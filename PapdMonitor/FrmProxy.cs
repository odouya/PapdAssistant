using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using PapdLib;
using PapdMonitor.Util;

namespace PapdMonitor
{
    public partial class FrmProxy : FrmBase
    {
        public FrmProxy()
        {
            InitializeComponent();
        }

        private void FrmProxy_Load(object sender, EventArgs e)
        {
            base.EnableCancelButton();
            InitProxy();
        }

        private void InitProxy()
        {
            if (PapdHelper.Proxy == null)
            {
                this.comboBoxType.SelectedIndex = 0;
            }
            else
            {
                this.comboBoxType.SelectedIndex = 1;
                this.txtIp.Text = PapdHelper.Proxy.Address.Host;
                this.txtPort.Text = PapdHelper.Proxy.Address.Port.ToString();
                if (PapdHelper.Proxy.Credentials != null)
                {
                    this.txtUser.Text = (PapdHelper.Proxy.Credentials as NetworkCredential).UserName;
                    this.txtPwd.Text = (PapdHelper.Proxy.Credentials as NetworkCredential).Password;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.comboBoxType.SelectedIndex == 0)
            {
                PapdHelper.Proxy = null;
            }
            else
            {
                WebProxy proxy = new WebProxy(
                    string.Format("http://{0}:{1}", this.txtIp.Text, this.txtPort.Text), true);
                if (!string.IsNullOrEmpty(this.txtUser.Text) &&
                    !string.IsNullOrEmpty(this.txtPwd.Text))
                {
                    proxy.Credentials = new NetworkCredential(this.txtUser.Text.Trim(), this.txtPwd.Text);
                }
                PapdHelper.Proxy = proxy; 
            }

            this.DialogResult = DialogResult.OK;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool noProxy = this.comboBoxType.SelectedIndex == 0;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = !noProxy;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
