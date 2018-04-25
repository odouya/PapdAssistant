using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class OrderInfo
    {
        //邮费
        public int postFee { get; set; }
        //创建时间
        public long createTime { get; set; }
        //交易ID
        public string tradeId { get; set; }
        //交易项总费用
        public long tradeItemTotalFee { get; set; }
        //支付时间
        public long payTime { get; set; }
        //订单状态
        public OrderStatus orderStatus { get; set; }
        //购买者ID
        public long buyerId { get; set; }
        //收货时间
        public long reachTime { get; set; }
        //使用的幸福金
        public int useGold { get; set; }
        //订单子项
        public OrderInfoItem[] items { get; set; }
        //商家名称
        public string sellerNick { get; set; }
        //商家ID
        public long sellerId { get; set; }
        //购买者名字
        public string buyerNick { get; set; }
        //业务类型
        public string bizType { get; set; }
        //是否使用信用卡，0否1是
        public int useCredit { get; set; }
        //商店ID
        public long storeId { get; set; }
        //真实的总费用
        public int actualTotalFee { get; set; }
        //外部ID，例如：P994957000414634524396510
        public string outerId { get; set; }
        //订单对应的按钮状态
        public ButtonStatusInfo buttonStatus;

        /// <summary>
        /// 获取订单状态描述信息
        /// </summary>
        /// <returns></returns>
        public string GetOrderStatus()
        {
            string result = string.Empty;
            switch (this.orderStatus)
            {
                case OrderStatus.WAITING_PAY:
                    result = "待付款";
                    break;
                case OrderStatus.WAITING_ACCEPT:
                    result = "待接单";
                    break;
                case OrderStatus.WAITING_DELIVERY:
                    result = "待发货";
                    break;
                case OrderStatus.SHIPPING:
                    result = "已发货";
                    break;
                case OrderStatus.CLOSED:
                    result = "已关闭";
                    break;
                case OrderStatus.CANCEL:
                    result = "已取消";
                    break;
                case OrderStatus.FINISH:
                    result = "已完成";
                    break;
                case OrderStatus.REFUNDING:
                    result = "退款中";
                    break;
                case OrderStatus.PAID:
                    result = "已支付";
                    break;
            }

            return result;
        }
    }

    /// <summary>
    /// 子订单信息
    /// </summary>
    public class OrderInfoItem
    {
        //总数
        public int amount { get; set; }
        //真实价格
        public int actualPrice { get; set; }
        //交易ID
        public string tradeId { get; set; }
        //业务类型
        public string itemType { get; set; }
        //库存ID
        public int itemSkuId { get; set; }
        //子订单ID
        public int itemId { get; set; }
        //子订单类型
        public string itemSubType { get; set; }
        //子订单标题
        public string itemTitle { get; set; }
        //子订单图片
        public string itemPic { get; set; }
    }

    public class ButtonStatusInfo{
        //查看按钮
        public bool viewCardsButton{get;set;}
        public bool buyerLgOrder{get;set;}
        //支付按钮
        public bool payButton{get;set;}
        //确认按钮
        public bool buyerConfirmOrder{get;set;}
        //关闭按钮
        public bool closeButton{get;set;}
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 待付款
        /// </summary>
        WAITING_PAY,

        /// <summary>
        /// 待接单
        /// </summary>
        WAITING_ACCEPT,

        /// <summary>
        /// 待发货
        /// </summary>
        WAITING_DELIVERY,

        /// <summary>
        /// 已发货
        /// </summary>
        SHIPPING,

        /// <summary>
        /// 已关闭
        /// </summary>
        CLOSED,

        /// <summary>
        /// 已取消
        /// </summary>
        CANCEL,

        /// <summary>
        /// 已完成
        /// </summary>
        FINISH,

        /// <summary>
        /// 退款中
        /// </summary>
        REFUNDING,

        /// <summary>
        ///  已支付
        /// </summary>
        PAID,
    }

    /// <summary>
    /// 业务类型
    /// </summary>
    //public enum BizType
    //{
    //    //交易收据
    //    EXCHANGE_VOUCHER,
    //    GENERAL_GOODS_B2C,
    //    GENERAL_GOODS,
    //    CARD,
    //    HEALTH_VIRTUAL_CARD,
    //    EXCHANGE
    //}

    /// <summary>
    /// 订单类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 全部
        /// </summary>
        ALL,

        /// <summary>
        /// 待付款
        /// </summary>
        WAITING_PAY,

        /// <summary>
        /// 进行中
        /// </summary>
        PAID,

        /// <summary>
        /// 已完成
        /// </summary>
        FINISH
    }
}
