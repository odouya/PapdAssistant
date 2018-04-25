using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 我的宝箱详情
    /// </summary>
    public class PajkGetMyBoxDetail : PajkValueResult<List<PajkGetMyBoxDetailItem>>
    {
    }

    /// <summary>
    /// 我的宝箱详情单项
    /// </summary>
    public class PajkGetMyBoxDetailItem
    {
        [JsonProperty("boxGiftList")]
        public BoxGiftItem[] BoxGiftList { get; set; }

        /// <summary>
        /// 获取宝箱时间
        /// </summary>
        [JsonProperty("boxDate")]
        public long BoxDate { get; set; }

        [JsonProperty("boxType")]
        public string BoxType { get; set; }

        /// <summary>
        /// 获取宝箱的方式
        /// </summary>
        [JsonProperty("boxCode")]
        public string BoxCode { get; set; }
    }
}
