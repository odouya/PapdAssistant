using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using PapdLib.Info;

namespace PapdMonitor
{
    /// <summary>
    /// 输入手机号窗体
    /// </summary>
    public partial class FrmInputPhone : FrmBase
    {

        #region 属性和字段
        private string phoneNumber;
        private List<string> historyMobiles;

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                this.phoneNumber = value;
                this.txtPhone.Text = value.ToString();
            }
        } 
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmInputPhone(List<string> historyMobiles)
        {
            InitializeComponent();

            if (historyMobiles == null || historyMobiles.Count<1)
                HideHistoryMobile();
            this.historyMobiles = historyMobiles;
        }

        /// <summary>
        /// 隐藏历史充值手机号按钮
        /// </summary>
        private void HideHistoryMobile()
        {
            this.btnHistory.Visible = false;
            this.ClientSize = new Size(this.btnOk.Right + this.label1.Left - 6, this.ClientSize.Height);
        }

        /// <summary>
        /// “确定”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string phone = this.txtPhone.Text.Trim();
            if (!Regex.IsMatch(phone, "^[1][0-9]{10}$"))
            {
                MessageBox.Show("请输入有效的11手机号码！");
                return;
            }
            this.PhoneNumber = phone;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// “取消”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }

        /// <summary>
        /// “选择历史手机号”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            var frm = new FrmList(this.historyMobiles);
            if (frm.ShowDialog() != DialogResult.OK)
                return;
            this.txtPhone.Text = frm.SelecteItem as string;
        }
    }
}
