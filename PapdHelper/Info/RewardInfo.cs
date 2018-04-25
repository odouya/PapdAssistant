using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 奖励信息
    /// </summary>
    public class RewardInfo
    {
        public string preType;
        public int series;
        //当前是否双倍奖励
        public bool isDoubleNowMoney;
        //上次奖励领取状态，RECEIVE或者NOT_RECEIVE
        public string preStatus;
        //上次奖励ID（获取奖励时需要）
        public long preRewardId;
        //上次奖励的健康金
        public string preMoney;
        public long activityId;
        //当前奖励的健康金
        public string nowMoney;
        //上次是否双倍奖励
        public bool isDoublePreMoney;
        public int totalSakTimes;
        public bool flag;
        public string totalSakMoney;
        //用户ID
        public long userId;
        public string fRule;
        //总健康金
        public string totalMoney;
        public string fDesc;

        /// <summary>
        /// 是否领取奖励
        /// </summary>
        /// <returns></returns>
        public bool IsPreMoneyFetch()
        {
            if (this.preStatus == "NOT_RECEIVE")
                return false;
            return true;
        }

        /// <summary>
        /// 计算步数
        /// </summary>
        /// <returns></returns>
        public string CalcStepNumber()
        {
            var money = Convert.ToDouble(this.preMoney);
            if (money.Equals(0d) || money.Equals(0.2d)) // 没有步数或只有起步金
            {
                return "<1000";
            }
            else
            {
                // 前1000步0.3金，之后每2000步0.1金
                if (this.isDoublePreMoney)
                {
                    money /= 2;
                }
                int stepNumber = (int)(1000 + (money - 0.3)/0.1*2000);
                //if (money == 3.0)
                //{
                //    return ">=" +　stepNumber;
                //}
                //return ">=" + stepNumber + "且<" + (stepNumber + 2000);

                return stepNumber + "+";
            }
        }
    }
}
