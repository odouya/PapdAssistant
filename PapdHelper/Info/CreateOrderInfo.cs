using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 创建订单信息
    /// </summary>
    public class CreateOrderInfo
    {
        //商家ID
        public long sellerId;
        //商店ID
        public long storeId;
        public SkuInfo[] skus = new SkuInfo[0];
        public SpecInfo[] specs = new SpecInfo[0];
        public RuleInfo[] rules = new RuleInfo[0];
        //邮费
        public int postFee;
        //真实邮费
        public int actualPostFee;
    }

    /// <summary>
    /// 子商品信息
    /// </summary>
    public class SkuInfo
    {
        //子商品ID
        public long skuId;
        //件数
        public int piece;
        //u.7-子商品ID
        public string trace = string.Empty;
        public int promPrice;
        public RuleInfo[] rules = new RuleInfo[0];
    }

    /// <summary>
    /// 规则信息
    /// </summary>
    public class RuleInfo
    {
        
    }

    /// <summary>
    /// 规格信息
    /// </summary>
    public class SpecInfo
    {
        
    }
}
