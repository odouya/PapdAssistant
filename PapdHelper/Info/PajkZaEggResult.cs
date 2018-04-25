using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 砸蛋结果
    /// </summary>
    public class PajkZaEggResult
    {
        public List<PajkZaEggResultItem> pockets;
        public bool success;
    }

    public class PajkZaEggResultItem
    {
        [JsonProperty("promoId")]
        public int PromoId { get; set; }

        [JsonProperty("days")]
        public int Days { get; set; }

        /// <summary>
        /// 奖励名称
        /// </summary>
        [JsonProperty("rewardName")]
        public string RewardName { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 个数
        /// </summary>
        [JsonProperty("rewardAmount")]
        public int RewardAmount { get; set; }

        [JsonProperty("rewardType")]
        public int RewardType { get; set; }
    }
}
