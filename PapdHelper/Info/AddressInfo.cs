using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 收货地址信息
    /// </summary>
    public class AddressInfo
    {
        public string streetAddress { get; set; }
        public string referAddr { get; set; }
        public string provinceCode { get; set; }
        public string cityCode { get; set; }
        public string city { get; set; }
        /// <summary>
        /// id为0时，表示新增；否则按id进行更新
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 收货人手机号
        /// </summary>
        public string recipientPhone { get; set; }
        public string districtCode { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string recipientName { get; set; }
        public bool isDefault { get; set; }
        public long userId { get; set; }
        public string province { get; set; }
        public string bizType { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string district { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}",
                this.recipientName,
                this.recipientPhone,
                this.streetAddress);
        }
    }

    public class AddressInfoLite
    {
        /// <summary>
        /// 地址ID
        /// </summary>
        public long id { get; set; }

        public string bizType = "mall";

        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string streetAddress { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string recipientName { get; set; }

        /// <summary>
        /// 收件人手机号
        /// </summary>
        public string recipientPhone { get; set; }

        /// <summary>
        /// 是否为默认收货地址
        /// </summary>
        public bool isDefault { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public long longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public long latitude { get; set; }

        /// <summary>
        /// 楼层，门牌号等收货地址
        /// </summary>
        public string referAddr { get; set; }
    }

    public class AddressInfoList2
    {
        public string detail;
        public string area;
        public string name;
        public string province;
        public long addressId;
        public string city;
        public string mobile;

        public override string ToString()
        {
            return string.Format("收件人：{0};收货地址：{1};收件人手机号：{2}",
                this.name,
                this.detail,
                this.mobile);
        }
    }
}
