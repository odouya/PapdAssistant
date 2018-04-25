using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PapdLib.Info
{
    /// <summary>
    /// 返回结果基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PajkResult<T> where T:new()
    {
        [JsonProperty("stat")]
        public PajkState Stat;
        [JsonProperty("content")]
        public T Content;
    }

    /// <summary>
    /// 返回结果基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PajkResultList<T> : PajkResult<List<T>> where T : new()
    {
        
    }

    /// <summary>
    /// 状态信息
    /// </summary>
    public class PajkState
    {
        [JsonProperty("systime")]
        public long SysTime;
        [JsonProperty("sm")]
        public string SM;
        [JsonProperty("stateList")]
        public List<PajkStateCode> StateList;
        [JsonProperty("data")]
        public long Data;
        [JsonProperty("code")]
        public int Code;
        [JsonProperty("cid")]
        public string Cid;
        [JsonProperty("sig")]
        public string Sig;
    }

    /// <summary>
    /// 状态码信息
    /// </summary>
    public class PajkStateCode
    {
        [JsonProperty("length")]
        public int Length;
        [JsonProperty("code")]
        public int Code;
        [JsonProperty("msg")]
        public string Msg;
    }
}
