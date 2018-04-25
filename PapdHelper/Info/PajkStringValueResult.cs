using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    public class PajkStringValueResult : PajkValueResult<String>
    {
    }

    public class PajkBooleanValueResult : PajkValueResult<Boolean>
    {
    }

    public class PajkValueResult<T>
    {
        [JsonProperty("value")]
        public T Value;
    }
}
