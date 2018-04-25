using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PapdLib;
using PapdLib.Info;

namespace PapdMonitor
{
    /// <summary>
    /// 创建订单窗体
    /// </summary>
    public partial class FrmCreateOrder : FrmBase
    {
        private IProductInfo mProductInfo;
        public event EventHandler CreateOrder;
        public AddressInfo SelectedAddress;
        public string SelectedMobile;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="productInfo">商品信息</param>
        public FrmCreateOrder(IProductInfo productInfo)
        {
            InitializeComponent();
            this.mProductInfo = productInfo;
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.txtProductName.Text = this.mProductInfo.name;
            if (this.mProductInfo.IsMobileRechargeProduct)
            {
                // 手机充值商品
                this.label1.Text = "请输入充值手机号：";
                MobileTextBox txtInputMobile = new MobileTextBox()
                {
                    Location = this.txtInput.Location,
                    Size = this.txtInput.Size,
                    Visible = true
                };
                this.Controls.Add(txtInputMobile);//必须把控件添加到控件中才能显示出来
                this.txtInput.Dispose();
                this.txtInput = txtInputMobile;
                this.btnSelect.Click += btnSelectMobile_Click;
            }
            else
            {
                // 非手机充值类商品
                this.label1.Text = "请选择收货地址：";
                this.btnSelect.Click += btnSelectAddress_Click;
            }
        }

        #region “选择”按钮点击事件
        /// <summary>
        /// “选择收货地址”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAddress_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectAddress(GlobalContext.CurrentCookieString);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var addressInfo = frm.CurrentAddressInfo;
                this.txtInput.Text = addressInfo == null ? null : addressInfo.ToString();
                this.txtInput.Tag = addressInfo;
            }
        }

        /// <summary>
        /// “选择充值手机号”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectMobile_Click(object sender, EventArgs e)
        {
            if (GlobalContext.HistoryRechargeMobile.Count < 1)
            {
                bool isThreadRunning = true;
                ThreadPool.QueueUserWorkItem(p =>
                {
                    try
                    {
                        var mobiles = GlobalContext.PH.GetHistoryOrderMobiles(GlobalContext.CurrentCookieString);
                        lock (GlobalContext.HistoryRechargeMobile)
                        {
                            GlobalContext.HistoryRechargeMobile.Clear();
                            GlobalContext.HistoryRechargeMobile.AddRange(mobiles);
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    isThreadRunning = false;
                });
                while (isThreadRunning) Application.DoEvents();
            }

            if (GlobalContext.HistoryRechargeMobile.Count < 1)
            {
                MsgBox.ShowInfo("没有历史充值号码！");
                return;
            }

            var frm = new FrmList(GlobalContext.HistoryRechargeMobile);
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            this.txtInput.Text = frm.SelecteItem as string;
        } 
        #endregion

        /// <summary>
        /// “提交订单”按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (this.mProductInfo.IsMobileRechargeProduct)
            {
                if (this.txtInput.Text.Trim().Length != 11)
                {
                    MsgBox.ShowInfo("请输入有效的手机号码！");
                    return;
                }
            }
            else
            {
                if (this.txtInput.Tag == null)
                {
                    MsgBox.ShowInfo("请选择收货地址！");
                    return;
                }
            }

            this.SelectedAddress = this.txtInput.Tag as AddressInfo;
            this.SelectedMobile = this.txtInput.Text.Trim();

            if (CreateOrder != null)
            {
                CreateOrder(this, new EventArgs());
            }
            else
            {
                GlobalContext.MainForm.DoGrab(this.mProductInfo,
                    GlobalContext.CurrentCookieString,
                    this.txtInput.Text.Trim(),
                    this.txtInput.Tag as AddressInfo); 
            }
        }

        /// <summary>
        /// “取消”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.Close();
            }
        }
    }
}
