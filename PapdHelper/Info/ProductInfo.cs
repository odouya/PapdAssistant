using System.Runtime.Serialization;

namespace PapdLib.Info
{
    /// <summary>
    /// 商品接口
    /// </summary>
    public interface IProductInfo
    {
        int healthGold { get; set; }//健康金可抵
        int price { get; set; }//价格
        bool exchange { get; }//是否可兑换
        string name { get; set; }//商品名称
        long id { get; set; }//商品id
        long storeId { get; set; }//商店id
        bool IsFullHealthGoldProduct { get;}//是否为健康金全额兑换商品
        string ToString();
        bool IsMobileRechargeProduct { get; }
    }

    /// <summary>
    /// 商品信息(旧)
    /// </summary>
    public class OldProductInfo : IProductInfo
    {
        /*
         *  "isPrescribed": 0,
            "healthGoldDeductibleAmount": 1000,
            "isPrice": 0,
            "picture": "T1LQJ_BsKv1RCvBVdK",
            "available": 1,
            "directPrice": 1000,
            "discount": 0,
            "isShowDiscount": 0,
            "id": 78557,
            "price": 1000,
            "isDiscount": 0,
            "name": "【电子券】健康商城10元通用优惠券",
            "drugId": 0,
            "merchantId": 0,
            "referId": 0,
            "storeId": "8905240509" 
         */
        public int isPrescribed;
        //健康金可抵（单位：0.01元）
        public int healthGold { get; set; }
        public int isPrice;
        //商品图片
        public string img;
        //是否可兑换
        public int available;
        public int directPrice;
        public int discount { get; set; }
        public int isShowDiscount { get; set; }
        //商品ID
        public long id { get; set; }
        //价格（单位：0.01元）
        public int price { get; set; }
        public int isDiscount;
        //名称
        public string name { get; set; }
        public int drugId;
        public int merchantId;
        public int referId;
        //商店id
        public long storeId { get; set; }

        /// <summary>
        /// 获取商品图片URL
        /// </summary>
        /// <returns></returns>
        public string GetProductImageUrl()
        {
            return PapdHelper.GetImageUrl(this.img);
        }

        /// <summary>
        /// 获取商品详情URL
        /// </summary>
        /// <returns></returns>
        public string GetProductDetailUrl()
        {
            return PapdHelper.GetProductDetailUrl(this.id, this.storeId);
        }

        /// <summary>
        /// 是否为健康金全额兑换商品
        /// </summary>
        public bool IsFullHealthGoldProduct
        {
            get { return this.healthGold >= this.price; }
        }

        public override string ToString()
        {
            return this.name;
        }

        public bool exchange
        {
            get { return this.available!=0; } 
        }


        public bool IsMobileRechargeProduct
        {
            get { return name.Contains("手机话费"); }
        }
    }

    /// <summary>
    /// 商品信息（新）
    /// </summary>
    public class ProductInfo : IProductInfo
    {
        //价格（单位：0.01元）
        public int price { get; set; }
        //健康金可抵（单位：0.01元）
        public int healthGoldDeductibleAmount;
        //原价
        public int origPrice;
        //库存量
        public int available;
        //商品ID
        public long id { get; set; }
        //名称
        public string title;
        //商店ID
        public long storeId { get; set; }
        //商品图片
        public string picture;

        /// <summary>
        /// 获取商品图片URL
        /// </summary>
        /// <returns></returns>
        public string GetProductImageUrl()
        {
            return PapdHelper.GetImageUrl(this.picture);
        }

        /// <summary>
        /// 获取商品详情URL
        /// </summary>
        /// <returns></returns>
        public string GetProductDetailUrl()
        {
            return PapdHelper.GetProductDetailUrl(this.id, this.storeId);
        }

        /// <summary>
        /// 是否为健康金全额兑换商品
        /// </summary>
        public bool IsFullHealthGoldProduct
        {
            get { return this.healthGoldDeductibleAmount >= this.price; }
        }

        public override string ToString()
        {
            return this.title;
        }

        public int healthGold
        {
            get { return this.healthGoldDeductibleAmount; }
            set { this.healthGoldDeductibleAmount = value; }
        }

        public bool exchange
        {
            get { return available > 0; }
        }

        public string name
        {
            get { return this.title; }
            set { this.title = value; }
        }


        public bool IsMobileRechargeProduct
        {
            get { return name.Contains("手机话费"); }
        }
    }
}
