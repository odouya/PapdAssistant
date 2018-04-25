using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Newtonsoft.Json;
using PapdLib;
using PapdLib.Util;

namespace PapdMonitor
{
    public partial class FrmStepManager : FrmBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmStepManager()
        {
            InitializeComponent();
            base.EnableCancelButton();
            this.toolStripTextBoxCurCertPath.Text = MyCertPath;
        }

        #region “获取走步数据”按钮点击事件
        /// <summary>
        /// “获取走步数据”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDownloadStepData_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
            {
                return;
            }

            string certPath = MyCertPath;
            if (certPath == null || !System.IO.File.Exists(certPath)) // 证书路径不存在，则重新选择
            {
                if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                certPath = this.openFileDialog1.FileName;
            }

            try
            {
                var result = PH.DownloadWalkData(MyUserInfo.id.ToString(), MyCookie, certPath);

                if (result == null)
                {
                    base.SetMyCertPath(null);
                    MsgBox.ShowInfo("无效证书！");
                    return;
                }

                if (result.Content==null||
                    result.Content.Count < 1 ||
                    result.Content[0].walkDataInfos == null ||
                    result.Content[0].walkDataInfos.Count < 1)
                {
                    // 没有数据
                    MsgBox.ShowInfo("未查询到走步数据！");
                    return;
                }

                var query = from info in result.Content[0].walkDataInfos
                            orderby info.walkDate descending
                            select info;

                this.listView1.Items.Clear();
                int index = 0;
                foreach (var item in query)
                {
                    var lvItem = new ListViewItem(new string[]
                    {
                        (++index).ToString(),
                        item.id.ToString(),
                        item.walkDate.ToString(),
                        item.distance*0.001+"",
                        item.stepCount.ToString(),
                        ToDateTime(item.walkTime).ToString(),
                        item.calories.ToString(),
                        item.targetStepCount.ToString()
                    });
                    this.listView1.Items.Add(lvItem);
                }

                SetMyCertPath(certPath);
            }
            catch (Exception ex)
            {
                SetMyCertPath(null);
                MsgBox.ShowInfo("查询失败，" + ex.Message);
            }
            UpdateCertPathDisplay();
        } 
        #endregion

        #region “上传走步数据”按钮点击事件
        /// <summary>
        /// “上传走步数据”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonUploadStepData_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
            {
                return;
            }

            var frmStepDataGen = new FrmStepDataGen();
            if (frmStepDataGen.ShowDialog() == DialogResult.Cancel)
                return;

            string certPath = MyCertPath;
            if (certPath == null || !System.IO.File.Exists(certPath)) // 证书路径不存在，则重新选择
            {
                if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                certPath = this.openFileDialog1.FileName;
            }

            try
            {
                var result = PH.UploadWalkData(MyUserInfo.id.ToString(), MyCookie, certPath, frmStepDataGen.StepCount);
                if (result == null)
                {
                    SetMyCertPath(null);
                    MsgBox.ShowInfo("无效证书！");
                    return;
                }
                if (result.Content[0].Value)
                {
                    MsgBox.ShowInfo("上传成功！");
                }
                SetMyCertPath(certPath);
            }
            catch (Exception ex)
            {
                SetMyCertPath(null);
                MsgBox.ShowInfo("上传失败，" + ex.Message);
            }
            UpdateCertPathDisplay();
        } 
        #endregion

        private DateTime ToDateTime(long value)
        {
            //0.1毫秒时间戳转时间
            return (new DateTime(1970, 1, 1) + new TimeSpan((long)(value * Math.Pow(10, 4)))).ToLocalTime();
        }

        /// <summary>
        /// 窗体关闭时，保存证书路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStepManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!base.IsLogin())
                return;

            // 保存证书路径
            var config = new ConfigStorage(GlobalContext.ConfigFileName);
            if (GlobalContext.CurrentCertPath != null)
            {
                config.UpdateCookieInfo(new CookieInfo() { Id = GlobalContext.CurrentUserInfo.id, CertPath = GlobalContext.CurrentCertPath }); 
            }
            else
            {
                config.ClearUserCert(GlobalContext.CurrentUserInfo.id);
            }
        }

        /// <summary>
        /// “帮助”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonHelp_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("平安好医生手机证书默认路径：");
            builder.AppendLine(@"sdcard\pajk\hm\pfx\api.jk.cn.pfx");
            MsgBox.ShowInfo(builder.ToString(), "帮助");
        }

        /// <summary>
        /// “查看证书”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (MyCertPath == null)
            {
                return;
            }

            try
            {
                new Thread(() => Process.Start("explorer.exe", "/select, " + MyCertPath)){IsBackground = true}.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// “选择证书”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSelectCert_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            base.SetMyCertPath(this.openFileDialog1.FileName);
            UpdateCertPathDisplay();
        }

        /// <summary>
        /// “清除证书”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonClearCert_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;
            if (MsgBox.ShowOkCancel("确定要清除证书？", "提示") == DialogResult.OK)
            {
                base.SetMyCertPath(null);
                UpdateCertPathDisplay();
            }
        }

        /// <summary>
        /// 更新证书路径显示框
        /// </summary>
        private void UpdateCertPathDisplay()
        {
            this.toolStripTextBoxCurCertPath.Text = MyCertPath;
        }

        /// <summary>
        /// 查看证书详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonViewCertDetail_Click(object sender, EventArgs e)
        {
            if (MyCertPath == null)
            {
                return;
            }
            try
            {
                var x509 = CertificateUtil.GetCertObject(MyCertPath);
                MessageBox.Show(x509.SubjectName.Name);
            }
            catch (Exception ex)
            {
                MsgBox.ShowWarnning("证书读取失败，" + ex.Message);
            }
        }

        /// <summary>
        /// CTRL+A全选证书路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxCurCertPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                this.toolStripTextBoxCurCertPath.SelectAll();
            }
        }

        /// <summary>
        /// 另存证书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSaveCert_Click(object sender, EventArgs e)
        {
            if (MyCertPath == null)
            {
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "证书(*.pfx)|*.pfx";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // 读取证书数据
                    byte[] certData = System.IO.File.ReadAllBytes(MyCertPath);
                    // 另存为
                    System.IO.File.WriteAllBytes(dialog.FileName, certData);
                    MsgBox.ShowInfo("证书另存完成！");
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInfo("证书另存失败，" + ex.Message);
                }
            }
        }
    }
}
