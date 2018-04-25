using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 步步夺宝信息
    /// </summary>
    public class PajkGetDepotResult
    {
        public string count;
        public PajkGetDepotResultItem[] depotItems;
    }

    /// <summary>
    /// 步步夺宝单项信息
    /// </summary>
    public class PajkGetDepotResultItem
    {
        [JsonProperty("spuType")]
        public int SpuType { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("spuSubType")]
        public int SpuSubType { get; set; }

        [JsonProperty("forwardDescription")]
        public string ForwardDescription { get; set; }

        [JsonProperty("forwardLinkUrl")]
        public string ForwardLinkUrl { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [JsonProperty("spuId")]
        public int SpuId { get; set; }

        [JsonProperty("skuId")]
        public int SkuId { get; set; }

        [JsonProperty("origPrice")]
        public int OrigPrice { get; set; }

        /// <summary>
        /// 价格，单位：0.01健康金
        /// </summary>
        [JsonProperty("priceGold")]
        public int PriceGold { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("spuTitle")]
        public string SpuTitle { get; set; }

        /// <summary>
        /// 需要碎片个数
        /// </summary>
        [JsonProperty("needNum")]
        public int NeedNum { get; set; }

        /// <summary>
        /// 已集齐的碎片个数
        /// </summary>
        [JsonProperty("ownNum")]
        public int OwnNum { get; set; }
    }
}
