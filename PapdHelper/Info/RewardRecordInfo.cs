using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 夺金明细信息
    /// </summary>
    public class RewardRecordInfo
    {
        /// <summary>
        /// 步数
        /// </summary>
        public long totalStep { get; set; }

        /// <summary>
        /// 秒数
        /// </summary>
        public string summary { get; set; }

        public int activity { get; set; }
        public RewardStatus rewardStatus { get; set; }
        public long userId { get; set; }
        public string money { get; set; }

        /// <summary>
        /// 时间线
        /// </summary>
        public long timeLine { get; set; }
        public string type { get; set; }
        /// <summary>
        /// 奖励类型
        /// </summary>
        public RewardType rewardType { get; set; }
        /// <summary>
        /// 奖励时间
        /// </summary>
        public long rewardDate { get; set; }

        /// <summary>
        /// 获取奖励时间
        /// </summary>
        public bool isDouble { get; set; }

        public override string ToString()
        {
            return this.summary;
            //if (this.rewardType == RewardType.STEP_REWARD)
            //{
            //    var localTime = PapdHelper.ConvertFromUnixTime(this.rewardDate);

            //    return string.Format("{0}月{1}日走了{2}步，奖励{3}元，{4}翻倍",
            //                                localTime.Month.ToString("00"),
            //                                localTime.Day.ToString("00"),
            //                                this.totalStep,
            //                                this.money,
            //                                this.isDouble ? "已" : "未"); 
            //}
            //else
            //{
            //    return this.summary;
            //}
        }

        /// <summary>
        /// 获取奖励状态描述
        /// </summary>
        /// <returns></returns>
        public string GetRewardStatusDescription()
        {
            switch (this.rewardStatus)
            {
                case RewardStatus.GRANTED:
                    return "已领取";
                case RewardStatus.RECEIVED:
                    return "发放中";
                case RewardStatus.CANCEL:
                    return "已取消";
                default:
                    return "未知类型：" + this.rewardType;
            }
        }
    }

    /// <summary>
    /// 奖励状态
    /// </summary>
    public enum RewardStatus
    {
        /// <summary>
        /// 已领取
        /// </summary>
        GRANTED,

        /// <summary>
        /// 发放中
        /// </summary>
        RECEIVED,

        /// <summary>
        /// 已取消
        /// </summary>
        CANCEL
    }

    /// <summary>
    /// 奖励类型
    /// </summary>
    public enum RewardType
    {
        /// <summary>
        /// 走步奖励
        /// </summary>
        STEP_REWARD,

        /// <summary>
        /// 邀请奖励
        /// </summary>
        INVITE_REWARD,

        /// <summary>
        /// 活动期间邀请首个好友
        /// </summary>
        CJ_INVITE_REWARD,

        /// <summary>
        /// 参与活动首日,领取“起步基金”0.2元
        /// </summary>
        BASE_REWARD,

        /// <summary>
        /// 抢好友健康金
        /// </summary>
        GRAB_STEP_REWARD
    }
}
