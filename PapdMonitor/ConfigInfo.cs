using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdMonitor
{
    /// <summary>
    /// Cookie存储信息类
    /// </summary>
    class CookieInfo
    {
        /// <summary>
        /// Id值
        /// </summary>
        public long? Id;

        /// <summary>
        /// Cookie对应的用户名
        /// </summary>
        public string Name;

        /// <summary>
        /// Cookie字符串
        /// </summary>
        public string Cookie;

        /// <summary>
        /// 证书临时路径
        /// </summary>
        public string CertPath
        {
            get 
            {
                return CertData2CertPath(this.CertData); 
            }
            set
            {
                this.CertData = CertPath2CertData(value);
            }
        }

        /// <summary>
        /// 证书文件Base64数据
        /// </summary>
        public string CertData;

        /// <summary>
        /// 将证书数据转换为文件文件
        /// </summary>
        /// <returns></returns>
        public static string CertData2CertPath(string certData)
        {
            try
            {
                // 创建临时证书文件
                string tempCertPath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pfx";
                // 将证书数据写入文件
                byte[] certBytes = Convert.FromBase64String(certData);
                System.IO.File.WriteAllBytes(tempCertPath, certBytes);

                return tempCertPath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 将证书文件转换为证书数据
        /// </summary>
        /// <param name="certPath">证书文件</param>
        /// <returns></returns>
        public static string CertPath2CertData(string certPath)
        {
            try
            {
                byte[] certBytes = System.IO.File.ReadAllBytes(certPath);

                return Convert.ToBase64String(certBytes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// 配置信息类
    /// </summary>
    class ConfigInfo
    {
        /// <summary>
        /// 历史Cookies
        /// </summary>
        public List<CookieInfo> HistoryCookies;

        /// <summary>
        /// 是否为测试模式
        /// </summary>
        public bool IsTestMode = false;

        public int RandomMinStep;

        public int RandomMaxStep;

        public int RequestTimeoutInSeconds;

        public const int Default_Random_Min_Step = 55005;

        public const int Default_Random_Max_Step = 56001;

        public const int Default_Request_Timeout = 8000;

        public bool IsAutoUploadWalkData = false;

        public bool IsAutoFetchYesterdayBonus = true;

        public bool IsAutoGrabGold = true;

        public bool IsAutoGrabTreasure = false;

        /// <summary>
        /// 下单时间间隔，单位：天
        /// </summary>
        public int CreateOrderTimespan = 14;
    }
}
