using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 商品详情
    /// </summary>
    public class ProductDetail
    {
        public string detail;
        public ProductDetailSpec[] detailSpecs = new ProductDetailSpec[0];
        //商品图片，多张图片用“|”分割
        public string pictures;
        public string type;
        //商家信息
        public SellerInfo seller;
        public string serviceRedirectUrl;
        public string serviceContent;
        public string level1Key;
        public int levels;
        //商品标题
        public string title;
        public int origPrice;
        //商品价格
        public int price;
        //子商品
        public ProductDetailItem[] items = new ProductDetailItem[0];
        public string subType;
        public string orderQty;
    }

    /// <summary>
    /// 商品详情规格
    /// </summary>
    public class ProductDetailSpec
    {
        //规格名称
        public string name;
        //规格排序
        public int sortFactor;
        //规格值
        public string value;
    }

    /// <summary>
    /// 子商品信息
    /// </summary>
    public class ProductDetailItem
    {
        //健康金可抵扣
        public int healthGoldDeductibleAmount { get; set; }
        //描述信息
        public string level1Spec { get; set; }
        public string level2Spec { get; set; }
        public string level3Spec { get; set; }
        public string level4Spec { get; set; }
        public string level5Spec { get; set; }
        public int levels { get; set; }
        //商品图片地址
        public string pictures { get; set; }
        //库存数
        public int stockNum { get; set; }
        //商店信息
        public StoreStockInfo storeStock { get; set; }
        //商品ID
        public long id { get; set; }
        public int hcodePrice { get; set; }
        //商品价格
        public int price { get; set; }
    }

    /// <summary>
    /// 商店信息
    /// </summary>
    public class StoreStockInfo
    {
        //商店ID
        public long id { get; set; }
        //库存数
        public int stockNum { get; set; }
        //商店名称
        public string name { get; set; }
        //商店类型
        public string type { get; set; }
        //服务规则
        public string serviceRule { get; set; }
    }
}
