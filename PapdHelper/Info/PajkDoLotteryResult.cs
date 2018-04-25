using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class PajkDoLotteryResult
    {
        /// <summary>
        /// 是否抽奖成功
        /// </summary>
        public bool isPrized { get; set; }
        public bool prize { get; set; }
        public bool prized { get; set; }
        /// <summary>
        /// 抽奖成功id
        /// </summary>
        public int winRecordId { get; set; }
    }
}
