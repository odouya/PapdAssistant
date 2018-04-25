using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib
{
    /// <summary>
    /// 参数集合
    /// </summary>
    public class ParaCollection : Dictionary<string,string>
    {
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            this.Add(key,value,false);
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="isUrlEncodeValue">是否进行Url编码</param>
        public void Add(string key, object value, bool isUrlEncodeValue)
        {
            string encodeValue = value.ToString();
            if (isUrlEncodeValue)
                encodeValue = System.Web.HttpUtility.UrlEncode(encodeValue);

            base.Add(key,encodeValue);
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="pc"></param>
        public void Add(ParaCollection pc)
        {
            if (pc == null)
                return;

            foreach (KeyValuePair<string, string> item in pc)
            {
                this.Add(item.Key, item.Value);
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in this)
            {
                builder.Append(item.Key + "=" + item.Value + "&");
            }
            result = builder.ToString();
            result = result.Substring(0, result.Length - 1);

            return result;
        }
    }
}
