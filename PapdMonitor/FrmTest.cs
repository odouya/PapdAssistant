using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using PapdLib;

namespace PapdMonitor
{
    public partial class FrmTest : FrmBase
    {
        private PapdHelper PH = new PapdHelper();
        private string mCurrentCookie = null;

        public FrmTest()
        {
            InitializeComponent();
            this.cmboCookieType.SelectedIndex = 0;
            this.textBox1.Text = GlobalContext.CurrentCookieString;
            this.txtCookie.Text = GlobalContext.CurrentCookieString;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            string combineStr = string.Empty;
            try
            {
                if (this.textBox2.Text.Trim().Length < 1)
                {
                    MsgBox.ShowInfo("请输入参数！");
                    return;
                }
                string[] content = this.textBox2.Lines;
                StringBuilder builder = new StringBuilder();
                foreach (var line in content)
                {
                    string[] parts = line.Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 1)
                        continue;
                    if (parts[0] == "_sig")
                        continue;
                    if (parts.Length == 2)
                    {
                        builder.Append(parts[0] + "=" + System.Web.HttpUtility.UrlEncode(parts[1]));
                    }
                    else if (parts.Length == 1)
                    {
                        builder.Append(parts[0] + "=");
                    }
                    builder.Append("&");
                }
                string postData = builder.ToString();
                postData = postData.Substring(0, postData.Length - 1);

                this.textBox3.Text = PapdHelper.CalcSig(postData, this.textBox1.Text, GlobalContext.CurrentPfxPrivateKey, out combineStr);
                this.textBox3.Text += "\r\n";
                this.textBox3.Text += "\r\n";
                this.textBox3.Text += combineStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("计算失败，" + ex.Message);
                this.textBox3.Text = combineStr;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string result = PH.Post(this.textBox4.Text, mCurrentCookie);
                this.textBox5.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmboCookieType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmboCookieType.SelectedIndex)
            {
                case 0:
                    this.mCurrentCookie = null;
                    break;
                case 1:
                    this.mCurrentCookie = GlobalContext.CurrentCookieString;
                    break;
                case 2:
                    var frm = new FrmInputText();
                    var point = this.cmboCookieType.Parent.PointToScreen(this.cmboCookieType.Location);
                    point.Y += this.cmboCookieType.Height + 1;
                    frm.Location = point;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        this.mCurrentCookie = frm.InputText;
                    }
                    break;
            }
        }

        #region 设置CookieTab页

        /// <summary>
        /// “设置Cookie”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetCookie_Click(object sender, EventArgs e)
        {
            string url = this.txtUrl.Text.Trim();
            string cookie = this.txtCookie.Text.Trim();
            bool result = PapdHelper.SetIECookie(url, cookie);

            this.btnOpenIE.Enabled = result;
            this.btnOpenBrowser.Enabled = result;
            MsgBox.ShowInfo("设置" + (result ? "成功" : "失败") + "！");
        }

        /// <summary>
        /// “打开IE”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenIE_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("iexplore.exe", this.txtUrl.Text.Trim());
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// “打开浏览器”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenBrowser_Click(object sender, EventArgs e)
        {
            var frm = new FrmWeb(this.txtUrl.Text.Trim());
            frm.Show();
        } 
        #endregion

        /// <summary>
        /// "选择证书"按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectaPfxFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择证书文件";
            ofd.Multiselect = false;
            ofd.Filter = "证书文件(*.pfx)|*.pfx";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                //打开证书
                System.Security.Cryptography.X509Certificates.X509Certificate2 x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(
                    ofd.FileName, 
                    PapdHelper.DEFAULT_PFX_PASSWORD, X509KeyStorageFlags.Exportable);
                MsgBox.ShowInfo("证书是别名：" + x509.SubjectName.Name);
                //x509.Thumbprint;
                //x509.PublicKey.Key.ToXmlString(false);
                GlobalContext.CurrentPfxPrivateKey = x509.PrivateKey.ToXmlString(true);
            }
            catch (Exception ex)
            {
                MsgBox.ShowInfo("证书无效，" + ex.Message);
            }
        }

        /// <summary>
        /// 设置TextBox按下Ctrl+A时，全选文本
        /// </summary>
        /// <param name="textBox"></param>
        private void SetTextBoxCtrlA(TextBox textBox)
        {
            if (textBox == null)
                return;
            textBox.KeyDown += (sender, args) =>
            {
                if (args.Control && args.KeyCode == Keys.A)
                    textBox.SelectAll();
            };
        }

        private void SetTextBoxCopyToEncodeFormMenu(TextBox textBox)
        {
            if (textBox != null)
            {
                textBox.ContextMenuStrip = new ContextMenuStrip();
                textBox.MouseDown += (sender, args) =>
                {
                    if (args.Button != MouseButtons.Right)
                        return;
                    ContextMenuStrip cms = new ContextMenuStrip();
                    cms.Items.Add("【文本加密】", null, (o, eventArgs) =>
                    {
                        new FrmTextEncode() { SourceString = textBox.SelectedText }.Show();
                    });
                    cms.Show(textBox, args.Location);
                };
            }
        }

        private void FrmTest2_Shown(object sender, EventArgs e)
        {
            // 将TabControl中所有文本框绑定Ctrl+A快捷键 以及 右键菜单
            for (int i = 0; i < this.tabControl1.TabCount; i++)
            {
                TabPage tabPage = this.tabControl1.TabPages[i];
                int controlCount = tabPage.Controls.Count;
                for (int j = 0; j < controlCount; j++)
                {
                    if (tabPage.Controls[j] is TextBox)
                    {
                        SetTextBoxCtrlA(tabPage.Controls[j] as TextBox);
                        SetTextBoxCopyToEncodeFormMenu(tabPage.Controls[j] as TextBox);
                    }
                }
            }
        }

        private void btnUrls_Click(object sender, EventArgs e)
        {
            // 从PapdHelper中获取静态字段Url

            List<string> urls = new List<string>();
            Type type = typeof (PapdHelper);
            FieldInfo[] fis = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            for (int i = 0; i < fis.Length; i++)
            {
                FieldInfo fi = fis[i];
                if (fi.FieldType == typeof (string))
                {
                    object value = fi.GetValue(null);
                    if (value != null &&
                        value.ToString().StartsWith("http://", StringComparison.CurrentCultureIgnoreCase))
                    {
                        urls.Add(value.ToString());
                    }
                } ;
            }
            if (urls.Count > 0)
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                foreach (var url in urls)
                {
                    cms.Items.Add(url, null, (o, args) =>
                    {
                        ToolStripMenuItem menuItem = o as ToolStripMenuItem;
                        this.txtUrl.Text = menuItem.Text;
                    });
                }
                cms.Show(tabPage3, new Point(this.txtUrl.Left, this.txtUrl.Bottom));
            }
        }

        /// <summary>
        /// 查看图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string pictureCode = this.textBox6.Text.Trim();

            DoTask(() => {
                Image img = PH.GetImageByPapdCode(pictureCode);

                var frm = new FrmViewPic(img);
                frm.ShowDialog();
                frm.Dispose();
            }, "查看图片失败", true);
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            var configInfo = ConfigStorage.GetInstance().GetConfigInfo();
            ContextMenuStrip cms = new ContextMenuStrip();
            configInfo.HistoryCookies.ForEach(action =>
                {
                    var item = cms.Items.Add(action.Name, null, (o, args) =>
                        {
                            var menuItem = o as ToolStripItem;
                            var cookieInfo = menuItem.Tag as CookieInfo;
                            try
                            {
                                //打开证书
                                System.Security.Cryptography.X509Certificates.X509Certificate2 x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(
                                    cookieInfo.CertPath,
                                    PapdHelper.DEFAULT_PFX_PASSWORD, X509KeyStorageFlags.Exportable);
                                MsgBox.ShowInfo("证书是别名：" + x509.SubjectName.Name);
                                //x509.Thumbprint;
                                //x509.PublicKey.Key.ToXmlString(false);
                                GlobalContext.CurrentPfxPrivateKey = x509.PrivateKey.ToXmlString(true);
                            }
                            catch (Exception ex)
                            {
                                MsgBox.ShowInfo("证书无效，" + ex.Message);
                            }
                        });
                    item.Tag = action;
                });
            cms.Show(this.button2, e.Location);
        }
    }
}
