using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using PapdLib;
using PapdLib.Info;
using PapdMonitor.Util;

namespace PapdMonitor
{
    /// <summary>
    /// 添加获取编辑收货地址窗体
    /// </summary>
    public partial class FrmEditAddress : FrmBase
    {
        /// <summary>
        /// 旧地址信息
        /// </summary>
        private AddressInfo oldAddressInfo;

        private PapdHelper PH = new PapdHelper();

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmEditAddress():this(null)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">地址信息</param>
        public FrmEditAddress(AddressInfo info)
        {
            InitializeComponent();

            this.oldAddressInfo = info;
            this.Text = info != null ? "修改地址" : "新增地址";//如果info为空，则新增；否则更新
            AddressInfo2Control(info);

            if (this.oldAddressInfo == null)
            {
                //如果为新增
                this.oldAddressInfo = new AddressInfo();
                this.oldAddressInfo.id = 0;
                this.oldAddressInfo.bizType = "mall";
            }
        } 
        #endregion

        /// <summary>
        /// 地址信息填充到控件上
        /// </summary>
        /// <param name="addressInfo">地址信息</param>
        private void AddressInfo2Control(AddressInfo addressInfo)
        {
            if (addressInfo == null)
                return;

            try
            {
                this.txtRecipientName.Text = addressInfo.recipientName;
                this.txtRecipientPhone.Text = addressInfo.recipientPhone;
                this.txtProvince.Text = addressInfo.province;
                this.txtCity.Text = addressInfo.city;
                this.txtStreetAddress.Text = addressInfo.streetAddress;
                this.txtHouseNum.Text = addressInfo.referAddr;
                this.chbIsDefault.Checked = addressInfo.isDefault;
                this.txtStreetAddress.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("填充信息失败，" + ex.Message);
            }
        }

        /// <summary>
        /// “保存”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            #region 校验信息
            var recipientName = this.txtRecipientName.Text.Trim();
            if (recipientName.Length < 1)
            {
                MessageBox.Show("收货人不能为空！");
                this.txtRecipientName.Focus();
                return;
            }
            var recipientPhone = this.txtRecipientPhone.Text.Trim();
            long tmp;
            if (recipientPhone.Length != 11 || !long.TryParse(recipientPhone, out tmp))
            {
                MessageBox.Show("手机号无效！");
                this.txtRecipientPhone.Focus();
                return;
            }
            var province = this.txtProvince.Text.Trim();
            if (province.Length < 1)
            {
                MessageBox.Show("所在省不能为空！");
                this.txtProvince.Focus();
                return;
            }
            var city = this.txtCity.Text.Trim();
            if (city.Length < 1)
            {
                MessageBox.Show("所在城市不能为空！");
                this.txtCity.Focus();
                return;
            }
            var streetAddr = this.txtStreetAddress.Text.Trim();
            if (streetAddr.Length < 1)
            {
                MessageBox.Show("收货地址不能为空！");
                this.txtStreetAddress.Focus();
                return;
            }
            var houseNum = this.txtHouseNum.Text.Trim();
            //if (houseNum.Length < 1)
            //{
            //    MessageBox.Show("门牌号不能为空！");
            //    this.txtHouseNum.Focus();
            //    return;
            //}
            var isDefault = this.chbIsDefault.Checked;
            #endregion

            AddressInfo addressInfo = this.oldAddressInfo;
            addressInfo.id = oldAddressInfo.id;
            addressInfo.recipientName = recipientName;
            addressInfo.recipientPhone = recipientPhone;
            addressInfo.province = province;
            addressInfo.city = city;
            addressInfo.streetAddress = streetAddr;
            addressInfo.referAddr = houseNum;
            addressInfo.isDefault = isDefault;

            //保存
            try
            {
                PH.AddOrUpdateAddress(GlobalContext.CurrentCookieString,addressInfo);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 选择省
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectProvince_Click(object sender, EventArgs e)
        {
            List<ProvinceInfo> list = null;
            try
            {
                list = GlobalContext.PH.GetAllProvinces();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取省列表失败，" + ex.Message);
                return;
            }

            var frm = new FrmSelectProvince(list);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            this.oldAddressInfo.province = frm.ProvinceInfo.provinceName;
            this.oldAddressInfo.provinceCode = frm.ProvinceInfo.provinceCode;
            this.txtProvince.Text = this.oldAddressInfo.province;
        }

        /// <summary>
        /// 选择市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCity_Click(object sender, EventArgs e)
        {
            List<CityInfo> cities = null;
            try
            {
                if (StringTool.IsNullOrWhitespace(this.oldAddressInfo.province) ||
                    StringTool.IsNullOrWhitespace(this.oldAddressInfo.provinceCode))
                {
                    cities = GlobalContext.PH.GetAllCities();
                }
                else
                {
                    cities = GlobalContext.PH.GetAllCitiesByProvinceCode(this.oldAddressInfo.provinceCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取城市列表失败，" + ex.Message);
                return;
            }

            var frm = new FrmSelectCity(cities);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            this.oldAddressInfo.city = frm.SelectedCityInfo.cityName;
            this.oldAddressInfo.cityCode = frm.SelectedCityInfo.cityCode;
            this.oldAddressInfo.provinceCode = frm.SelectedCityInfo.provinceCode;
            this.txtCity.Text = this.oldAddressInfo.city;
        }


        /// <summary>
        /// 选择街道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectStreet_Click(object sender, EventArgs e)
        {
            var frm = new FrmLocation(this.oldAddressInfo.city);
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            this.oldAddressInfo.longitude = frm.Longitude;
            this.oldAddressInfo.latitude = frm.Latitude;
            this.oldAddressInfo.streetAddress = frm.DetailAddress;
            this.txtStreetAddress.Text = frm.DetailAddress;
            this.txtStreetAddress.ReadOnly = false;
        }
    }
}
