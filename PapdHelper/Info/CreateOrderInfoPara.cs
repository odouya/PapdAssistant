using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PapdLib.Info
{
    /// <summary>
    /// 创建订单参数
    /// </summary>
    public class CreateOrderInfoPara : CreateOrderInfoParaList
    {
        public int source;
        //消费者信息
        public string custormerInfo = string.Empty;
        //需要充值的手机号
        public string userMobile = string.Empty;
        //是否用现金支付邮费
        public bool useCashOnDelivery = false;
        //发票
        public InvoiceInfo invoice;
        public string callBackUrl = "https://www.jk.cn/yao-h5/index.html#/duojin-paysuccess/{0}";
    }

    /// <summary>
    /// 创建订单参数精简
    /// </summary>
    public class CreateOrderInfoParaList
    {
        //收货地址ID
        public long addressId = 0;
        //是否来自购物车
        public IsType isFromCart = 0;
        //优惠券
        public CouponInfo[] coupons = new CouponInfo[0];
        //是否使用优惠券
        public bool isUseCoupon = false;
        public int orderTag = 0;
        public bool isGiftCard = false;
        //是否使用健康金
        public bool isHealthGold = true;
    }

    /// <summary>
    /// 优惠券信息
    /// </summary>
    public class CouponInfo
    {
        
    }

    /// <summary>
    /// 发票信息
    /// </summary>
    public class InvoiceInfo
    {
        //发票类型
        public InvoiceType type;
        //发票标题
        public string title = string.Empty;
        //发票内容
        public string content = string.Empty;
        //是否需要发票
        public bool isNeed;
    }

    /// <summary>
    /// 发票类型
    /// </summary>
    public enum InvoiceType
    {
        公司=1,
        个人=2
    }
}
