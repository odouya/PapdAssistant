using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PapdLib;

namespace PapdMonitor
{
    public partial class FrmQRCode : FrmBase
    {

        #region 属性和字段
        /// <summary>
        /// 右键菜单
        /// </summary>
        private ContextMenuStrip cms = null;

        /// <summary>
        /// 邀请二维码图片
        /// </summary>
        private Image qrCodeImage;


        /// <summary>
        /// 邀请地址
        /// </summary>
        private string inviteUrl;

        /// <summary>
        /// 邀请码
        /// </summary>
        private string inviteCode; 
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="qrCodeImage">邀请二维码图片</param>
        /// <param name="inviteUrl">邀请地址</param>
        /// <param name="inviteCode">邀请码</param>
        public FrmQRCode(Image qrCodeImage, string inviteUrl, string inviteCode)
        {
            InitializeComponent();
            this.qrCodeImage = qrCodeImage;
            this.inviteUrl = inviteUrl;
            this.inviteCode = inviteCode;
            InitQRImage();
            InitContextMenu();
            this.lblInviteCode.Text = this.inviteCode;
        } 
        #endregion

        #region 初始化

        /// <summary>
        /// 初始化二维码图片
        /// </summary>
        private void InitQRImage()
        {
            this.pictureBox1.BackgroundImage = qrCodeImage;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// 初始化右键菜单
        /// </summary>
        private void InitContextMenu()
        {
            this.cms = new ContextMenuStrip();
            this.cms.Items.Add("图片另存为...", null, (sender, args) =>
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "另存为";
                sfd.FileName = "我的邀请二维码.png";
                sfd.Filter = "PNG(*.png)|*.png";
                sfd.FilterIndex = 0;
                var dr = sfd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        //创建目录
                        string dir = Path.GetDirectoryName(sfd.FileName);
                        if (!Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        //保存图片
                        //注：使用Image对象直接Save()时
                        //报错：GDI+ 中发生一般性错误。
                        //解决：通过Image对象创建Bitmap对象，再调用Save()
                        Bitmap bmp = new Bitmap(qrCodeImage);
                        bmp.Save(sfd.FileName,ImageFormat.Png);
                        MessageBox.Show("保存成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败，" + ex.Message);
                    }
                }
            });
            this.cms.Items.Add("复制图片", null, (sender, args) =>
            {
                try
                {
                    Clipboard.SetImage(this.qrCodeImage);
                    MessageBox.Show("已复制！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("复制失败，" + ex.Message);
                }
            });
            if (GlobalContext.CurrentUserInfo!=null)
            {
                this.cms.Items.Add("打开链接", null, (sender, args) => Process.Start(PapdHelper.GetInviteUrl(
                                                                                            GlobalContext.CurrentUserInfo.id.ToString(),
                                                                                            this.inviteCode))); 
            }
        } 
        #endregion

        #region 显示右键菜单
        /// <summary>
        /// 二维码图片右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.cms.Show(this.pictureBox1, e.Location); 
            }
        } 
        #endregion

        /// <summary>
        /// 邀请码标签点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInviteCode_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetData(DataFormats.Text, inviteCode);
                MessageBox.Show("邀请码已复制！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("邀请码复制失败，" + ex.Message);
            }
        }

        /// <summary>
        /// “快速邀请”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuickInvite_Click(object sender, EventArgs e)
        {
            SetControlStateWhenQuickInvite(false);
            var frm = new FrmInputPhone(null);
            frm.Text = "请输入被邀请人的手机号";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                try
                {
                    GlobalContext.PH.QuickInvite(this.inviteCode, frm.PhoneNumber);
                    MsgBox.ShowInfo("邀请成功！");
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInfo("邀请失败，" + ex.Message);
                }
            }
            SetControlStateWhenQuickInvite(true);
        }

        private void SetControlStateWhenQuickInvite(bool enabled)
        {
            this.btnQuickInvite.Enabled = enabled;
            this.btnQuickInvite.Text = enabled ? "快速邀请" : "邀请中";
        }

        private void btnTip_Click(object sender, EventArgs e)
        {
            new FrmInviteTip().ShowDialog();
        }
    }
}
