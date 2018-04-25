using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 邀请码信息
    /// </summary>
    public class InviteCodeInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long useId { get; set; }

        /// <summary>
        /// 二维码图片URL
        /// </summary>
        public string QRCodeUrl { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public string inviteCode { get; set; }
    }
}
