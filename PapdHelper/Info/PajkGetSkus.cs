using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 根据商品id获取商品信息
    /// </summary>
    public class PajkGetSkus
    {
        [JsonProperty("recipeSkuDTOs")]
        public RecipeSkuDTO[] RecipeSkuDTOs { get; set; }
    }

    public class RecipeSkuDTO
    {
        /// <summary>
        /// 规格描述
        /// </summary>
        [JsonProperty("spec")]
        public string Spec { get; set; }

        [JsonProperty("isPrescribed")]
        public int IsPrescribed { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        [JsonProperty("img")]
        public string Img { get; set; }

        /// <summary>
        /// 原价
        /// </summary>
        [JsonProperty("origPrice")]
        public int OrigPrice { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [JsonProperty("skuId")]
        public int SkuId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
        [JsonProperty("storeName")]
        public string StoreName { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("spuSpecs")]
        public SpuSpec[] SpuSpecs { get; set; }

        [JsonProperty("spuId")]
        public int SpuId { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        [JsonProperty("sellerName")]
        public string SellerName { get; set; }

        /// <summary>
        /// 剩余库存
        /// </summary>
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("serviceContent")]
        public string ServiceContent { get; set; }

        [JsonProperty("isReceipt")]
        public bool IsReceipt { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("subType")]
        public int SubType { get; set; }

        /// <summary>
        /// 商家id
        /// </summary>
        [JsonProperty("sellerId")]
        public long SellerId { get; set; }

        [JsonProperty("volume")]
        public int Volume { get; set; }

        [JsonProperty("storeType")]
        public string StoreType { get; set; }

        [JsonProperty("factory")]
        public string Factory { get; set; }

        /// <summary>
        /// 商店id
        /// </summary>
        [JsonProperty("storeId")]
        public long StoreId { get; set; }

        [JsonProperty("basePrice")]
        public int BasePrice { get; set; }

        [JsonProperty("orderQty")]
        public int OrderQty { get; set; }
    }

    public class SpuSpec
    {
        [JsonProperty("sortFactor")]
        public int SortFactor { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("spuId")]
        public int SpuId { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
