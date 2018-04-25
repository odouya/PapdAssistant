using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PapdLib.Util
{
    /// <summary>
    /// 证书工具
    /// </summary>
    public class CertificateUtil
    {
        /// <summary>
        /// 从证书文件中获取私钥和didValue
        /// </summary>
        /// <param name="certFilePath">证书文件路径</param>
        /// <param name="privateKey">私钥值</param>
        /// <param name="didValue">didvalue</param>
        /// <returns></returns>
        public static bool GetPfxPrivateKeyAndDidValue(string certFilePath, out string privateKey, out string didValue)
        {
            privateKey = null;
            didValue = null;

            try
            {
                //打开证书
                var x509 = GetCertObject(certFilePath);
                privateKey = x509.PrivateKey.ToXmlString(true);
                var subjectName = x509.SubjectName.Name;
                var array = subjectName.Split(',');
                foreach (var item in array)
                {
                    var values = item.Split('=');
                    if (values[0].Trim() == "CN")
                    {
                        didValue = values[1].Trim();
                        break;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取证书对象
        /// </summary>
        /// <param name="certFilePath">证书路径</param>
        /// <returns></returns>
        public static X509Certificate2 GetCertObject(string certFilePath)
        {
            System.Security.Cryptography.X509Certificates.X509Certificate2 x509 =
                    new System.Security.Cryptography.X509Certificates.X509Certificate2(certFilePath,
                                PapdHelper.DEFAULT_PFX_PASSWORD,
                                X509KeyStorageFlags.Exportable);

            return x509;
        }

        /// <summary>
        /// 获取证书主题名称
        /// </summary>
        /// <param name="certFilePath">证书路径</param>
        /// <returns></returns>
        public static string GetCertSubjectName(string certFilePath)
        {
            try
            {
                return GetCertObject(certFilePath).SubjectName.Name;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
