using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class RankingInfoLite
    {
        //用户排名
        public int index { get; set; }
        //用户金额（当前金额或总金额）
        public string bonus { get; set; }
        //是否Praise过Ta
        public bool isPraised { get; set; }
        //步数（当前步数或总步数）
        public long steps { get; set; }
        //是否为活动用户
        public bool isActivityUser { get; set; }
        //用户信息
        public UserInfoLite userInfo { get; set; }
        //是否提醒过Ta零钱（是否未领取奖励）
        public bool isBonusAccepted { get; set; }

        /// <summary>
        /// 是否已领取奖励
        /// </summary>
        /// <returns></returns>
        public bool IsBonusFetched()
        {
            return !isBonusAccepted;
        }
    }

    public class GrabGoldInfoLite : RankingInfoLite
    {
        [Obsolete("已过期",true)]
        private string bonus { get; set; }
        public int scope;
        public int status;
        public long fId;//为0时，表示可抢；不为0时，表示已被抢，值为抢金人的id。
        public int angPao;//可抢金额

        public bool IsGrabGoldAvailable()
        {
            return fId == 0;
        }

        public string GetGrabGoldInfo(long userId)
        {
            return GetGrabGoldInfo(userId.ToString());
        }

        public string GetGrabGoldInfo(string userId)
        {
            if (IsGrabGoldAvailable())
            {
                if (IsBonusFetched())
                    return "可抢";
                else
                    return "等待好友领钱";
            }
            else
            {
                if (this.fId.ToString() == userId)
                    return "*我抢的";

                return "来晚了";
            }
        }
    }
}
