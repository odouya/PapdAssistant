using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PapdLib;
using PapdLib.Info;
using PapdLib.Util;

namespace PapdMonitor
{
    public partial class FrmBatchHandle : FrmBase
    {
        public FrmBatchHandle()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                SetControlEnabled(this.toolStrip1, false);
                try
                {
                    var config = ConfigStorage.GetInstance().GetConfigInfo();
                    ClearListView(this.listView1);
                    for (int i = 0; i < config.HistoryCookies.Count; i++)
                    {
                        var info = config.HistoryCookies[i];
                        AddListViewmItem(this.listView1, new object[]
                        {
                            (i + 1).ToString(),
                            info.Name,
                            info.Id == null ? string.Empty : info.Id.ToString(),
                            info.Cookie,
                            CertificateUtil.GetCertSubjectName(info.CertPath)
                        });
                        SetListViewItemTag(this.listView1, i, info);
                        SetListViewItemChecked(this.listView1, i, true);
                    }
                }
                catch (Exception ex)
                {
                    
                }
                SetControlEnabled(this.toolStrip1, true);
            });
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.listView1.CheckedItems.Count < 1)
            {
                MsgBox.ShowInfo("请勾选账号！");
                return;
            }

            List<int> checkedRows = new List<int>();
            for (int i = 0; i < this.listView1.CheckedItems.Count; i++)
            {
                checkedRows.Add(this.listView1.CheckedItems[i].Index);
            }

            ThreadPool.QueueUserWorkItem(o =>
            {
                SetControlEnabled(this.toolStrip1, false);
                for (int i = 0; i < checkedRows.Count; i++)
                {
                    int index = checkedRows[i];
                    string cookie = GetListViewItemValue(this.listView1, index, 3);

                    #region 查询余额
                    try
                    {
                        var goldInfo = PH.GetGoldInfo(cookie);
                        SetListViewItemValue(this.listView1, index, 5, goldInfo.balance + "金");
                    }
                    catch (Exception ex)
                    {
                        SetListViewItemValue(this.listView1, index, 5, "余额查询失败");
                    }
                    #endregion

                    #region 查询下次可抢购时间

                    try
                    {
                        var orders = PH.QueryOrders(cookie, OrderType.ALL, 1);
                        if (orders.Count > 0)
                        {
                            DateTime lastOrderCreateTime = PapdHelper.ConvertFromUnixTime(orders[0].createTime);
                            DateTime nextOrderCreateTime = lastOrderCreateTime.AddDays(GlobalContext.CurrentConfigInfo.CreateOrderTimespan);
                            var leftDays = Math.Round((nextOrderCreateTime - DateTime.Now).TotalDays, 1);
                            var msg = string.Format("{0},下次抢购时间：{1}",
                                leftDays > 0 ? ("还有" + leftDays + "天") : "可抢",
                                nextOrderCreateTime.ToString("yyyy/MM/dd HH:mm:ss dddd"));
                            SetListViewItemValue(this.listView1, index, 6, msg);
                        }
                        else
                        {
                            SetListViewItemValue(this.listView1, index, 6, "可抢");
                        }
                    }
                    catch (Exception ex)
                    {
                        SetListViewItemValue(this.listView1, index, 6, "查询下次抢购时间失败");
                    }
                    #endregion
                }
                SetControlEnabled(this.toolStrip1, true);
            });
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.listView1.CheckedItems.Count < 1)
            {
                MsgBox.ShowInfo("请勾选账号！");
                return;
            }

            List<int> checkedRows = new List<int>();
            for (int i = 0; i < this.listView1.CheckedItems.Count; i++)
            {
                checkedRows.Add(this.listView1.CheckedItems[i].Index);
            }

            ThreadPool.QueueUserWorkItem(o =>
            {
                var configInfo = ConfigStorage.GetInstance().GetConfigInfo();
                SetControlEnabled(this.toolStrip1, false);
                for (int i = 0; i < checkedRows.Count; i++)
                {
                    int index = checkedRows[i];
                    CookieInfo cookieInfo = GetListViewItemTag<CookieInfo>(this.listView1, index);
                    string cookie = cookieInfo.Cookie;
                    string id = cookieInfo.Id.ToString();
                    string cert = cookieInfo.CertPath;

                    bool fetchYestodayReward = true;
                    if (configInfo.IsAutoFetchYesterdayBonus)
                    {
                        #region 领取昨日奖励
                        SetListViewItemValue(this.listView1, index, 7, "正在领取奖励");
                        try
                        {
                            var rewardInfo = PH.QueryRewardInfo(cookie, 3000);
                            if (!rewardInfo.IsPreMoneyFetch())
                            {
                                var fetchRewardResult = PH.FetchReward(cookie, rewardInfo.preRewardId);
                                SetListViewItemValue(this.listView1, index, 7, "昨日奖励领取成功!");
                            }
                            else
                            {
                                SetListViewItemValue(this.listView1, index, 7, "昨日奖励已领取。");
                            }
                        }
                        catch (Exception ex)
                        {
                            SetListViewItemValue(this.listView1, index, 7, "昨日奖励领取失败！");
                            fetchYestodayReward = false;
                        }
                        #endregion 
                    }

                    Thread.Sleep(1000);

                    int grabGoldSuccess = 0;
                    if (configInfo.IsAutoGrabGold)
                    {
                        #region 抢金
                        SetListViewItemValue(this.listView1, index, 7, "正在抢金");
                        try
                        {
                            var grabGoldInfo = PH.GetGrabGoldInfo(cookie, 1);
                            for (int j = 0; j < grabGoldInfo.userRankingList.Length; j++)
                            {
                                var user = grabGoldInfo.userRankingList[j];
                                if (!user.IsGrabGoldAvailable())
                                {
                                    continue;
                                }
                                try
                                {
                                    PH.GrabGoldFromFollower(cookie, user.userInfo.userId);
                                    grabGoldSuccess++;
                                }
                                catch (Exception ex)
                                {
                                    SetListViewItemValue(this.listView1, index, 7, "抢金错误");
                                }
                            }
                            SetListViewItemValue(this.listView1, index, 7, "成功抢金" + grabGoldSuccess + "个好友！");
                        }
                        catch (Exception ex)
                        {
                            SetListViewItemValue(this.listView1, index, 7, "抢金失败");
                        }
                        #endregion 
                    }

                    int fetchBoxCount = 0;
                    if (configInfo.IsAutoGrabTreasure)
                    {
                        #region 步步夺宝
                        SetListViewItemValue(this.listView1, index, 7, "正在夺宝...");
                        var fetchBoxFuncList = new List<Func<string, PajkResultList<PajkFetchBoxResult>>>();
                        fetchBoxFuncList.Add(PH.FetchBoxByShareReading);
                        fetchBoxFuncList.Add(PH.FetchBoxByWalkMall);
                        fetchBoxFuncList.Add(PH.FetchBoxByInviteFriend);
                        fetchBoxFuncList.Add(PH.FetchBoxByVideo);
                        for (int j = 0; j < fetchBoxFuncList.Count; j++)
                        {
                            try
                            {
                                var fetchResult = fetchBoxFuncList[j](cookie);
                                Thread.Sleep(1200);
                                SetListViewItemValue(this.listView1, index, 7, "得到宝箱：" + fetchResult.Content[0].BoxGiftList[0].GiftName);
                                fetchBoxCount += fetchResult.Content[0].BoxGiftList.Length;
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        #endregion 
                    }

                    Thread.Sleep(1000);

                    bool uploadWalkData = true;
                    float sc = 0f;
                    if (configInfo.IsAutoUploadWalkData)
                    {
                        #region 上传走步数据

                        SetListViewItemValue(this.listView1, index, 7, "正在上传走步数据");
                        try
                        {
                            var downloadResult = PH.DownloadWalkData(id, cookie, cert);
                            if (downloadResult != null)
                            {
                                PajkWalkDataInfo today = null;
                                if (downloadResult.Content[0].walkDataInfos == null ||
                                    (today = downloadResult.Content[0].walkDataInfos.Find(
                                            match => match.walkDate == DateTime.Now.ToString("yyyyMMdd"))) == null)
                                {
                                    int stepCount = new Random((int)DateTime.Now.Ticks).Next(
                                        GlobalContext.CurrentConfigInfo.RandomMinStep,
                                        GlobalContext.CurrentConfigInfo.RandomMaxStep);
                                    sc = stepCount;
                                    var result = PH.UploadWalkData(id, cookie, cert, stepCount);
                                    if (result.Content[0].Value)
                                    {
                                        SetListViewItemValue(this.listView1, index, 7, "成功上传走步" + stepCount + "！");
                                    }
                                    else
                                    {
                                        throw new Exception(result.Stat.Code.ToString());
                                    }
                                }
                                else
                                {
                                    sc = today.stepCount;
                                    SetListViewItemValue(this.listView1, index, 7, "今天已上传走步" + today.stepCount + "。");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SetListViewItemValue(this.listView1, index, 7, "上传走步失败");
                            uploadWalkData = false;
                        }
                        #endregion 
                    }

                    SetListViewItemValue(this.listView1, index, 7, 
                        string.Format("领取昨日奖励：{0}，上传走步：{1}，成功抢金：{2}个，得到宝箱：{3}个",
                        fetchYestodayReward?"成功":"失败",
                        uploadWalkData?sc.ToString():"失败",
                        grabGoldSuccess,
                        fetchBoxCount));
                }
                SetControlEnabled(this.toolStrip1, true);
            });
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (this.listView1.CheckedItems.Count < 1)
            {
                MsgBox.ShowInfo("请勾选账号！");
                return;
            }

            if (MsgBox.ShowOkCancel("确定要删除勾选的账号？", "提示") == DialogResult.Cancel)
                return;

            for (int i = this.listView1.CheckedItems.Count-1; i >= 0; i--)
            {
                int index = this.listView1.CheckedItems[i].Index;
                string cookie = GetListViewItemValue(this.listView1, index, 3);
                string name = GetListViewItemValue(this.listView1, index, 1);
                ConfigStorage.GetInstance().RemoveCookieInfo(new CookieInfo() { Cookie = cookie });
                this.listView1.Items.RemoveAt(index);
            }

            // 重新排序
            for (var i = 0; i < this.listView1.Items.Count; i++)
            {
                this.listView1.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void 切换账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count < 1)
                return;

            var item = this.listView1.SelectedItems[0];
            CookieInfo cookieInfo = item.Tag as CookieInfo;
            string cookie = cookieInfo.Cookie;

            var frmLogin = new FrmLogin(cookie, true);
            if (frmLogin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GlobalContext.MainForm.ChangeLoginState(frmLogin.MyUserInfo, frmLogin.CookieString, frmLogin.CertPath);
            }
            frmLogin.Dispose();
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                return;
            if (this.listView1.SelectedItems.Count < 1)
                return;

            this.contextMenuStrip1.Show(this.listView1, e.Location);
        }
    }
}
