using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PapdMonitor;

namespace PapdMonitor
{
    public partial class FrmImageVerifyCode : FrmBase
    {
        public string VerifyCode { get; private set; }

        public event EventHandler<RefreshImageEventArgs> RefreshImage;

        public Func<bool> ConfirmVerifyCode;

        public bool IsAutoVerifyCode;

        public FrmImageVerifyCode()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (RefreshImage != null)
            {
                var args = new RefreshImageEventArgs();
                RefreshImage(this, args);
                if (args.Img == null)
                {
                    ClearControl(this.pictureBox1);
                }
                else
                {
                    this.pictureBox1.Image = args.Img;
                    this.pictureBox1.Size = args.Img.Size;
                }
            }
        }

        private int failNum = 0;
        private void bntOk_Click(object sender, EventArgs e)
        {
            this.VerifyCode = this.textBox1.Text.Trim();
            if (ConfirmVerifyCode != null)
            {
                var result = ConfirmVerifyCode();
                if (!result)
                {
                    // 验证失败后，重新获取验证码，并且不退出窗体
                    pictureBox1_Click(null, null);
                    this.textBox1.Clear();
                    this.textBox1.Focus();
                    if (IsAutoVerifyCode)
                    {
                        failNum++;
                        if (failNum > 12)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            return;
                        }
                        bntOk_Click(null, null);
                    }
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void FrmImageVerifyCode_Load(object sender, EventArgs e)
        {
            pictureBox1_Click(null, null);
            if (IsAutoVerifyCode)
            {
                this.Text += " [自动识别模式]";
                bntOk_Click(null, null);
            }
        }

        public void SetVerifyCode(string str)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetVerifyCode), str);
                return;
            }
            this.textBox1.Text = str;
            this.textBox1.Refresh();
        }

        public Image GetPictureBoxImge()
        {
            if (this.InvokeRequired)
            {
                return this.Invoke(new Func<Image>(GetPictureBoxImge)) as Image;
            }
            return this.pictureBox1.Image;
        }

        public void DoConfirm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(DoConfirm));
                return;
            }
            this.bntOk_Click(null, null);
        }

        private void FrmImageVerifyCode_Shown(object sender, EventArgs e)
        {
        }
    }

    public class RefreshImageEventArgs : EventArgs
    {
        public Image Img;
    }
}
