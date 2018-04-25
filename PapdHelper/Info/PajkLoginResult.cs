using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    public class PajkLoginResult : PajkRenewTkAndWtkResult
    {
        [JsonProperty("channelName")]
        public string ChannelName;
    }
}
