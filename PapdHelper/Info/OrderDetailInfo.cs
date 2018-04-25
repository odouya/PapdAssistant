using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class OrderDetailInfo
    {
        public OrderInfoEx tradeOrder;
        public AddressInfoList2 address;
        public InvoiceInfo invoice;
        public ButtonStatusInfo buttonStatus;

        public bool IsNeedAddress()
        {
            return this.tradeOrder.tradeExtMaps.Length == 0;
        }
    }

    public class OrderInfoEx : OrderInfo
    {
        public TradeExtMap[] tradeExtMaps = new TradeExtMap[0];
    }

    public class TradeExtMap
    {
        public string key;
        public string value;
    }
}
