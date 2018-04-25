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
using PapdLib.Info;
using PapdLib.Util;

namespace PapdMonitor
{
    public partial class FrmLogin : FrmBase
    {
        /// <summary>
        /// Cookie字符串
        /// </summary>
        public string CookieString { get; private set; }

        /// <summary>
        /// 证书文件路径
        /// </summary>
        public string CertPath { get; private set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo MyUserInfo { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmLogin(string cookieString):this()
        {
            this.textBoxCookie.Text = cookieString;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cookieString"></param>
        /// <param name="autoLogin"></param>
        public FrmLogin(string cookieString, bool autoLogin) : this()
        {
            this.textBoxCookie.Text = cookieString;
            if (autoLogin)
            {
                buttonOk_Click(null, null); 
            }
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            string cookie = base.GetControlText(this.textBoxCookie).Trim();
            if (cookie.Length < 1)
            {
                MessageBox.Show("请输入Cookie！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //登录
            this.CookieString = cookie;
            var config = new ConfigStorage(GlobalContext.ConfigFileName);
            Thread thread = new Thread(()=>
            {
                try
                {
                    ChangeControlState(false);
                    this.MyUserInfo = GlobalContext.PH.GetUserInfo(cookie);

                    if (CertPath == null)
                    {
                        CookieInfo foundCookieInfo;
                        if ((foundCookieInfo = config.GetCookieInfoByUserId(this.MyUserInfo.id)) != null)
                        {
                            CertPath = foundCookieInfo.CertPath;
                        } 
                    }

                    // 更新配置文件中的账户信息
                    config.UpdateCookieInfo(new CookieInfo()
                    {
                        Id = this.MyUserInfo.id,
                        Name = this.MyUserInfo.nick,
                        Cookie = cookie,
                        CertPath = CertPath
                    });
                    
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    GlobalContext.MainForm.Output("登录失败：" + ex.Message);
                    this.CookieString = null;
                    this.CertPath = null;
                    if (ex.Message.Contains("已过期"))
                    {
                        GlobalContext.Output("Cookie已过期，正在更新Cookie...");
                        string tk = CookieUtil.GetCookieValue(cookie, "_tk");
                        var cookieInfo = config.GetCookieInfoByCookieUserToken(tk);
                        string id = null;
                        if (cookieInfo == null || cookieInfo.Id == null)
                        {
                            var frm = new FrmInputText();
                            frm.Text = "请输入健康号";
                            frm.FormBorderStyle = FormBorderStyle.Sizable;
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            if (frm.ShowDialog() != DialogResult.OK)
                            {
                                ChangeControlState(true);
                                return;
                            }
                            id = frm.InputText.Trim();
                        }
                        else
                        {
                            id = cookieInfo.Id.ToString();
                        }

                        string certPath = null;
                        if (cookieInfo == null || !File.Exists(cookieInfo.CertPath))
                        {
                            var ofd = new OpenFileDialog();
                            ofd.Title = "请选择证书";
                            ofd.Filter = "证书文件（*.pfx）|*.pfx";
                            ofd.FilterIndex = 1;
                            ofd.Multiselect = false;
                            if (ofd.ShowDialog() != DialogResult.OK)
                            {
                                ChangeControlState(true);
                                return;
                            }
                            certPath = ofd.FileName;
                        }
                        else
                        {
                            certPath = cookieInfo.CertPath;
                        }

                        try
                        {
                            var result = GlobalContext.PH.RenewUserTokenAndWebToken(id, cookie, certPath);
                            if (result.Stat.Code == 0)
                            {
                                string cookieNew = string.Empty;
                                cookieNew += "_tk=" + System.Web.HttpUtility.UrlEncode(result.Content[0].Token) + ";"; // 必须进行urlencode
                                cookieNew += "_wtk=" + result.Content[0].WebToken + ";";
                                SetControlText(this.textBoxCookie, cookieNew);

                                this.CertPath = certPath;

                                // 重新登录
                                buttonOk_Click(null, null);

                                //StringBuilder builder = new StringBuilder();
                                //builder.AppendLine("Uid:" + result.Content[0].Uid);
                                //builder.AppendLine("Tk:" + result.Content[0].Token);
                                //builder.AppendLine("Wtk:" + result.Content[0].WebToken);
                                //builder.AppendLine("Expire:" + result.Content[0].GetExpireTime());
                                //builder.AppendLine("LockTime:" + result.Content[0].LockTime);
                                //builder.AppendLine("请重新点击登录！");

                                //MsgBox.ShowInfo(builder.ToString(), "更新成功");
                            }
                        }
                        catch (Exception ex2)
                        {
                            MsgBox.ShowInfo("更新失败，" + ex2.Message);
                        }
                        ChangeControlState(true);
                        return;
                    }
                    else if (ex.Message.Contains("设备上退出"))
                    {
                        config.RemoveCookieInfo(new CookieInfo {Cookie = this.CookieString});
                    }

                    MessageBox.Show("登录失败，" + ex.Message);
                    ChangeControlState(true);
                }
                finally
                {
                    //重新读取历史Cookie信息
                    ConfigInfo configInfo = config.GetConfigInfo();
                    GlobalContext.HistoryCookies = configInfo.HistoryCookies;
                }
            });
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// 修改控件状态
        /// </summary>
        /// <param name="isEnabled"></param>
        private void ChangeControlState(bool isEnabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(ChangeControlState), isEnabled);
                return;
            }
            this.buttonHistoryCookies.Enabled = isEnabled;
            this.btnReadFromDb.Enabled = isEnabled;
            this.buttonOk.Enabled = isEnabled;
            this.buttonOk.Text = isEnabled ? "登录" : "登录中";
            this.buttonCancel.Enabled = isEnabled;
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Cookie输入框的KeyPress事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCookie_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((int)e.KeyChar == 1)
            {
                //处理Ctrl+A快捷键
                tb.SelectAll();
            }
        }

        /// <summary>
        /// 历史Cookie按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistoryCookies_Click(object sender, EventArgs e)
        {
            GlobalContext.RereadConfig();

            this.contextMenuStrip1.Items.Clear();

            //动态添加菜单
            if (GlobalContext.HistoryCookies.Count < 1)
            {
                var menu = new ToolStripMenuItem();
                menu.Text = "无";
                this.contextMenuStrip1.Items.Add(menu);
            }
            else
            {
                foreach (var cookieInfo in GlobalContext.HistoryCookies)
                {
                    var menuItem = new ToolStripMenuItem();
                    menuItem.Text = cookieInfo.Name;//Cookie名称
                    menuItem.Tag = cookieInfo;
                    menuItem.Click += (s, ea) =>
                    {
                        var info = (s as ToolStripMenuItem).Tag as CookieInfo;
                        this.textBoxCookie.Text = info.Cookie;
                        this.CookieString = info.Cookie;
                        this.CertPath = info.CertPath;
                    };
                    this.contextMenuStrip1.Items.Add(menuItem);
                }
            }

            //显示菜单
            Point menuClientPoint = new Point(this.buttonHistoryCookies.Left, this.buttonHistoryCookies.Bottom);//菜单显示在按钮的正下方
            Point menuScreenPoint = this.PointToScreen(menuClientPoint);//将控件的客户区域坐标转换为屏幕坐标
            this.contextMenuStrip1.Show(menuScreenPoint);
        }

        /// <summary>
        /// 从DB文件中读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFromDb_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "打开Cookie文件";
            dlg.FileName = "Cookies";
            var dr = dlg.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;

            ReadCookieFromFile(dlg.FileName);
        }

        /// <summary>
        /// 从文件中获取Cookie
        /// </summary>
        /// <param name="fileName">sqlite数据库文件地址</param>
        private void ReadCookieFromFile(string fileName)
        {
            try
            {
                //读取db数据库
                //SQLiteConnection conn = new SQLiteConnection();
                //conn.ConnectionString = "data source=" + fileName;
                //conn.Open();
                //SQLiteCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "select name,value from cookies";
                //SQLiteDataReader reader = cmd.ExecuteReader();
                //var dic = new Dictionary<string, string>();
                //var keys = new List<string>() { "_webDtk", "_tk", "_wtk" };
                //while (reader.Read())
                //{
                //    string name = Convert.ToString(reader.GetValue(0)).Trim();
                //    string value = Convert.ToString(reader.GetValue(1));

                //    if (keys.Contains(name))
                //    {
                //        dic.Add(name, value);
                //    }
                //}
                //reader.Close();
                //cmd.Dispose();
                //conn.Close();

                //显示Cookie
                //StringBuilder builder = new StringBuilder();
                //foreach (KeyValuePair<string, string> item in dic)
                //{
                //    builder.Append(item.Key + "=" + item.Value + ";");
                //}
                //this.textBoxCookie.Text = builder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败，" + ex.Message);
            }
        }

        public void SetControlText(Control control, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Control, string>(SetControlText), control, text);
                return;
            }
            control.Text = text;
        }

        #region 将Cookie文件拖动到文本框中

        /// <summary>
        /// 拖动进入时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCookie_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                e.Effect = DragDropEffects.None;
            }
            else if(files.Length==1)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>
        /// 拖动完成时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCookie_DragDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            ReadCookieFromFile(files[0]);
        } 
        #endregion

        #region 抓取Cookie按钮点击事件
        /// <summary>
        /// 抓取Cookie按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFetchCookie_Click(object sender, EventArgs e)
        {
            var frm = new FrmHttpProxy();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.textBoxCookie.Text = frm.Cookie;
                buttonOk_Click(null, null);
            }
        } 
        #endregion
    }
}
