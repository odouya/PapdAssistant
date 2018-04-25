using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 步步招财返回结果
    /// </summary>
    public class PlayBBZCResult
    {
        /// <summary>
        /// 当前余额
        /// </summary>
        public float amount;

        /// <summary>
        /// 奖励金额
        /// </summary>
        public float money;

        /// <summary>
        /// 奖励倍数
        /// </summary>
        public int multiple;

        /// <summary>
        /// 奖励等级
        /// </summary>
        public string prizeLevel;
    }
}
