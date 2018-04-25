using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 抽奖项信息
    /// </summary>
    public class PajkPrizeItemInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public int id;
        /// <summary>
        /// 名称
        /// </summary>
        public string name;
        /// <summary>
        /// 花费幸福金
        /// </summary>
        public double costGold;
    }

    public class PajkPrizeInfo
    {
        public List<PajkPrizeItemInfo> prizes = new List<PajkPrizeItemInfo>();
    }
}
