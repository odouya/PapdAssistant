using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 获取宝箱结果
    /// </summary>
    public class PajkFetchBoxResult
    {
        [JsonProperty("boxId")]
        public int BoxId { get; set; }

        [JsonProperty("boxGiftList")]
        public BoxGiftItem[] BoxGiftList { get; set; }

        [JsonProperty("boxType")]
        public string BoxType { get; set; }
    }

    /// <summary>
    /// 获取宝箱单项结果
    /// </summary>
    public class BoxGiftItem
    {
        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("giftImg")]
        public string GiftImg { get; set; }

        [JsonProperty("giftType")]
        public string GiftType { get; set; }

        /// <summary>
        /// 宝箱名称
        /// </summary>
        [JsonProperty("giftName")]
        public string GiftName { get; set; }

        [JsonProperty("needNumber")]
        public int NeedNumber { get; set; }

        [JsonProperty("gold")]
        public int Gold { get; set; }

        [JsonProperty("giftNumber")]
        public int GiftNumber { get; set; }

        [JsonProperty("hasNumber")]
        public int HasNumber { get; set; }
    }
}
