using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 我的宝箱个数信息
    /// </summary>
    public class PajkGetMyBoxNum
    {
        [JsonProperty("uid")]
        public long Uid { get; set; }

        [JsonProperty("totalBox")]
        public int TotalBox { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("money")]
        public int Money { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}
