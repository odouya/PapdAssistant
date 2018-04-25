using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using PapdLib;
using PapdLib.Info;
using PapdMonitor.Util;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace PapdMonitor
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class FrmMain : FrmBase
    {
        #region 属性和字段

        /// <summary>
        /// 商品抢购线程是否正在运行
        /// </summary>
        private bool isRunning = false;

        /// <summary>
        /// 商品抢购线程是否已经暂停
        /// </summary>
        private bool isPaused = false;

        /// <summary>
        /// 当前商品抢购列表
        /// </summary>
        private List<IProductInfo> monitorList = new List<IProductInfo>();

        /// <summary>
        /// 是否启用自定义循环间隔
        /// </summary>
        private bool enabledCustomLoopInternal;

        /// <summary>
        /// 自定义时间间隔
        /// </summary>
        private decimal customLoopInternal;

        /// <summary>
        /// 是否只显示可用健康金全部兑换的商品
        /// </summary>
        private bool isOnlyShowHealthGoldProduct;

        /// <summary>
        /// 是否启动定时任务
        /// </summary>
        private bool enableTimerStart = false;

        /// <summary>
        /// 查询商品接口模式
        /// 8位，从低位到高位分别代表接口1、接口2、。。。。
        /// </summary>
        private int SearchProductInterfaceMode = 2; 

        /// <summary>
        /// 按详细商品信息查询
        /// </summary>
        private bool m_grabByDetailProductInfo = true;

        private List<IProductInfo> m_currentProducts = new List<IProductInfo>();

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            InitNotifyIcon();
            InitAudioList();
            //状态栏中的子控件显示ToolTip
            this.statusStrip1.ShowItemToolTips = true;
            //初始化PapdHelper
            InitTimer();
            InitListViewKeyDown(this.tabControlQueryInfo);
            InitSetting();
            this.chbEnableQQMsg.Checked = false;
            this.dateTimePickerStartTime.Value = DateTime.Now.AddMinutes(10);
            GlobalContext.MainForm = this;
            InitTabPage();
        }

        /// <summary>
        /// 初始化TabControl中的所有ListView
        /// </summary>
        /// <param name="tc"></param>
        private void InitListViewKeyDown(TabControl tc)
        {
            foreach (TabPage tabPage in tc.TabPages)
            {
                for (int i = 0; i < tabPage.Controls.Count; i++)
                {
                    if (tabPage.Controls[i] is ListView)
                    {
                        tabPage.Controls[i].KeyDown += ListViewOnKeyDown;
                    }
                    else if (tabPage.Controls[i] is TabControl)
                    {
                        InitListViewKeyDown(tabPage.Controls[i] as TabControl);
                    }
                }
            }
        }

        /// <summary>
        /// 在ListView上按Ctrl+C复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                ListView lv = sender as ListView;

                var p = lv.PointToClient(MousePosition);
                ListViewHitTestInfo ti = lv.HitTest(p);
                if (ti != null && ti.SubItem != null)
                {
                    try
                    {
                        string content = ti.SubItem.Text;
                        Clipboard.SetData(DataFormats.Text, content);
                        //Clipboard.SetText(ti.SubItem.Text, TextDataFormat.UnicodeText);
                        //MessageBox.Show("已复制：" + content);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        #endregion

        #region 初始化

        private void InitTabPage()
        {
            // 初始化游戏中心模块
            var frmGameCenter = new FrmGameCenter();
            frmGameCenter.TopLevel = false;
            frmGameCenter.Parent = this.tabPageGameCenter;
            frmGameCenter.FormBorderStyle = FormBorderStyle.None;
            frmGameCenter.Dock = DockStyle.Fill;
            frmGameCenter.OutputEvent += (sender, args) => Output(args.Info);
            frmGameCenter.Show();
            this.tabPageGameCenter.Controls.Add(frmGameCenter);

            // 隐藏游戏页
            this.tabPageGameCenter.Parent = null;

            // 添加其他页面
            List<Control> controls = new List<Control>()
            {
                new FrmBatchHandle(),
                new FrmFetchBox(),
                new FrmLottery(),
            };
            foreach (var control in controls)
            {
                TabPage tp = new TabPage(control.Text);
                if (control is Form)
                {
                    var frm = control as Form;
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                }
                control.Visible = true;
                control.Dock = DockStyle.Fill;
                tp.Controls.Add(control);
                this.tabControlQueryInfo.TabPages.Add(tp);
            }
        }

        /// <summary>
        /// 初始化声音文件列表
        /// </summary>
        private void InitAudioList()
        {
            try
            {
                string audioPath = GlobalContext.AudioPath;
                var files = Directory.GetFiles(audioPath);
                this.cmbAudioList.Items.Clear();
                foreach (var file in files)
                {
                    this.cmbAudioList.Items.Add(Path.GetFileName(file));
                }
                if (files.Length > 0)
                {
                    int index = new Random().Next(0, files.Length-1);
                    this.cmbAudioList.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                DoOutput("初始化声音文件失败，" + ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化系统托盘图标
        /// </summary>
        private void InitNotifyIcon()
        {
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Text = "平安好医生助手";
            this.notifyIcon1.Icon = this.Icon;
            this.notifyIcon1.MouseClick += (s, e) =>
            {
                if (e.Button != MouseButtons.Left)
                    return;
                this.ShowInTaskbar = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            };
        }

        /// <summary>
        /// 初始化显示时间Timer
        /// </summary>
        private void InitTimer()
        {
            this.toolStripStatusLabelTimer.Text = "当前时间：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// 显示当前时间Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabelTimer.Text = "当前时间：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// 初始化设置
        /// </summary>
        private void InitSetting()
        {
            //折叠设置
            //button1_Click(this.button1, new EventArgs());
            //测试模式
            if (GlobalContext.IsTestMode)
            {
                this.toolStripButtonTest.Visible = true;
            }
            else
            {
                this.toolStripButtonTest.Visible = false;
            }

            //系统设置
            this.enabledCustomLoopInternal = this.chkboxEnableLoopInternal.Checked;
            this.customLoopInternal = this.numericUpDownLoopInternal.Value;
            this.isOnlyShowHealthGoldProduct = this.chkboxIsOnlyShowHealthGoldProduct.Checked;
            this.cmbBoxGrabMode.SelectedIndex = m_grabByDetailProductInfo ? 1 : 0;
            //设置抢购模式
            string strMode = Convert.ToString(SearchProductInterfaceMode, 2).PadLeft(this.chkboxlstSearchInterface.Items.Count,'0');
            char[] modeArray = strMode.ToCharArray();
            Array.Reverse(modeArray);
            for (int i = 0; i < modeArray.Length; i++)
            {
                this.chkboxlstSearchInterface.SetItemChecked(i, modeArray[i] == '1');
            }
        }

        #endregion

        #region 工具栏按钮

        /// <summary>
        /// “登录”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonLogin_Click(object sender, EventArgs e)
        {
            ToolStripButton tsBtn = sender as ToolStripButton;
            if (tsBtn.Text == "登录")
            {
                var frmLogin = new FrmLogin(GlobalContext.CurrentCookieString);
                if (frmLogin.ShowDialog() != DialogResult.OK)
                {
                    //登录失败
                    ChangeLoginState(null, null,null);
                    return;
                }

                //登录成功
                ChangeLoginState(frmLogin.MyUserInfo, frmLogin.CookieString, frmLogin.CertPath);
            }
            else
            {
                var dialogResult = MsgBox.ShowYesNoCancel("是否切换登录账号？");
                if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                    return;
                ChangeLoginState(null,null,null);
                if (dialogResult == DialogResult.Yes)
                {
                    // 切换账号s
                    toolStripButtonLogin.PerformClick();
                }
            }
        }

        /// <summary>
        /// 异步初始化历史充值手机号
        /// </summary>
        private void InitHistoryRechargeMobile()
        {
            ThreadPool.QueueUserWorkItem(p =>
            {
                try
                {
                    var mobiles = base.PH.GetHistoryOrderMobiles(GlobalContext.CurrentCookieString);
                    lock (GlobalContext.HistoryRechargeMobile)
                    {
                        GlobalContext.HistoryRechargeMobile.Clear();
                        GlobalContext.HistoryRechargeMobile.AddRange(mobiles);
                    }
                }
                catch (Exception ex)
                {
                }
            });
        }

        public void ChangeLoginState(UserInfo userInfo, string cookie, string certPath)
        {
            for (int i = 0; i < this.tabControlQueryInfo.TabPages.Count; i++)
            {
                TabPage tabPage = this.tabControlQueryInfo.TabPages[i];
                if (tabPage == this.tabPageMonitor) // 不清空商品列表tab页
                    continue;
                base.ClearControl(tabPage);
            }
            base.ClearControl(this.tabPage1);
            GlobalContext.ClearCurrentUserInfo();
            if (userInfo != null)
            {
                //登录成功
                base.SetControlText(this, GlobalContext.AppName + "---" + userInfo.nick);
                base.SetControlText(this.toolStripButtonLogin, "注销");
                base.SetControlText(this.toolStripStatusLabelUser, "当前用户：" + userInfo.nick);
                base.SetControlText(this.notifyIcon1, GlobalContext.AppName + "\r\n" + userInfo.nick);

                GlobalContext.CurrentUserInfo = userInfo;
                GlobalContext.CurrentCookieString = cookie;
                GlobalContext.CurrentCertPath = certPath;

                UserInfo2Control(userInfo);

                //声音提示
                ApiUtil.MessageBeep(ApiUtil.BeepType.MB_ICONASTERISK);

                Output();
                Output(MyUserInfo.nick + "，登陆成功。");

                var configInfo = ConfigStorage.GetInstance().GetConfigInfo();
                
                new Thread(() =>
                {
                    bool isAutoHandled = false;
                    // 查询健康金到期提醒
                    try
                    {
                        var result = PH.QueryGoldExpireInfo(GlobalContext.CurrentCookieString);
                        var goldExpireInfo = result.Content[0].pcValidityResult;
                        Output("您有"+goldExpireInfo.amount*0.01+"金将于"+goldExpireInfo.validityEndDate+"过期!");
                    }
                    catch (Exception ex2)
                    {
                        
                    }
                    if (configInfo.IsAutoFetchYesterdayBonus)
                    {
                        #region 领取昨日奖励
                        try
                        {
                            var rewardInfo = PH.QueryRewardInfo(GlobalContext.CurrentCookieString, 3000);
                            if (!rewardInfo.IsPreMoneyFetch())
                            {
                                var fetchRewardResult = PH.FetchReward(GlobalContext.CurrentCookieString,
                                    rewardInfo.preRewardId);
                                Output("昨日奖励领取成功！");
                            }
                            else
                            {
                                Output("昨日奖励已领取。");
                                //isAutoHandled = true;
                                //Output("即将跳过抢金、上传走步、夺宝操作。");
                            }
                        }
                        catch (Exception ex)
                        {
                            Output("昨日奖励领取失败，" + ex.Message);
                        }
                        #endregion 
                    }

                    if (configInfo.IsAutoGrabGold && !isAutoHandled)
                    {
                        #region 抢金

                        try
                        {
                            Output("正在抢金...");
                            var grabGoldInfo = PH.GetGrabGoldInfo(GlobalContext.CurrentCookieString, 1);
                            int success = 0;
                            for (int i = 0; i < grabGoldInfo.userRankingList.Length; i++)
                            {
                                var user = grabGoldInfo.userRankingList[i];
                                if (!user.IsGrabGoldAvailable())
                                {
                                    continue;
                                }
                                try
                                {
                                    PH.GrabGoldFromFollower(GlobalContext.CurrentCookieString, user.userInfo.userId);
                                    success++;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("抢金错误：" + ex.Message);
                                }
                            }
                            Output("成功抢金" + success + "个好友！");
                        }
                        catch (Exception ex)
                        {
                            Output("抢金失败," + ex.Message);
                        }
                        #endregion 
                    }

                    if (configInfo.IsAutoUploadWalkData && !isAutoHandled)
                    {
                        #region 上传走步数据
                        try
                        {
                            if (!File.Exists(MyCertPath))
                            {
                                throw new Exception("证书路径无效");
                            }
                            var downloadResult = PH.DownloadWalkData(base.MyUserInfo.id.ToString(), MyCookie, MyCertPath);
                            if (downloadResult != null)
                            {
                                PajkWalkDataInfo today = null;
                                if (downloadResult.Content[0].walkDataInfos == null ||
                                    (today = downloadResult.Content[0].walkDataInfos.Find(
                                            match => match.walkDate == DateTime.Now.ToString("yyyyMMdd")))==null)
                                {
                                    int stepCount = new Random((int) DateTime.Now.Ticks).Next(
                                        GlobalContext.CurrentConfigInfo.RandomMinStep,
                                        GlobalContext.CurrentConfigInfo.RandomMaxStep);
                                    var result = PH.UploadWalkData(base.MyUserInfo.id.ToString(), MyCookie, MyCertPath,
                                        stepCount);
                                    if (result.Content[0].Value)
                                    {
                                        Output("成功上传走步" + stepCount + "！");
                                    }
                                    else
                                    {
                                        throw new Exception(result.Stat.Code.ToString());
                                    } 
                                }
                                else
                                {
                                    Output("今天已上传走步" + today.stepCount + "。");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Output("上传走步失败，" + ex.Message);
                        }
                        #endregion 
                    }

                    if (configInfo.IsAutoGrabTreasure && !isAutoHandled)
                    {
                        #region 步步夺宝
                        Output("正在夺宝...");
                        var fetchBoxFuncList = new List<Func<string, PajkResultList<PajkFetchBoxResult>>>();
                        fetchBoxFuncList.Add(PH.FetchBoxByShareReading);
                        fetchBoxFuncList.Add(PH.FetchBoxByWalkMall);
                        fetchBoxFuncList.Add(PH.FetchBoxByInviteFriend);
                        fetchBoxFuncList.Add(PH.FetchBoxByVideo);
                        for (int i = 0; i < fetchBoxFuncList.Count; i++)
                        {
                            try
                            {
                                var fetchResult = fetchBoxFuncList[i](base.MyCookie);
                                Thread.Sleep(1200);
                                Output("得到宝箱：" + fetchResult.Content[0].BoxGiftList[0].GiftName);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        #endregion 
                    }

                    #region 查询余额
                    try
                    {
                        var goldInfo = PH.GetGoldInfo(GlobalContext.CurrentCookieString);
                        Output("我的余额：" + goldInfo.balance + "金");
                    }
                    catch (Exception ex)
                    {
                        Output("余额查询失败，" + ex.Message);
                    } 
                    #endregion

                    #region 查询下次可抢购时间

                    try
                    {
                        var orders = PH.QueryOrders(MyCookie, OrderType.ALL, 1);
                        if (orders.Count > 0)
                        {
                            DateTime lastOrderCreateTime = PapdHelper.ConvertFromUnixTime(orders[0].createTime);
                            DateTime nextOrderCreateTime = lastOrderCreateTime.AddDays(GlobalContext.CurrentConfigInfo.CreateOrderTimespan);
                            var leftDays = Math.Round((nextOrderCreateTime - DateTime.Now).TotalDays, 1);
                            Output(string.Format("下次抢购时间：{0}，{1}",
                                nextOrderCreateTime.ToString("yyyy/MM/dd HH:mm:ss dddd"),
                                leftDays > 0 ? ("还有" + leftDays + "天") : "可抢"));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("查询下次抢购时间失败，" + ex.Message);
                    }
                    #endregion

                }){IsBackground = true}.Start();
                
                //初始化历史充值手机号
                InitHistoryRechargeMobile();
            }
            else
            {
                base.SetControlText(this, GlobalContext.AppName);
                base.SetControlText(this.toolStripButtonLogin, "登录");
                base.SetControlText(this.toolStripStatusLabelUser, "当前用户:[未登录]");
                base.SetControlText(this.notifyIcon1, GlobalContext.AppName);

                GlobalContext.ClearCurrentUserInfo();
            }
        }

        /// <summary>
        /// “查询”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.listViewProduct.Items.Clear();
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    Output("正在查询所有商品...");
                    var products = GetExchangeProducts();
                    ProductInfos2Control(products, true);
                    Output("查询结束，共查询到" + products.Count + "个！");
                    lock (m_currentProducts)
                    {
                        if(m_currentProducts!=null)
                            m_currentProducts.Clear();
                        m_currentProducts = products;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询失败，" + ex.Message);
                }
            });
        }

        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        private List<IProductInfo> GetExchangeProducts()
        {
            List<IProductInfo> products = new List<IProductInfo>();
            if ((this.SearchProductInterfaceMode&1)==1)
            {
                //Console.WriteLine("接口1已启用");
                products.AddRange(PH.GetExchangeProductsV1(isOnlyShowHealthGoldProduct));
            }
            if ((this.SearchProductInterfaceMode & 2)>>1 == 1)
            {
                //Console.WriteLine("接口2已启用");
                products.AddRange(PH.GetExchangeProductsWithFull(isOnlyShowHealthGoldProduct));
            }
            if ((this.SearchProductInterfaceMode & 4)>>2 == 1)
            {
                //Console.WriteLine("接口3已启用");
                products.AddRange(PH.GetExchangeProductsWithHalf(isOnlyShowHealthGoldProduct));
            }
            if ((this.SearchProductInterfaceMode & 8)>>3 == 1)
            {
                //Console.WriteLine("接口4已启用");
                products.AddRange(PH.GetExchangeProductsWithPrivilege(isOnlyShowHealthGoldProduct));
            }

            var result = new List<IProductInfo>();
            for (int i = 0; i < products.Count; i++)
            {
                if (result.Find(match => match.id == products[i].id) != null)
                    continue;
                result.Add(products[i]);
            }

            return result;
        }

        /// <summary>
        /// “开始抢购”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonMonitor_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                #region 获取商品抢购列表
                this.monitorList.Clear();
                for (int i = 0; i < this.listBoxMonitor.Items.Count; i++)
                {
                    var item = this.listBoxMonitor.Items[i] as IProductInfo;
                    monitorList.Add(item);
                }
                if (monitorList.Count < 1)
                {
                    MsgBox.ShowInfo("请先添加需要抢购的商品！");
                    return;
                } 
                #endregion

                if (!base.CheckLoginState())
                    return;

                isRunning = true;
                this.toolStripButtonMonitor.Text = "停止抢购";
                SetControlStateWhenMonitor(false);

                //启动抢购线程
                Thread thread = new Thread(DoMonitor);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                isPaused = true;
            }
        }

        /// <summary>
        /// 商品抢购异步线程
        /// </summary>
        private void DoMonitor()
        {
            Stopwatch sw = new Stopwatch();
            Random random = new Random();
            try
            {
                bool lastVerifyShown = false;
                DateTime lastRecommandTime = DateTime.Now;
                int loopTimes = 1;//循环检测次数
                while (isRunning)
                {
                    if (loopTimes >= 1000)
                        loopTimes = 1;

                    sw.Reset();
                    sw.Start();
                    try
                    {
                        IProductInfo foundProduct = null;
                        if (!m_grabByDetailProductInfo)
                        {
                            //获取商品信息
                            var products = GetExchangeProducts();
                            //加载到控件
                            ProductInfos2Control(products, true);
                            //检测抢购列表中的商品是否可以兑换
                            foreach (var product in products)
                            {
                                for (int i = 0; i < monitorList.Count; i++)
                                {
                                    if (monitorList[i].id == product.id && product.exchange)
                                    {
                                        foundProduct = product;
                                    }
                                }
                            } 
                        }
                        else
                        {
                            for (int i = 0; i < monitorList.Count; i++)
                            {
                                var product = monitorList[i];
                                var detailInfo = PH.GetProductDetail(product.id, product.storeId);
                                if (detailInfo.items.Length > 0 && detailInfo.items[0].stockNum > 0)
                                {
                                    foundProduct = product;
                                }
                            } 
                        }
                        // 智能提前输入验证码
                        List<DateTime> recommandTimes = GetRecommandTimes();
                        foreach (var recommandTime in recommandTimes)
                        {
                            if (recommandTime > DateTime.Now)
                            {
                                // 时间差为两分钟
                                double minutes = (recommandTime - DateTime.Now).TotalMinutes;
                                if (minutes <= 2)
                                {
                                    if (!DateEquals(recommandTime, lastRecommandTime))
                                    {
                                        lastVerifyShown = false;
                                    }
                                    if (!lastVerifyShown)
                                    {
                                        Output("下次抢购时间：" + recommandTime);
                                        Output("开始提前输入验证码...");
                                        var products = PH.GetExchangeProductsWithFull(isOnlyShowHealthGoldProduct);
                                        var product = products.Find(match => match.name.Contains("电子券") && match.exchange);
                                        if (product != null)
                                        {
                                            base.DoTask(() => ShowVerifyCode(product), "错误");
                                        }
                                        lastVerifyShown = true;
                                        lastRecommandTime = recommandTime;
                                        break; 
                                    }
                                }
                            }
                        }
                        if (foundProduct != null)
                        {
                            //商品可以兑换
                            DoTip(foundProduct);
                            DoGrab(foundProduct);
                            return;
                        }
                    }
                    catch (UserStateException ex)
                    {
                        //用于检测账户在其他设备上登录等状态
                        Output("账户状态异常，" + ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Output("异常，" + ex.Message);
                    }

                    //循环延时
                    int randomTime = (int)this.customLoopInternal;
                    if (!this.enabledCustomLoopInternal)
                    {
                        randomTime = random.Next(1, 3); 
                    }
                    sw.Stop();
                    Output("第" + (loopTimes++).ToString("000") + "次，用时：" + sw.Elapsed.TotalSeconds.ToString("0.0") + "秒");
                    for (int i = 0; i < randomTime; i++)
                    {
                        Thread.Sleep(1000);

                        //检测是否停止抢购
                        if (isPaused)
                        {
                            isPaused = false;
                            if (MsgBox.ShowYesNo("是否停止？","提示") == System.Windows.Forms.DialogResult.Yes)
                            {
                                return;
                            }
                        }

                        //检测当前登录状态
                        if (GlobalContext.CurrentUserInfo == null)
                        {
                            Output("用户已退出！");
                            return;
                        }
                    }
                }
            }
            finally
            {
                isRunning = false;
                SetControlStateWhenMonitor(true);
                this.Invoke(new Action(() => { this.toolStripButtonMonitor.Text = "开始抢购"; }));

                //关闭音乐
                CloseAudio();
            }
        }

        private bool DateEquals(DateTime dt1, DateTime dt2)
        {
            return dt1.Year == dt2.Year && 
                dt1.Month == dt2.Month && 
                dt1.Day == dt2.Day &&
                dt1.Hour == dt2.Hour && 
                dt1.Minute == dt2.Minute && 
                dt1.Second == dt2.Second;
        }
        /// <summary>
        /// 抢购提示
        /// </summary>
        /// <param name="product"></param>
        private void DoTip(IProductInfo product)
        {
            var msg = "亲," + product.name + ",有货了!";

            //气泡提醒
            ShowBalloonTip(msg);

            //声音提醒
            if (this.chbEnableAudio.Checked)
            {
                PlaySelectedAudio();
            }

            //QQ提醒
            if (this.chbEnableQQMsg.Checked && SelectedQQWindow != null)
            {
                SendQQMessage(msg);
                Thread.Sleep(500);
            }

            //通过IE抢购
            //if (!string.IsNullOrEmpty(GlobalContext.CurrentCookieString))
            //{
            //    PapdHelper.StartIE(product.GetProductDetailUrl(), GlobalContext.CurrentCookieString);
            //}

            //MessageBox提醒
            //MessageBox.Show(msg);
        }

        /// <summary>
        /// 抢购流程
        /// </summary>
        /// <param name="productInfo"></param>
        /// <param name="cookie"></param>
        /// <param name="mobile"></param>
        /// <param name="address"></param>
        public void DoGrab(IProductInfo productInfo, string cookie, string mobile, AddressInfo address)
        {
            if (checkVerifyCodeOrdering)
            {
                var isTakeOrderOk = IsTakeOrderOk(productInfo);
                if (isTakeOrderOk)
                {
                    Output("已跳过验证码输入！");
                }
                else
                {
                    Output("正在拉取验证码...");
                    var result = ShowVerifyCode(productInfo);
                    if (result == false)
                    {
                        Output("已取消下单！");
                        return;
                    }
                }
            }
            else
            {
                Output("正在拉取验证码...");
                var result = ShowVerifyCode(productInfo);
                if (result == false)
                {
                    Output("已取消下单！");
                    return;
                }
            }

            #region 开始抢购
            Output();
            Output("启动抢购流程...");
            Output();

            Output(">正在抢购【" + productInfo.name + "】...");
            try
            {
                #region 检测商品类型，是否为手机充值类
                if (productInfo.IsMobileRechargeProduct)
                {
                    Output("手机号：" + mobile);
                }
                else
                {
                    if (address == null)
                    {
                        throw new Exception("未设置收货地址！");
                    }
                    Output("收货地址：" + address);
                }
                #endregion

                #region 提交订单
                // 提交订单前，增加延时
                int sleepTime = new Random((int) DateTime.Now.Ticks).Next(200, 800);
                Thread.Sleep(sleepTime);
                string successUrl = PH.CreateOrder(cookie,
                                productInfo.id,
                                productInfo.storeId,
                                mobile,
                                address);
                Output(successUrl);
                #endregion

                Output("抢购成功！");
                MsgBox.ShowInfo("抢购成功！");
            }
            catch (Exception ex)
            {
                Output("抢购失败，" + ex.Message);
                MsgBox.ShowInfo("抢购失败，" + ex.Message);
            }

            #endregion
        }

        /// <summary>
        /// 抢购流程
        /// </summary>
        /// <param name="productInfo"></param>
        public void DoGrab(IProductInfo productInfo)
        {
            DoGrab(productInfo, GlobalContext.CurrentCookieString,
                GlobalContext.CurrentRechargePhone,
                GlobalContext.CurrentAddressInfo);
        }

        /// <summary>
        /// “帮助”-“关于”菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            var frm = new FrmAbout();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// “测试”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonTest_Click(object sender, EventArgs e)
        {
            var frm = new FrmTest();
            frm.ShowDialog();
        }

        /// <summary>
        /// “帮助”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonHelp_ButtonClick(object sender, EventArgs e)
        {
            this.toolStripButtonHelp.ShowDropDown();//点击ToolStripSplitButton时，显示子项
        }

        /// <summary>
        /// “帮助”-“查看活动规则”菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemViewActivityRules_Click(object sender, EventArgs e)
        {
            var frm = new FrmWeb("http://gc.jk.cn/duojin/activityRule.html");
            frm.ShowDialog();
        }

        /// <summary>
        /// “设置”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frm = new FrmSetting();
            frm.ShowDialog();
            frm.Dispose();
        }
        #endregion

        #region 信息查询TabControl

        #region 抢购页面

        /// <summary>
        /// 在“商品列表”中点击右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewProduct_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            ContextMenuStrip cms = new ContextMenuStrip();
            if (GlobalContext.CurrentUserInfo != null && !isRunning)
            {
                cms.Items.Add("添加到抢购列表", null, toolStripMenuItemAddToMinitorList_Click);
            }
            if (this.listViewProduct.SelectedItems.Count == 1)
            {
                var item = this.listViewProduct.SelectedItems[0];
                var product = item.Tag as IProductInfo;
		        cms.Items.Add("查看商品图片", null, ((o, args) =>
		        {
                    DoTask(() =>
                    {
                        var detailInfo = PH.GetProductDetail(product.id, product.storeId);
                        var pics = detailInfo.pictures;
                        var image = PH.GetImageByPapdCode(pics);
                        new FrmViewPic(image).ShowDialog();
                    }, "查看失败");
		            
                    //StringBuilder builder = new StringBuilder();
                    //builder.AppendLine("商品名称：" + product.name);
                    //builder.AppendLine("  商品ID：" + product.id);
                    //builder.AppendLine("  商店ID：" + product.storeId);

                    //MsgBox.ShowInfo(builder.ToString());
                }));
                cms.Items.Add("查看商品详情", null, (o, args) =>
                {
                    string detailUrl = string.Format("https://yao-h5.s.jk.cn/home.html#/yao-detail/{0}", product.id);
                    Process.Start(detailUrl);
                });
                cms.Items.Add("提前输入验证码", null, (o, args) =>
                {
                    base.DoTask(() =>
                    {
                        var verifyResult = ShowVerifyCode(product);
                        if (verifyResult)
                        {
                            MsgBox.ShowInfo("Ok!");
                        }
                    }, "错误");
                });
                cms.Items.Add("检测是否可以下单", null, (o, args) =>
                {
                    var takeOrderResult = IsTakeOrderOk(product);
                    MsgBox.ShowInfo((takeOrderResult ? "" : "不") + "可以下单！");
                });

                
            }
            cms.Show(this.listViewProduct,e.Location);
        }
        
        /// <summary>
        /// “添加到抢购列表”菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAddToMinitorList_Click(object sender, EventArgs e)
        {
            if (this.listViewProduct.SelectedItems.Count > 0)
            {
                for (int i = 0; i < this.listViewProduct.SelectedIndices.Count; i++)
                {
                    var index = this.listViewProduct.SelectedIndices[i];
                    var productInfo = this.listViewProduct.Items[index].Tag as IProductInfo;
                    AppendToMonitorList(productInfo);
                }
            }
        }

        /// <summary>
        /// 添加到抢购列表中
        /// </summary>
        /// <param name="productInfo"></param>
        private void AppendToMonitorList(IProductInfo productInfo)
        {
            if (this.listBoxMonitor.Items.Contains(productInfo))//去重
                return;
            if (productInfo.name.Contains("手机话费"))
            {
                if(StringTool.IsNullOrWhitespace(GlobalContext.CurrentRechargePhone))
                {
                    btnChangeRechargePhone_Click(null, null); 
                }
                if(StringTool.IsNullOrWhitespace(GlobalContext.CurrentRechargePhone))
                    return;
            }
            else
            {
                if (GlobalContext.CurrentAddressInfo == null)
                {
                    btnChangeCurrentAddress_Click(null, null);
                }
                if (GlobalContext.CurrentAddressInfo == null)
                    return;
            }
            this.listBoxMonitor.Items.Add(productInfo);
        }

        /// <summary>
        /// 当抢购商品时，设置控件状态
        /// </summary>
        /// <param name="enabled"></param>
        private void SetControlStateWhenMonitor(bool enabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetControlStateWhenMonitor), enabled);
                return;
            }
            this.toolStripButtonSearch.Enabled = enabled;
            //this.listViewProduct.Enabled = enabled;
            this.listBoxMonitor.Enabled = enabled;
        }

        /// <summary>
        /// 将“所有商品信息”填充到控件上
        /// </summary>
        /// <param name="products">所有商品</param>
        /// <param name="isClearBefore">添加前是否先清空</param>
        private void ProductInfos2Control(List<IProductInfo> products, bool isClearBefore)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<IProductInfo>, bool>(ProductInfos2Control), products, isClearBefore);
                return;
            }

            if (isClearBefore)
            {
                this.listViewProduct.Items.Clear();
            }

            //排序
            products = products.OrderBy(p => p.name).ToList();

            int index = 0;
            foreach (var product in products)
            {
                var item = new ListViewItem((++index).ToString());
                item.SubItems.Add(product.id.ToString());
                item.SubItems.Add(product.name);
                item.SubItems.Add(product.exchange ? "1":"0");
                item.SubItems.Add((product.price / 100f).ToString("0.00"));
                item.SubItems.Add((product.healthGold / 100f).ToString("0.00"));
                item.Tag = product;

                this.listViewProduct.Items.Add(item);

                if (!isOnlyShowHealthGoldProduct && product.IsFullHealthGoldProduct)
                {
                    HighlightListViewRow(this.listViewProduct, index - 1, Color.LightSkyBlue);
                }
            }
        }

        /// <summary>
        /// 双击商品信息ListView时，显示商品的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewProduct_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (this.listViewProduct.SelectedIndices.Count != 1)
                return;

            if (GlobalContext.CurrentUserInfo == null)
                return;

            ListViewItem item = this.listViewProduct.SelectedItems[0];
            IProductInfo info = item.Tag as IProductInfo;
            var frm = new FrmCreateOrder(info);
            frm.ShowDialog();
        }

        #region 搜索商品名称相关

        /// <summary>
        /// Ctrl+F显示隐藏搜索框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                this.panelFindProduct.Visible = !this.panelFindProduct.Visible;
            }
        }

        /// <summary>
        /// 关闭搜索框按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseFind_Click(object sender, EventArgs e)
        {
            this.panelFindProduct.Visible = false;
        }

        /// <summary>
        /// 搜索商品名称按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            if (m_currentProducts != null)
            {
                var list = new List<IProductInfo>();
                string pattern = this.txtFindProduct.Text.Trim();
                if (pattern.Length < 1)
                {
                    list = m_currentProducts;
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < m_currentProducts.Count; i++)
                        {
                            if (Regex.IsMatch(m_currentProducts[i].name, pattern, RegexOptions.IgnoreCase))
                            {
                                list.Add(m_currentProducts[i]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowWarnning("无效查询！");
                        return;
                    }
                }
                ProductInfos2Control(list, true);
            }
        }

        /// <summary>
        /// 在搜索框中回车直接搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFindProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindProduct_Click(null, null);
            }
        }
        #endregion

        #endregion

        #region 我的信息

        /// <summary>
        /// “查询用户信息”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryUserInfo_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageMyInfo);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(o =>
            {
                this.btnQueryUserInfo.Text = "查询中";
                this.btnQueryUserInfo.Enabled = false;
                try
                {
                    Output("正在查询我的信息...");
                    var userInfo = PH.GetUserInfo(GlobalContext.CurrentCookieString);
                    UserInfo2Control(userInfo);
                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryUserInfo.Text = "查询用户信息";
                    this.btnQueryUserInfo.Enabled = true;
                }
            });
        }

        /// <summary>
        /// 将用户信息填充到控件上
        /// </summary>
        /// <param name="userInfo"></param>
        private void UserInfo2Control(UserInfo userInfo)
        {
            this.txtUserId.Text = userInfo.id.ToString();
            this.txtUserNick.Text = userInfo.nick;
            this.txtUserGender.Text = userInfo.GetGender();
            this.txtUserMobile.Text = userInfo.mobile.ToString();
            WebClient client = new WebClient();
            var avatarData = client.DownloadData(userInfo.GetAvatarUrl());
            using (var ms = new MemoryStream())
            {
                ms.Write(avatarData, 0, avatarData.Length);
                this.pbAvatar.BackgroundImage = Image.FromStream(ms);
                this.pbAvatar.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        #endregion

        #region 我的幸福金

        /// <summary>
        /// “查询幸福金”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryGoldInfo_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageGoldInfo);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(o =>
            {
                this.btnQueryGoldInfo.Enabled = false;
                this.btnQueryGoldInfo.Text = "查询中";
                try
                {
                    Output("正在查询幸福金...");
                    var goldInfo = PH.GetGoldInfo(GlobalContext.CurrentCookieString);
                    GoldInfo2Control(goldInfo);
                    Output("我的余额：" + goldInfo.balance + "金");
                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryGoldInfo.Enabled = true;
                    this.btnQueryGoldInfo.Text = "查询幸福金";
                }
            });
        }

        /// <summary>
        /// 将幸福金信息填充到控件上
        /// </summary>
        /// <param name="goldInfo"></param>
        private void GoldInfo2Control(GoldInfo goldInfo)
        {
            this.txtBanlance.Text = "￥" + goldInfo.balance.ToString();
            this.txtCumulativeReward.Text = "￥" + goldInfo.cumulativeReward.ToString();
            this.txtInvitationReward.Text = "￥" + goldInfo.invitationReward.ToString();
            this.txtStepReward.Text = "￥" + goldInfo.stepReward.ToString();
        }

        /// <summary>
        /// 幸福金续期按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelayGoldExpiredTime_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            base.DoTask(() =>
            {
                string result = PH.DelayGlodExpireTime(GlobalContext.CurrentCookieString);
                DoOutput(result);
                if (result.Contains("HEALTH_GOLD_DELAY"))
                {
                    MsgBox.ShowInfo("续期成功！");
                }
            }, "幸福金续期");
        }
        #endregion

        #region 我的邀请

        /// <summary>
        /// “查询我的邀请”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryInvitees_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageInvite);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(o =>
            {
                this.btnQueryInvitees.Enabled = false;
                this.btnQueryInvitees.Text = "查询中";
                try
                {
                    Output("正在查询我的邀请...");
                    List<InviteeInfo> inviteds = new List<InviteeInfo>();
                    List<InviteeInfo> invitings = new List<InviteeInfo>();

                    #region 获取所有已成功邀请的好友
                    int pageNo = 1;
                    while (true)
                    {
                        var list = PH.GetInvitees(GlobalContext.CurrentCookieString, true, pageNo++);
                        if (list.Count < 1)
                            break;
                        inviteds.AddRange(list);
                    } 
                    #endregion

                    #region 获取所有正在邀请的好友
                    pageNo = 1;
                    while (true)
                    {
                        var list = PH.GetInvitees(GlobalContext.CurrentCookieString, false, pageNo++);
                        if (list.Count < 1)
                            break;
                        invitings.AddRange(list);
                    } 
                    #endregion

                    //调整好友顺序，将最先邀请的好友放在最前面
                    inviteds.Reverse();
                    invitings.Reverse();

                    Invitess2Control(inviteds, invitings);
                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryInvitees.Enabled = true;
                    this.btnQueryInvitees.Text = "查询我的邀请";
                }
            });
        }

        /// <summary>
        /// 将邀请的好友信息填充到控件上
        /// </summary>
        /// <param name="invitedList"></param>
        /// <param name="invitingList"></param>
        private void Invitess2Control(List<InviteeInfo> invitedList, List<InviteeInfo> invitingList)
        {
            int index = 0;
            foreach (var info in invitedList)
            {
                var item = new ListViewItem(new string[]
                {
                    (++index).ToString(),
                    info.nickname,
                    info.mobile,
                    info.status.ToString(),
                    info.hasRemind.ToString(),
                    info.userId.ToString(),
                    info.stage.ToString()
                });
                item.Tag = info;

                this.lvInvitees.Items.Add(item);
            }

            foreach (var info in invitingList)
            {
                var item = new ListViewItem(new string[]
                {
                    (++index).ToString(),
                    info.nickname,
                    info.mobile,
                    info.status.ToString(),
                    info.hasRemind.ToString()
                });
                item.Tag = info;

                this.lvInvitees.Items.Add(item);
            }
        }

        /// <summary>
        /// 在被邀请人列表上点击右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvInvitees_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.lvInvitees.SelectedItems.Count != 1)
                    return;

                ListViewItem selectedItem = this.lvInvitees.SelectedItems[0];
                InviteeInfo inviteeInfo = selectedItem.Tag as InviteeInfo;

                var cms = new ContextMenuStrip();
                if (inviteeInfo.hasRemind == 0)
                {
                    cms.Items.Add("提醒", null, (o, args) =>
                    {
                        try
                        {
                            PH.NoticeRegisterToInvitee(inviteeInfo, GlobalContext.CurrentCookieString);
                            MessageBox.Show("提醒成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提醒失败，" + ex.Message);
                        }
                    });
                    cms.Show(this.lvInvitees,e.Location);
                }
            }
        }

        /// <summary>
        /// 生成邀请二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateInviteQRImage_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            Control.CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(()=>
            {
                this.btnCreateInviteQRImage.Enabled = false;
                this.btnCreateInviteQRImage.Text = "生成中";
                Image qrImage;
                InviteCodeInfo inviteInfo;
                try
                {
                    Output("正在生成邀请二维码...");
                    inviteInfo = PH.GetInviteQRInfo(GlobalContext.CurrentCookieString);
                    qrImage = PH.GetImageByPapdCode(inviteInfo.QRCodeUrl);
                    Output("生成成功！");
                }
                catch (Exception ex)
                {
                    Output("生成失败，" + ex.Message);
                    return;//执行finally=>return
                }
                finally
                {
                    this.btnCreateInviteQRImage.Enabled = true;
                    this.btnCreateInviteQRImage.Text = "生成邀请二维码";
                }

                var frm = new FrmQRCode(qrImage, inviteInfo.QRCodeUrl, inviteInfo.inviteCode);
                frm.ShowDialog();
            });
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        #endregion

        #region 昨日记步奖励

        /// <summary>
        /// “查询昨日记步奖励”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryPreRewardInfo_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageLastBonus);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryPreRewardInfo.Enabled = false;
                this.btnQueryPreRewardInfo.Text = "查询中";
                try
                {
                    Output("正在查询昨日奖励...");
                    var info = PH.QueryRewardInfo(GlobalContext.CurrentCookieString, 3000);

                    this.Invoke(new Action(() =>
                    {
                        this.txtPreRewardID.Text = info.preRewardId.ToString();
                        this.txtPreMoney.Text = "￥" + info.preMoney.ToString();
                        this.txtIsPreDoubleMoney.Text = info.isDoublePreMoney ? "已翻倍" : "未翻倍";
                        this.txtIsPreDoubleMoney.ForeColor = info.isDoubleNowMoney ? Color.Black : Color.Red;
                        this.txtIsPreMoneyFetch.Text = info.IsPreMoneyFetch() ? "已领取" : "未领取";
                        this.txtIsPreMoneyFetch.ForeColor = info.IsPreMoneyFetch() ? Color.Black : Color.Red;
                        this.txtPreSteps.Text = info.CalcStepNumber();
                        if (info.IsPreMoneyFetch())
                        {
                            this.btnFetchReward.Text = "已领取";
                            this.btnFetchReward.ForeColor = Color.Green;
                            this.btnFetchReward.Tag = null;
                            this.btnFetchReward.Visible = false;
                        }
                        else
                        {
                            this.btnFetchReward.Text = "领钱";
                            this.btnFetchReward.ForeColor = Color.Red;
                            this.btnFetchReward.Tag = info.preRewardId;
                            this.btnFetchReward.Visible = true; //修改Visible属性时报错，则改为this.Invoke方式修改控件
                        }
                    }));
                    
                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryPreRewardInfo.Enabled = true;
                    this.btnQueryPreRewardInfo.Text = "查询昨日奖励";
                }
            });
        }

        /// <summary>
        /// “领取”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFetchReward_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag == null)
                return;

            long preRewardId = Convert.ToInt64(btn.Tag);
            try
            {
                PH.FetchReward(GlobalContext.CurrentCookieString, preRewardId);
                MessageBox.Show("领取成功！");

                this.txtIsPreMoneyFetch.Text = "已领取";
                this.txtIsPreMoneyFetch.ForeColor = Color.Green;

                this.btnFetchReward.Visible = false;
                this.btnFetchReward.Text = "已领取";
                this.btnFetchReward.ForeColor = Color.Green;
                this.btnFetchReward.Tag = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 好友排行

        /// <summary>
        /// “查询好友排行”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryFriendRanking_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageFriendRank);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryFriendRanking.Enabled = false;
                this.btnQueryFriendRanking.Text = "查询中";
                try
                {
                    Output("正在查询好友排行...");
                    var rankingInfo = PH.GetFriendRankingList(GlobalContext.CurrentCookieString,1);
                    FriendRanking2Control(rankingInfo, this.lvFriendRanking,this.txtRankingDate);
                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryFriendRanking.Enabled = true;
                    this.btnQueryFriendRanking.Text = "查询好友排行";
                }
            });
        }

        /// <summary>
        /// 将好友排行信息填充到控件上
        /// </summary>
        /// <param name="info"></param>
        private void FriendRanking2Control(RankingInfo info, ListView lvRanking, TextBox txtRankingDate)
        {
            txtRankingDate.Text = info.rankingDay;
            info.userRankingList = info.userRankingList.OrderBy(rl => rl.index).ToArray();//根据排名进行排序
            foreach (var item in info.userRankingList)
            {
                var listViewItem = new ListViewItem(item.index.ToString());
                listViewItem.SubItems.Add(item.userInfo.name);
                listViewItem.SubItems.Add(item.steps.ToString("N0"));
                listViewItem.SubItems.Add(item.bonus.ToString());
                listViewItem.Tag = item;

                lvRanking.Items.Add(listViewItem);
            }

            if (info.myRankingInfo!=null && 
                info.myRankingInfo.index<=lvRanking.Items.Count)
            {
                HighlightListViewRow(lvRanking, info.myRankingInfo.index - 1);
            }
        }

        /// <summary>
        /// 好友排行右键点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvFriendRanking_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (this.lvFriendRanking.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = this.lvFriendRanking.SelectedItems[0];
                RankingInfoLite infoLite = selectedItem.Tag as RankingInfoLite;

                ContextMenuStrip cms = new ContextMenuStrip();
                if (!infoLite.isBonusAccepted)
                {
                    cms.Items.Add("叫Ta领钱", null, (o, args) =>
                            {
                                try
                                {
                                    PH.NoticeBonusToFollower(GlobalContext.CurrentCookieString, infoLite.userInfo.userId);
                                    infoLite.isBonusAccepted = true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }); 
                }
                if (!infoLite.isPraised)
                {
                    cms.Items.Add("赞Ta", null, (o, args) =>
                    {
                        try
                        {
                            PH.PraiseToFollower(GlobalContext.CurrentCookieString, infoLite.userInfo.userId);
                            infoLite.isPraised = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });
                }
                if (cms.Items.Count < 1)
                    return;

                cms.Show(this.lvFriendRanking,e.Location);
            }
        }

        #endregion

        #region 步步抢金
        /// <summary>
        /// “查询步步抢金”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryGrabGold_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageGrabGold);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryGrabGold.Enabled = false;
                this.btnQueryGrabGold.Text = "查询中";
                try
                {
                    Output("正在查询步步抢金...");
                    var grabGoldInfo = PH.GetGrabGoldInfo(GlobalContext.CurrentCookieString, 1);
                    GrabGoldInfo2Control(grabGoldInfo);
                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryGrabGold.Enabled = true;
                    this.btnQueryGrabGold.Text = "查询步步抢金";
                }
            });
        }

        private void GrabGoldInfo2Control(GrabGoldInfo info)
        {
            this.txtGrabGoldRankingDate.Text = info.rankingDay;
            this.txtTotalGrabGold.Text = info.totalAngPao + "元";
            List<GrabGoldInfoLite> list = new List<GrabGoldInfoLite>();
            list.AddRange(info.initRankingList);
            list.AddRange(info.userRankingList);
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var listViewItem = new ListViewItem(item.userInfo.name);
                listViewItem.SubItems.Add(item.steps.ToString("N0"));
                listViewItem.SubItems.Add(item.IsBonusFetched()?"是":"否");
                listViewItem.SubItems.Add(item.GetGrabGoldInfo(GlobalContext.CurrentUserInfo.id));
                listViewItem.SubItems.Add(item.angPao*0.01 + "");
                listViewItem.Tag = item;

                this.lvGrabGoldRanking.Items.Add(listViewItem);

                if (item.IsGrabGoldAvailable())
                {
                    HighlightListViewRow(this.lvGrabGoldRanking,i);
                }
            }
        }

        private void lvGrabGoldRanking_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (this.lvGrabGoldRanking.SelectedItems.Count == 1)
            {
                var info = this.lvGrabGoldRanking.SelectedItems[0].Tag as GrabGoldInfoLite;
                if (info.IsBonusFetched() &&
                    info.IsGrabGoldAvailable())
                {
                    ContextMenuStrip cms = new ContextMenuStrip();
                    cms.Items.Add("马上抢", null, (o, args) =>
                    {
                        try
                        {
                            PH.GrabGoldFromFollower(GlobalContext.CurrentCookieString, info.userInfo.userId);
                            MsgBox.ShowInfo("抢金成功！");

                            info.fId = GlobalContext.CurrentUserInfo.id;
                            int rowIndex = this.lvGrabGoldRanking.SelectedItems[0].Index;
                            this.lvGrabGoldRanking.Items[rowIndex].SubItems[3].Text = info.GetGrabGoldInfo(GlobalContext.CurrentUserInfo.id);
                            HighlightListViewRow(this.lvGrabGoldRanking, rowIndex, this.lvGrabGoldRanking.BackColor);
                        }
                        catch (Exception ex)
                        {
                            MsgBox.ShowInfo("抢金失败，" + ex.Message);
                        }
                    });
                    cms.Show(this.lvGrabGoldRanking, e.Location);
                }
            }
        }
        #endregion

        #region 赚钱排行
        /// <summary>
        /// “查询赚钱排行”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryBonusRankingList_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageBonusRank);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryBonusRankingList.Enabled = false;
                this.btnQueryBonusRankingList.Text = "查询中";
                try
                {
                    Output("正在查询赚钱排行...");
                    RankingInfo rankingInfo = new RankingInfo();
                    rankingInfo = PH.GetBonusRankingList(GlobalContext.CurrentCookieString, 1);
                    BonusRanking2Control(rankingInfo);
                    //在最后一行添加我的信息
                    var myRankingInfo = rankingInfo.myRankingInfo;
                    var listViewItem = new ListViewItem(myRankingInfo.index.ToString());
                    listViewItem.SubItems.Add(myRankingInfo.userInfo.name);
                    listViewItem.SubItems.Add(myRankingInfo.steps.ToString("N0"));
                    listViewItem.SubItems.Add(myRankingInfo.bonus.ToString());
                    listViewItem.Tag = myRankingInfo;
                    this.lvBonusRankingList.Items.Add(listViewItem);
                    HighlightListViewRow(this.lvBonusRankingList,this.lvBonusRankingList.Items.Count-1);

                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryBonusRankingList.Enabled = true;
                    this.btnQueryBonusRankingList.Text = "查询赚钱排行";
                }
            });
        }

        private void BonusRanking2Control(RankingInfo rankingInfo)
        {
            FriendRanking2Control(rankingInfo, this.lvBonusRankingList,this.txtBonusRankingDate);
        }
        #endregion

        #region 订单信息

        /// <summary>
        /// “查询订单信息”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryOrders_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageOrderInfo);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryOrders.Enabled = false;
                this.btnQueryOrders.Text = "查询中";
                try
                {
                    Output("正在查询我的订单...");
                    int pageNo = 1;
                    List<OrderInfo> list = new List<OrderInfo>();
                    while (true)
                    {
                        var orders = PH.QueryOrders(GlobalContext.CurrentCookieString, OrderType.ALL, pageNo++);
                        list.AddRange(orders);
                        if (orders.Count < 1)
                            break;
                    }
                    list = list.OrderByDescending(info => info.createTime).ToList();
                    OrderInfos2Control(this.lvAllOrders, list);
                    OrderInfos2Control(this.lvWaitingPayOrders,
                        list.FindAll(info => info.orderStatus == OrderStatus.WAITING_PAY));
                    OrderInfos2Control(this.lvPaidOrders, null);
                    OrderInfos2Control(this.lvFinishOrders, list.FindAll(info => info.orderStatus == OrderStatus.FINISH));
                    Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryOrders.Enabled = true;
                    this.btnQueryOrders.Text = "查询我的订单";
                }
            });
        }

        /// <summary>
        /// “内置浏览订单”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewOrderInfoInWeb_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            PapdHelper.SetIECookie(PapdHelper.MyOrdersUrl, GlobalContext.CurrentCookieString);
            FrmWeb frmWeb = new FrmWeb(PapdHelper.MyOrdersUrl);
            frmWeb.Show();
        }

        /// <summary>
        /// 将订单信息填充到控件上
        /// </summary>
        /// <param name="list"></param>
        private void OrderInfos2Control(ListView lvOrders, List<OrderInfo> list)
        {
            if (list == null)
                return;

            Color[] colors = new Color[2] {Color.LightSkyBlue, Color.PaleVioletRed};
            DateTime lastDate = DateTime.MinValue;
            int lastColorIndex = 0;
            for (int i = 0; i < list.Count; i++)
            {
                var orderInfo = list[i];
                foreach (var orderItem in orderInfo.items)
                {
                    var createTime = PapdHelper.ConvertFromUnixTime(orderInfo.createTime);
                    var item = new ListViewItem(new string[]{
                        (i+1).ToString(),
                        createTime.ToString("yyyy/MM/dd HH:mm:ss 周ddd"),
                        orderItem.itemTitle,
                        (orderItem.actualPrice/100).ToString(),
                        orderInfo.GetOrderStatus()
                    });
                    item.Tag = orderInfo;

                    #region 将在同一周内的日期标记为相同得颜色
                    if (i == 0)
                    {
                        //第一条记录
                        lastColorIndex = 0;
                    }
                    else
                    {
                        if (!IsInSameWeek(createTime, lastDate))
                        {
                            //如果跟上一个日期不在同一周，则更换背景色
                            lastColorIndex = lastColorIndex == 0 ? 1 : 0;
                        }
                    }
                    lastDate = createTime;
                    item.SubItems[0].BackColor = colors[lastColorIndex]; 
                    #endregion

                    lvOrders.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 判断两天是否在同一周
        /// </summary>
        /// <param name="d1">日期1</param>
        /// <param name="d2">日期2</param>
        /// <returns></returns>
        public static bool IsInSameWeek(DateTime d1, DateTime d2)
        {
            DateTime bigger = d1 >= d2 ? d1 : d2;
            DateTime smaller = d1 < d2 ? d1 : d2;

            //周日改为7
            int n = bigger.DayOfWeek == 0 ? 7 : (int)bigger.DayOfWeek;
            //上周日
            DateTime lastSunday = bigger.AddDays(-n);
            lastSunday = new DateTime(lastSunday.Year, lastSunday.Month, lastSunday.Day, 23, 59, 59);
            if (smaller > lastSunday)
                return true;

            return false;

            //int a = bigger.DayOfWeek == 0 ? 7 : (int) bigger.DayOfWeek;
            //int b = smaller.DayOfWeek==0?7:(int)smaller.DayOfWeek;
            //int c = (bigger - smaller).Days;

            //return a - b == c;
        }

        /// <summary>
        /// 在所有订单和待付款订单中点击右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvAllOrders_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count != 1)
                return;
            ListViewItem selectedItem = lv.SelectedItems[0];
            OrderInfo orderInfo = selectedItem.Tag as OrderInfo;
            if (orderInfo.orderStatus == OrderStatus.WAITING_PAY)
            {
                var cms = new ContextMenuStrip();
                cms.Items.Add("取消订单", null, (o, args) =>
                {
                    try
                    {
                        if (MessageBox.Show("确定要取消订单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                            DialogResult.Yes)
                            return;
                        PH.CloseOrder(GlobalContext.CurrentCookieString,Convert.ToInt64(orderInfo.tradeId));
                        MessageBox.Show("订单取消成功！");
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowInfo("订单取消失败，" + ex.Message);
                    }
                    btnQueryOrders_Click(null, null);
                });
                cms.Items.Add("复制支付地址", null, (o, args) =>
                {
                    try
                    {
                        string payUrl = PH.GetPayUrl(GlobalContext.CurrentCookieString, Convert.ToInt64(orderInfo.tradeId));
                        Clipboard.SetText(payUrl);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowInfo("复制支付地址失败，" + ex.Message);
                    }
                    
                });
                cms.Items.Add("继续支付(IE)", null, (o, args) =>
                {
                    try
                    {
                        string payUrl = PH.GetPayUrl(GlobalContext.CurrentCookieString, Convert.ToInt64(orderInfo.tradeId));
                        PapdHelper.SetIECookie(payUrl, GlobalContext.CurrentCookieString);
                        Process.Start("iexplore.exe",payUrl);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowInfo("继续支付(IE)失败，" + ex.Message);
                    }

                });
                cms.Items.Add("继续支付(内置)", null, (o, args) =>
                {
                    try
                    {
                        string payUrl = PH.GetPayUrl(GlobalContext.CurrentCookieString, Convert.ToInt64(orderInfo.tradeId));
                        PapdHelper.SetIECookie(payUrl, GlobalContext.CurrentCookieString);
                        new FrmWeb(payUrl).Show();
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowInfo("继续支付(内置)失败，" + ex.Message);
                    }

                });
                cms.Show(lv,e.Location);
            }
        }

        /// <summary>
        /// 在订单列表双击显示订单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvAllOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListView listView = sender as ListView;
                if (listView.SelectedItems.Count < 1)
                    return;

                OrderInfo orderInfo = listView.SelectedItems[0].Tag as OrderInfo;
                var orderDetailInfo = PH.QueryOrderDetailInfo(GlobalContext.CurrentCookieString, orderInfo.tradeId);
                var frm = new FrmOrderDetail(orderDetailInfo);
                frm.Show();
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfo("获取订单详情失败，" + ex.Message);
            }
        }

        #endregion

        #region 夺金明细

        /// <summary>
        /// “查询夺金明细”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryRewardRecord_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageRewardRecord);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryRewardRecord.Enabled = false;
                this.btnQueryRewardRecord.Text = "查询中";
                try
                {
                    Output("正在查询夺金明细");
                    var list = PH.GetRewardRecordInfos(GlobalContext.CurrentCookieString);
                    list = list.OrderByDescending(info => info.rewardDate).ToList();
                    RewardRecordList2Control(list);
                    if(list.Count<1)
                        Output("没有夺金明细！");
                    else
                        Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryRewardRecord.Enabled = true;
                    this.btnQueryRewardRecord.Text = "查询夺金明细";
                }
            });
        }

        /// <summary>
        /// 将夺金明细填充到控件上
        /// </summary>
        /// <param name="list"></param>
        private void RewardRecordList2Control(List<RewardRecordInfo> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var info = list[i];
                var item = new ListViewItem((i + 1).ToString());
                var localTime = PapdHelper.ConvertFromUnixTime(info.rewardDate);
                item.SubItems.Add(localTime.ToString("yyyy/MM/dd"));
                item.SubItems.Add(info.ToString());
                item.SubItems.Add(info.money + "元");
                item.SubItems.Add(info.GetRewardStatusDescription());
                this.lvRewardRecord.Items.Add(item);

                if (info.rewardStatus == RewardStatus.RECEIVED)
                {
                    HighlightListViewRow(this.lvRewardRecord, i);
                }
                else if (info.rewardStatus == RewardStatus.CANCEL)
                {
                    //item.UseItemStyleForSubItems = false;
                    //item.SubItems[3].BackColor = Color.Red;
                    HighlightListViewRow(this.lvRewardRecord, i);
                }
            }
        }

        #endregion

        #region 收支明细

        /// <summary>
        /// “查询收支明细”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryBatchOrderRecord_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageInOutRecord);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryBatchOrderRecord.Enabled = false;
                this.btnQueryBatchOrderRecord.Text = "查询中";
                try
                {
                    Output("正在查询收支明细");
                    var list = PH.QueryBatchOrderRecord(GlobalContext.CurrentCookieString);
                    list = list.OrderByDescending(info => info.timeLine).ToList();
                    RewardRecordList2Control2(list);
                    if (list.Count < 1)
                        Output("没有收支明细！");
                    else
                        Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryBatchOrderRecord.Enabled = true;
                    this.btnQueryBatchOrderRecord.Text = "查询收支明细";
                }
            });
        }

        /// <summary>
        /// 将收支明细填充到控件上
        /// </summary>
        /// <param name="list"></param>
        private void RewardRecordList2Control2(List<RewardRecordInfo> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var info = list[i];
                var item = new ListViewItem((i + 1).ToString());
                var localTime = PapdHelper.ConvertFromUnixTime(info.timeLine);
                item.SubItems.Add(localTime.ToString("yyyy/MM/dd"));
                item.SubItems.Add(info.ToString());
                string str = (info.type == "10" ? "+" : "-") + info.money + "金";
                item.SubItems.Add(KeepRightAlign(str, 10));

                this.lvBatchOrderRecord.Items.Add(item);
            }
        }

        private string KeepRightAlign(string str, int length)
        {
            string result = string.Empty;
            for (int i = 0; i < length - str.Length; i++)
            {
                result += " ";
            }

            return result + str;
        }
        #endregion

        #region 收货地址

        /// <summary>
        /// “查询收货地址”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryAddresses_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            ClearControl(tabPageAddress);
            Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(p =>
            {
                this.btnQueryAddresses.Enabled = false;
                this.btnQueryAddresses.Text = "查询中";
                try
                {
                    Output("正在查询收货地址...");
                    var list = PH.GetAllAddress(GlobalContext.CurrentCookieString);
                    Addresses2Control(list);
                    if (list.Count < 1)
                        Output("没有收货地址！");
                    else
                        Output("查询成功！");
                }
                catch (Exception ex)
                {
                    Output("查询失败，" + ex.Message);
                }
                finally
                {
                    this.btnQueryAddresses.Enabled = true;
                    this.btnQueryAddresses.Text = "查询收货地址";
                }
            });
        }

        /// <summary>
        /// 将收货信息填充到控件上
        /// </summary>
        /// <param name="list"></param>
        private void Addresses2Control(List<AddressInfo> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var address = list[i];

                var item = new ListViewItem(new string[]{
                    (i+1).ToString(),
                    address.recipientName,
                    address.recipientPhone,
                    address.province,
                    address.city,
                    address.streetAddress,
                    address.isDefault ? "是":"否"
                });
                item.Tag = address;
                this.lvAddresses.Items.Add(item);

                if (address.isDefault)
                {
                    HighlightListViewRow(this.lvAddresses, i, Color.PaleVioletRed);
                }
            }
        }

        /// <summary>
        /// 在收货地址ListView上鼠标弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvAddresses_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cms = new ContextMenuStrip();

                //添加
                cms.Items.Add("添加收货地址", null, (o, args) =>
                {
                    var frm = new FrmEditAddress();
                    if (frm.ShowDialog() == DialogResult.Cancel)
                        return;
                    btnQueryAddresses_Click(null, null);
                });
                if (this.lvAddresses.SelectedItems.Count == 1)
                {
                    //编辑
                    var selectedItem = this.lvAddresses.SelectedItems[0];
                    var addressInfo = selectedItem.Tag as AddressInfo;

                    cms.Items.Add("编辑收货地址", null, (o, args) =>
                    {
                        var frm = new FrmEditAddress(addressInfo);
                        if (frm.ShowDialog() == DialogResult.Cancel)
                            return;

                        btnQueryAddresses_Click(null, null);
                    });

                    cms.Items.Add("删除收货地址", null, (o, args) =>
                    {
                        var dr = MessageBox.Show("确定要删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                PH.DeleteAddress(GlobalContext.CurrentCookieString, addressInfo.id);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            btnQueryAddresses_Click(null, null);
                        }
                    });
                }

                cms.Show(this.lvAddresses,e.Location);
            }
        }

        #endregion

        #endregion

        #region 显示或隐藏设置区域按钮
        private void button1_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn.Text.Contains("↑"))
            {
                this.panelBottom.Visible = true;
                btn.Text = "↓隐藏设置区域↓";
            }
            else
            {
                this.panelBottom.Visible = false;
                btn.Text = "↑显示设置区域↑";
            }
        }
        #endregion

        #region 设置TabControl

        #region 抢购设置

        /// <summary>
        /// 在“抢购列表”上点击右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxMonitor_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (this.isRunning)//正在自动抢购商品时，不允许移除
                return;
            ContextMenuStrip cms = new ContextMenuStrip();
            if (this.listBoxMonitor.SelectedItems.Count>0)
            {
                cms.Items.Add("移除", null, toolStripMenuItemRemoveMonitorItem_Click); 
            }
            cms.Show(this.listBoxMonitor,e.Location);
        }

        /// <summary>
        /// 从抢购列表中“移除”菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemRemoveMonitorItem_Click(object sender, EventArgs e)
        {
            for (int i = this.listBoxMonitor.SelectedItems.Count - 1; i >= 0; i--)
            {
                var item = this.listBoxMonitor.SelectedItems[i];
                this.listBoxMonitor.Items.Remove(item);
            }
        } 

        /// <summary>
        /// 修改充值手机号按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeRechargePhone_Click(object sender, EventArgs e)
        {
            var frm = new FrmInputPhone(GlobalContext.HistoryRechargeMobile);
            frm.PhoneNumber = this.txtRechargePhone.Text;
            if (frm.ShowDialog() != DialogResult.OK)
                return;
            GlobalContext.CurrentRechargePhone = frm.PhoneNumber;
            this.txtRechargePhone.Text = frm.PhoneNumber.ToString();
        }

        /// <summary>
        /// “修改收货地址”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeCurrentAddress_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectAddress(GlobalContext.CurrentCookieString);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var addressInfo = frm.CurrentAddressInfo;
                this.txtCurrentAddress.Text = addressInfo == null ? null : addressInfo.ToString();
                this.txtCurrentAddress.Tag = addressInfo;
                GlobalContext.CurrentAddressInfo = addressInfo;
            }
        }

        #endregion

        #region 气泡提示

        /// <summary>
        /// 在系统托盘显示气泡信息
        /// </summary>
        /// <param name="tipText">提示信息</param>
        private void ShowBalloonTip(string tipText)
        {
            this.notifyIcon1.ShowBalloonTip(3000, "提示", tipText, ToolTipIcon.Info);
        }

        #endregion

        #region 信息输出

        /// <summary>
        /// 已经输出的行数
        /// </summary>
        private int outPutRow = 0;

        /// <summary>
        /// 输出信息
        /// </summary>
        private void Output()
        {
            Output(string.Empty);
        }

        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="info"></param>
        public void Output(string info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(Output), info);
            }
            else
            {
                if (++outPutRow > 10000)
                    this.textBoxOutput.Clear();

                StringBuilder builder = new StringBuilder();
                builder.Append(DateTime.Now.ToString("HH:mm:ss:f"));
                builder.AppendLine(" " + info.TrimStart());

                this.textBoxOutput.Text = builder + this.textBoxOutput.Text;
            }
        }

        /// <summary>
        /// 输出信息框的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                this.textBoxOutput.SelectAll();
            }
        }

        private void textBoxOutput_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            ContextMenuStrip cms = new ContextMenuStrip();
            if (this.textBoxOutput.ContextMenuStrip == null)
            {
                this.textBoxOutput.ContextMenuStrip = cms; // 屏蔽textbox默认右键菜单
            }
            cms.Items.Add("全选(&A)", null, (o, args) => this.textBoxOutput.SelectAll());
            cms.Items.Add("复制(&C)", null, (o, args) =>
            {
                try
                {
                    Clipboard.SetText(this.textBoxOutput.SelectedText);
                }
                catch
                {
                }
            });
            cms.Items.Add("清空(&E)", null, (o, args) => this.textBoxOutput.Clear());
            cms.Show(this.textBoxOutput, e.Location);
        }

        #endregion

        #region 声音提醒

        /// <summary>
        /// 声音和视频播放API函数
        /// </summary>
        /// <param name="lpstrCommand"></param>
        /// <param name="lpstrReturnString"></param>
        /// <param name="uReturnLength"></param>
        /// <param name="hwndCallback"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
            string lpstrCommand,
            string lpstrReturnString,
            int uReturnLength,
            int hwndCallback
            );

        /// <summary>
        /// “启用”checkbox状态发生变化时，调整控件的可用性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbEnableAudio_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            foreach (Control control in this.groupBoxAudio.Controls)
            {
                if(control is Label)
                    continue;
                control.Enabled = chk.Checked;
            }
        }

        /// <summary>
        /// “试听”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestPlay_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag == null)
            {
                PlaySelectedAudio();
                btn.Text = "停止";
                btn.Tag = 1;
            }
            else
            {
                CloseAudio();
                btn.Text = "试听";
                btn.Tag = null;
            }
        }

        /// <summary>
        /// 切换歌曲时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAudioList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnTestPlay.Text = "试听";
            this.btnTestPlay.Tag = null;
            CloseAudio();
        }

        /// <summary>
        /// 播放已经选择的声音文件
        /// </summary>
        private void PlaySelectedAudio()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(PlaySelectedAudio));
                return;
            }
            var fileName = this.cmbAudioList.Text;
            var filePath = Path.Combine(GlobalContext.AudioPath, fileName);
            this.btnTestPlay.Text = "停止";
            this.btnTestPlay.Tag = 1;

            try
            {
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                //player.SoundLocation = filePath;
                //player.Load();
                //player.Play();

                //Audio audio = new Audio(fileName);
                //audio.Play();

                CloseAudio();//关闭

                //打开  file 这个路径的歌曲 " ，type mpegvideo是文件类型  ，    alias 是将文件别名为media 
                mciSendString("open \"" + filePath + "\" type mpegvideo alias media", null, 0, 0);
                mciSendString("play media notify", null, 0, this.Handle.ToInt32());//播放
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 关闭音乐
        /// </summary>
        private void CloseAudio()
        {
            try
            {
                mciSendString("close media", null, 0, 0);
            }
            catch
            {
            }
        }

        #endregion

        #region QQ提醒

        #region 获取QQ聊天窗口相关API
        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, int lParam);
        public delegate bool EnumWindowsProc(int hwnd, int lParam);
        [DllImport("user32")]
        public static extern int GetClassNameA(int hwnd, StringBuilder lptrString, int nMaxCount);
        [DllImport("user32")]
        public static extern int GetWindowText(int hwnd, StringBuilder lptrString, int nMaxCount);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// 激活并还原显示窗口
        /// </summary>
        private const int SW_RESTORE = 9;

        /// <summary>
        /// 枚举所有窗口相关委托
        /// </summary>
        /// <param name="hwnd">窗口ID</param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private bool LpEnumFunc(int hwnd, int lParam)
        {
            StringBuilder className = new StringBuilder(254);
            //获取窗口类名
            GetClassNameA(hwnd, className, className.Capacity);
            if (className.ToString().Contains("TXGuiFoundation"))
            {
                //如果为QQ窗口
                StringBuilder title = new StringBuilder(254);
                //获取窗口名称
                GetWindowText(hwnd, title, title.Capacity);
                if (title.ToString().Trim().Length < 1)
                    return true;
                //将获取的窗口名称添加到下拉框中
                this.cmboxQQWindow.Items.Add(new WindowInfo() { Hwnd = (IntPtr)hwnd, Name = title.ToString() });
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 当前选择的QQ窗口
        /// </summary>
        private WindowInfo SelectedQQWindow = null;

        /// <summary>
        /// 当前选择的QQ窗口发送消息模式
        /// </summary>
        private QQSendKeyMode _selectedQqSendKeyMode = QQSendKeyMode.CtrlEnter;

        /// <summary>
        /// 消息发送模式
        /// </summary>
        enum QQSendKeyMode
        {
            Enter,
            CtrlEnter
        }

        /// <summary>
        /// “获取QQ聊天窗口”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetQQHwnd_Click(object sender, EventArgs e)
        {
            this.cmboxQQWindow.Items.Clear();

            //枚举所有窗口
            EnumWindows(LpEnumFunc, 0);
        }

        /// <summary>
        /// “启用”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbEnableQQMsg_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            foreach (Control control in this.groupBoxQQ.Controls)
            {
                if (control is Label)
                    continue;
                control.Enabled = chk.Checked;
            }
        }

        /// <summary>
        /// 选择QQ窗口后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboxQQWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedQQWindow = this.cmboxQQWindow.SelectedItem as WindowInfo;
        }

        /// <summary>
        /// 选择Enter键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoBtnEnter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoBtnEnter.Checked)
                this._selectedQqSendKeyMode = QQSendKeyMode.Enter;
        }

        /// <summary>
        /// 选择Ctrl+Enter键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoBtnCtrlEnter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoBtnCtrlEnter.Checked)
                this._selectedQqSendKeyMode = QQSendKeyMode.CtrlEnter;
        }

        /// <summary>
        /// 测试向QQ窗体中发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestQQSend_Click(object sender, EventArgs e)
        {
            SendQQMessage("平安好医生助手测试！");
        }

        /// <summary>
        /// 发送QQ消息
        /// </summary>
        /// <param name="message"></param>
        private void SendQQMessage(string message)
        {
            if (this.SelectedQQWindow != null)
            {
                ShowWindow(this.SelectedQQWindow.Hwnd, SW_RESTORE);
                SetForegroundWindow(this.SelectedQQWindow.Hwnd);
                SendKeys.SendWait(message);
                if (this._selectedQqSendKeyMode == QQSendKeyMode.Enter)
                {
                    SendKeys.SendWait("{Enter}");
                }
                else
                {
                    /*
                     *  SHIFT    +     
                        CTRL    ^     
                        ALT    %
                     */
                    SendKeys.SendWait("^{Enter}");
                }
            }
        }
        #endregion

        #region 系统设置

        private void cmbBoxGrabMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_grabByDetailProductInfo = this.cmbBoxGrabMode.SelectedIndex == 1;
        }

        /// <summary>
        /// “修改间隔”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkboxEnableCustomLoopInternal_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = this.chkboxEnableLoopInternal.Checked;
            this.enabledCustomLoopInternal = enabled;
            this.numericUpDownLoopInternal.Enabled = enabled;
        }

        /// <summary>
        /// 自定义修改时间间隔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownCustomLoopInternal_ValueChanged(object sender, EventArgs e)
        {
            var numericUD = sender as NumericUpDown;
            this.customLoopInternal = numericUD.Value;
        }

        /// <summary>
        /// “推荐定时抢购时间”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecommandDate_Click(object sender, EventArgs e)
        {
            var recommandDates = GetRecommandTimes();

            ContextMenuStrip cms = new ContextMenuStrip();
            for (int i = 0; i < recommandDates.Count; i++)
            {
                if (recommandDates[i] > DateTime.Now)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(recommandDates[i].ToString());
                    item.Tag = recommandDates[i];
                    item.Click += (o, args) => { this.dateTimePickerStartTime.Value = (DateTime)item.Tag; };
                    cms.Items.Add(item);
                }
            }

            Point pointScreen = this.btnRecommandDate.Parent.PointToScreen(this.btnRecommandDate.Location);
            pointScreen.Y -= cms.Height + this.btnRecommandDate.Height;

            cms.Show(pointScreen);
        }

        private List<DateTime> GetRecommandTimes()
        {
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(1);
            List<DateTime> recommandTimes = new List<DateTime>()
            {
                new DateTime(today.Year,today.Month,today.Day, 9, 59, 0),
                new DateTime(today.Year,today.Month,today.Day, 12, 59, 0),
                new DateTime(today.Year,today.Month,today.Day, 14, 59, 0),
                new DateTime(today.Year,today.Month,today.Day, 19, 59, 0),
                new DateTime(tomorrow.Year,tomorrow.Month,tomorrow.Day, 9, 59, 0),
                new DateTime(tomorrow.Year,tomorrow.Month,tomorrow.Day, 14, 59, 0),
            };

            return recommandTimes;
        }

        /// <summary>
        /// 只显示可健康金全额兑换的商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbIsOnlyShowHealthGoldProduct_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = this.chkboxIsOnlyShowHealthGoldProduct.Checked;
            this.isOnlyShowHealthGoldProduct = enabled;
        }

        /// <summary>
        /// 定时启动检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkboxEnableTimerStart_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbox = sender as CheckBox;

            if (chkbox.Tag != null)
            {
                //Tag非空时，直接返回
                chkbox.Tag = null;
                return;
            }

            if (chkbox.Checked)
            {
                #region 启动定时任务

                if (this.isRunning)
                {
                    MsgBox.ShowInfo("正在抢购中，无法启动定时抢购任务！");
                    chkbox.Tag = "ignore";
                    chkbox.Checked = false;
                    return;
                }
                if (DateTime.Now >= this.dateTimePickerStartTime.Value)
                {
                    MsgBox.ShowInfo("定时抢购时间，必须大于当前时间！");
                    chkbox.Tag = "ignore";
                    chkbox.Checked = false;
                    return;
                }
                if (!CheckLoginState())
                {
                    chkbox.Tag = "ignore";
                    chkbox.Checked = false;
                    return;
                }
                if (this.listBoxMonitor.Items.Count < 1)
                {
                    MsgBox.ShowInfo("请先添加需要抢购的商品！");
                    chkbox.Tag = "ignore";
                    chkbox.Checked = false;
                    return;
                }

                ChangeStateWhenTimerAction(true);

                //启动检测线程
                Thread thread = new Thread(() =>
                {
                    while (this.enableTimerStart)
                    {
                        this.Invoke(new Action(() =>
                        {
                            //if (IsBiggerDateInHHMMSS(DateTime.Now, this.dateTimePickerStartTime.Value, true))
                            if(DateTime.Now>=this.dateTimePickerStartTime.Value)
                            {
                                Output("定时抢购已激活，开始抢购！");
                                ApiUtil.MessageBeep(ApiUtil.BeepType.MB_ICONASTERISK);
                                ChangeStateWhenTimerAction(false);
                                this.toolStripButtonMonitor.PerformClick();
                                return;
                            }
                        }));
                        Thread.Sleep(1000);
                    }

                    ChangeStateWhenTimerAction(false);
                });
                thread.IsBackground = true;
                thread.Start();
                Output("即将在 " + this.dateTimePickerStartTime.Text + " 启动抢购！");
                MsgBox.ShowInfo("即将在 " + this.dateTimePickerStartTime.Text + " 启动抢购！");

                #endregion
            }
            else
            {
                //取消定时任务
                ChangeStateWhenTimerAction(false);
                Output("定时抢购已取消！");
                MsgBox.ShowInfo("定时抢购已取消！");
            }
        }

        /// <summary>
        /// 进行定时任务操作时，相应控件的状态
        /// </summary>
        /// <param name="isTimerStart">是否已启动定时任务</param>
        private void ChangeStateWhenTimerAction(bool isTimerStart)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(ChangeStateWhenTimerAction), isTimerStart);
                return;
            }

            this.enableTimerStart = isTimerStart;
            if (this.chkboxEnableTimerStart.Checked != isTimerStart)
            {
                //注：如果checkbox的checked值没有发生变化是否不会调用CheckedChanged事件的
                this.chkboxEnableTimerStart.Tag = "ignore";
                this.chkboxEnableTimerStart.Checked = isTimerStart;
            }

            this.toolStripButtonLogin.Enabled = !isTimerStart;
            this.toolStripButtonMonitor.Enabled = !isTimerStart;
            this.listBoxMonitor.Enabled = !isTimerStart;
        }

        /// <summary>
        /// 根据时分秒判断前者是否大于（或者大于等于）后者
        /// </summary>
        /// <param name="former">前者的时间</param>
        /// <param name="latter">后者的时间</param>
        /// <param name="isEqualBigger">前者和后者相等时，是否认为前者大于后者</param>
        /// <returns></returns>
        private bool IsBiggerDateInHHMMSS(DateTime former, DateTime latter, bool isEqualBigger)
        {
            if (former.Hour > latter.Hour)
            {
                return true;
            }
            else if (former.Hour < latter.Hour)
            {
                return false;
            }
            else//时相等
            {
                if (former.Minute > latter.Minute)
                {
                    return true;
                }
                else if (former.Minute < latter.Minute)
                {
                    return false;
                }
                else//时、分相等
                {
                    if (former.Second > latter.Second)
                    {
                        return true;
                    }
                    else if (former.Second < latter.Second)
                    {
                        return false;
                    }
                    else//时、分、秒相等
                    {
                        return isEqualBigger;
                    }
                }
            }
        }

        /// <summary>
        /// 商品查询接口模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkboxlstSearchInterface_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox chkboxlist = this.chkboxlstSearchInterface;
            if (chkboxlist.Items.Count < 1)
                return;
            // 记录每项的checked状态
            bool[] checks = new bool[chkboxlist.Items.Count];
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i] = chkboxlist.GetItemChecked(i);
            }
            // 修正当前item的checked状态
            checks[e.Index] = e.NewValue == CheckState.Checked;
            // 修改模式变量
            for (int i = 0; i < checks.Length; i++)
            {
                if (checks[i])
                {
                    SearchProductInterfaceMode = SearchProductInterfaceMode | (1 << i);
                }
                else
                {
                    SearchProductInterfaceMode = SearchProductInterfaceMode & (~(1 << i));
                }
            }
        }

        #endregion

        #endregion

        #region 窗体最小化处理
        /// <summary>
        /// 窗体尺寸发生改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            //窗体最小化时，会调用SizeChanged事件
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
            }
        } 
        #endregion

        #region 窗体关闭中事件
        /// <summary>
        /// 窗体关闭中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("亲，确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                DialogResult.OK)
            {
                return;
            }
            e.Cancel = true;
        } 
        #endregion

        #region “走步数据管理”按钮点击事件
        /// <summary>
        /// “走步数据管理”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonStepManager_Click(object sender, EventArgs e)
        {
            new FrmStepManager().ShowDialog();
        } 
        #endregion

        #region 显示验证码窗体
        /// <summary>
        /// 是否自动识别验证码
        /// </summary>
        private bool isAutoVerifyCode = true;
        /// <summary>
        /// 显示验证码
        /// </summary>
        /// <param name="productInfo"></param>
        /// <returns></returns>
        public bool ShowVerifyCode(IProductInfo productInfo)
        {
            // 获取商品详情
            var detail = PH.GetProductDetail(productInfo.id, productInfo.storeId);

            var frm = new FrmImageVerifyCode();
            // 刷新验证码
            frm.RefreshImage += (o, args) =>
            {
                try
                {
                    args.Img = PH.GetVerifyCode(MyCookie);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("获取验证码失败：" + ex.Message);
                }
            };
            // 提交验证码
            frm.IsAutoVerifyCode = this.isAutoVerifyCode;
            frm.ConfirmVerifyCode = new Func<bool>(() =>
            {
                if (!isAutoVerifyCode)
                {
                    try
                    {
                        var checkOrderResult = PH.CheckOrderRight(productInfo.id.ToString(), MyCookie);
                        var checkVerifyCodeResult = PH.CheckVerifyCode(MyCookie, detail.items[0].id.ToString(),
                            productInfo.storeId.ToString(), frm.VerifyCode);

                        return checkOrderResult && checkVerifyCodeResult;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                else
                {
                    var img = frm.GetPictureBoxImge();
                    var bytes = ImageHelper.ImageToBytes(img);
                    var vcode = AntiCode.VerifyCode(bytes);
                    vcode = vcode.Trim();
                    GlobalContext.Output("预计验证码为：" + vcode);
                    if (vcode.Length == 2)
                    {
                        if (char.IsNumber(vcode[0]) && char.IsNumber(vcode[1]))
                        {
                            // + x - /
                            int n1 = Convert.ToInt32(vcode[0].ToString());
                            int n2 = Convert.ToInt32(vcode[1].ToString());
                            List<string> result = new List<string>();
                            result.Add((n1+n2)+"");
                            result.Add((n1*n2)+"");
                            result.Add((n1-n2)+"");
                            if (n2!=0&&n1%n2==0)
                            {
                                result.Add((n1 / n2) + ""); 
                            }
                            for (int i = 0; i < result.Count; i++)
                            {
                                GlobalContext.Output(">>>正在验证：" + result[i]);
                                frm.SetVerifyCode(result[i]);
                                try
                                {
                                    var checkOrderResult = PH.CheckOrderRight(productInfo.id.ToString(), MyCookie);
                                    var checkVerifyCodeResult = PH.CheckVerifyCode(MyCookie, detail.items[0].id.ToString(),
                                        productInfo.storeId.ToString(), result[i]);

                                    GlobalContext.Output("识别成功！");
                                    return true;

                                    //return checkOrderResult && checkVerifyCodeResult;
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    //return false;
                                    //continue;
                                }
                                Thread.Sleep(1000);
                            }
                        }
                    }
                    GlobalContext.Output("识别失败！");
                    return false;
                }
            });
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 检测是否可以下单

        /// <summary>
        /// 检测是否可以下单
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private bool IsTakeOrderOk(IProductInfo product)
        {
            try
            {
                Output("正在检测是否可以下单...");
                var result = GlobalContext.PH.GetTotalFee(product.id, product.storeId, GlobalContext.CurrentCookieString);
                Output("可以下单!");
                return true;
            }
            catch (Exception ex)
            {
                Output("不可以下单：" + ex.Message);
                return false;
            }
        }
        #endregion

        #region 下单前是否检测是否需要输入验证码
        // 下单前是否检测是否需要输入验证码
        private bool checkVerifyCodeOrdering = true;
        private void checkBoxCheckVerifyCodeByOrdering_CheckedChanged(object sender, EventArgs e)
        {
            checkVerifyCodeOrdering = this.checkBoxCheckVerifyCodeByOrdering.Checked;
        }
        #endregion

        #region 自动识别验证码
        private void checkBoxAutoVerifyCode_CheckedChanged(object sender, EventArgs e)
        {
            isAutoVerifyCode = this.checkBoxAutoVerifyCode.Checked;
        }
        #endregion

        #region 代理设置
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var frm = new FrmProxy();
            frm.ShowDialog();
            frm.Dispose();
        } 
        #endregion

        
    }
}
