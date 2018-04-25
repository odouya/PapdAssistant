using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 更新UserToken和WebToken返回结果
    /// </summary>
    public class PajkRenewTkAndWtkResult
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("uid")]
        public string Uid;

        /// <summary>
        /// 失效日期(Unix 毫秒)
        /// </summary>
        [JsonProperty("expire")]
        public long Expire;

        /// <summary>
        /// 锁定次数
        /// </summary>
        [JsonProperty("lockTime")]
        public int LockTime;

        /// <summary>
        /// WebToken
        /// </summary>
        [JsonProperty("webToken")]
        public string WebToken;

        /// <summary>
        /// ChannelId
        /// </summary>
        [JsonProperty("channelId")]
        public int ChannelId;

        /// <summary>
        /// UserToken
        /// </summary>
        [JsonProperty("token")]
        public string Token;

        /// <summary>
        /// 是否新注册
        /// </summary>
        [JsonProperty("newlyReg")]
        public bool NewlyReg;

        public DateTime GetExpireTime()
        {
            return PapdHelper.ConvertFromUnixTime(this.Expire);
        }
    }
}
