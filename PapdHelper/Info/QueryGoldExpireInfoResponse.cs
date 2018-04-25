using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class QueryGoldExpireInfoResponse
    {
        public QueryGoldExpireInfoResponseItem pcValidityResult;
    }

    public class QueryGoldExpireInfoResponseItem
    {
        public int amount;
        public string validityEndDate;
    }
}
