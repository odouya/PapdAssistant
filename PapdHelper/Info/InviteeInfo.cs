using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 被邀请人信息
    /// </summary>
    public class InviteeInfo
    {
        /// <summary>
        /// 是否已提醒
        /// </summary>
        public int hasRemind { get; set; }

        /// <summary>
        /// 被邀请人状态
        /// </summary>
        public InviteeStatus status { get; set; }

        /// <summary>
        /// 被邀请人昵称
        /// </summary>
        public string nickname{get;set;}

        /// <summary>
        /// 被邀请人ID
        /// </summary>
        public long userId{get;set;}

        /// <summary>
        /// 被邀请人头像
        /// </summary>
        public string avatar { get; set; }


        public int stage { get; set; }

        /// <summary>
        /// 被邀请人手机号
        /// </summary>
        public string mobile { get; set; }
    }

    /// <summary>
    /// 被邀请人状态
    /// </summary>
    public enum InviteeStatus
    {
        /// <summary>
        /// 表示用户还没有登录app领取起步基金，未邀请成功（不会获取邀请奖励）
        /// </summary>
        在路上 = 1,
        /// <summary>
        /// 表示邀请成功（获取邀请奖励）
        /// </summary>
        已邀请 = 2
    }
}
