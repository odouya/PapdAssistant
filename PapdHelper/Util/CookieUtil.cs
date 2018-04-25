using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PapdLib.Util
{
    /// <summary>
    /// Cookie工具类
    /// </summary>
    public class CookieUtil
    {
        public static string GetCookieValue(string cookie, string key)
        {
            return GetCookieValue(cookie, key, true);
        }

        /// <summary>
        /// 根据key，从cookie中获取对应的value
        /// </summary>
        /// <param name="cookie">cookie字符串</param>
        /// <param name="key">key值</param>
        /// <param name="isDecodeValue"></param>
        /// <returns>返回的对应的value值；如果没有找到，则返回null</returns>
        public static string GetCookieValue(string cookie, string key, bool isDecodeValue)
        {
            var array = cookie.Split(';');
            foreach (var item in array)
            {
                var values = item.Split('=');
                if (values[0].Trim() == key)
                {
                    var value = values[1].Trim();
                    if (value.Contains("%")　&& isDecodeValue)
                    {
                        return HttpUtility.UrlDecode(value);
                    }
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据key，从cookie中获取对应的value
        /// </summary>
        /// <param name="cookieCollection"></param>
        /// <param name="key"></param>
        /// <param name="isDecodeValue"></param>
        /// <returns></returns>
        public static string GetCookieValue(CookieCollection cookieCollection, string key, bool isDecodeValue)
        {
            foreach (Cookie cookie in cookieCollection)
            {
                if (cookie.Name == key)
                {
                    string value = cookie.Value;
                    if (value.Contains("%") && isDecodeValue)
                    {
                        value = HttpUtility.UrlDecode(value);
                    }
                    return value;
                }
            }
            return null;
        }
    }
}
