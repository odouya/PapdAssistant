using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 幸福金信息
    /// </summary>
    public class GoldInfo
    {
        /// <summary>
        /// 余额
        /// </summary>
        public double balance { get; set; }

        /// <summary>
        /// 累计金额
        /// </summary>
        public double cumulativeReward { get; set; }

        /// <summary>
        /// 邀请奖励
        /// </summary>
        public double invitationReward { get; set; }

        /// <summary>
        /// 走步奖励
        /// </summary>
        public double stepReward { get; set; }

        public override string ToString()
        {
            return "当前余额：" + this.balance;
        }
    }
}
