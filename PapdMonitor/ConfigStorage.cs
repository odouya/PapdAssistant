using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;
using PapdLib.Util;
using PapdLib;

namespace PapdMonitor
{
    /// <summary>
    /// 配置信息读写操作类
    /// </summary>
    class ConfigStorage
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string fileName { get; set; }

        private static ConfigStorage _instance = null;

        public static ConfigStorage GetInstance()
        {
            if(_instance==null)
                _instance = new ConfigStorage();

            return _instance;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">配置文件路径</param>
        public ConfigStorage(string fileName)
        {
            this.fileName = fileName;
        }

        public ConfigStorage()
            : this(GlobalContext.ConfigFileName)
        {
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public ConfigInfo GetConfigInfo()
        {
            ConfigInfo info = new ConfigInfo();

            info.HistoryCookies = new List<CookieInfo>();
            info.IsTestMode = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);
                XmlNode root = doc.DocumentElement;

                //历史Cookies
                XmlNodeList historyCookieNodes = root.SelectNodes("ItemGroup/Cookie");
                foreach (XmlNode cookieNode in historyCookieNodes)
                {
                    var cookieInfo = new CookieInfo();
                    cookieInfo.Cookie = cookieNode.InnerText.Trim();
                    cookieInfo.Name = GetNodeAttribute(cookieNode, "name", "");
                    var strId = GetNodeAttribute(cookieNode, "id", null);
                    var id = 0l;
                    if (long.TryParse(strId, out id))
                    {
                        cookieInfo.Id = id;
                    }
                    cookieInfo.CertData = GetNodeAttribute(cookieNode, "certData", null);

                    info.HistoryCookies.Add(cookieInfo);
                }

                //是否为测试模式
                XmlNode isTestModeNode = root.SelectSingleNode("PropertyGroup/IsTestMode");
                bool isTestMode;
                if (bool.TryParse(isTestModeNode.InnerText, out isTestMode))
                {
                    info.IsTestMode = isTestMode;
                }

                // 随机步数
                XmlNode randomStepNode = root.SelectSingleNode("PropertyGroup/RandomStep");
                info.RandomMinStep =
                        Convert.ToInt32(GetNodeAttribute(randomStepNode, "min",
                            ConfigInfo.Default_Random_Min_Step.ToString()));
                info.RandomMaxStep =
                    Convert.ToInt32(GetNodeAttribute(randomStepNode, "max",
                        ConfigInfo.Default_Random_Max_Step.ToString()));

                // 请求设置
                XmlNode reqNode = root.SelectSingleNode("PropertyGroup/Request");
                info.RequestTimeoutInSeconds =
                    Convert.ToInt32(GetNodeAttribute(reqNode, "timeout",
                        ConfigInfo.Default_Request_Timeout.ToString()));

                info.IsAutoFetchYesterdayBonus =
                    Convert.ToBoolean(GetNodeValue(
                        root.SelectSingleNode("PropertyGroup/IsAutoFetchYesterdayBonus"), "true"));

                info.IsAutoGrabGold =
                    Convert.ToBoolean(GetNodeValue(
                        root.SelectSingleNode("PropertyGroup/IsAutoGrabGold"), "true"));

                info.IsAutoGrabTreasure =
                    Convert.ToBoolean(GetNodeValue(
                        root.SelectSingleNode("PropertyGroup/IsAutoGrabTreasure"), "false"));

                info.IsAutoUploadWalkData =
                    Convert.ToBoolean(GetNodeValue(
                        root.SelectSingleNode("PropertyGroup/IsAutoUploadWalkData"), "false"));

                info.CreateOrderTimespan =
                    Convert.ToInt32(GetNodeValue(root.SelectSingleNode("PropertyGroup/CreateOrderTimespan"), "false"));
            }
            catch (Exception ex)
            {
                // 修复配置文件不存在时，导致读取的RequestTimeoutInSeconds为0，从而查询接口时超时的bug
                info.RandomMinStep = 30000;
                info.RandomMaxStep = 40000;
                info.IsTestMode = false;
                info.IsAutoFetchYesterdayBonus = true;
                info.IsAutoGrabGold = true;
                info.IsAutoGrabTreasure = true;
                info.IsAutoUploadWalkData = true;
                info.RequestTimeoutInSeconds = 15000;
                info.CreateOrderTimespan = 14;
            }

            return info;
        }

        /// <summary>
        /// 更新配置文件中关于自动相关的设置
        /// </summary>
        /// <param name="info"></param>
        public void UpdateAutoConfigInfo(ConfigInfo info)
        {
            if (!IsFileValid())
                CreateNewFile();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);
                var rootNode = doc.DocumentElement;

                var propertyGroupNode = rootNode.SelectSingleNode("PropertyGroup");

                SetNodeValue(propertyGroupNode, "IsAutoUploadWalkData", info.IsAutoUploadWalkData.ToString());
                SetNodeValue(propertyGroupNode, "IsAutoFetchYesterdayBonus", info.IsAutoFetchYesterdayBonus.ToString());
                SetNodeValue(propertyGroupNode, "IsAutoGrabGold", info.IsAutoGrabGold.ToString());
                SetNodeValue(propertyGroupNode, "IsAutoGrabTreasure", info.IsAutoGrabTreasure.ToString());
                SetNodeValue(propertyGroupNode, "CreateOrderTimespan", info.CreateOrderTimespan.ToString());

                var randomStepNode = SetNodeValue(propertyGroupNode, "RandomStep", "");
                SetNodeAttribute(randomStepNode, "min", info.RandomMinStep);
                SetNodeAttribute(randomStepNode, "max", info.RandomMaxStep);

                doc.Save(this.fileName);
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 更新Cookie信息，不存在时，则新增
        /// </summary>
        /// <param name="info"></param>
        public void UpdateCookieInfo(CookieInfo info)
        {
            // 用户id不能为空
            if (info.Id == null)
            {
                return;
            }

            if (!IsFileValid())
                CreateNewFile();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);

                var rootNode = doc.DocumentElement;
                var cookies = rootNode.SelectNodes("ItemGroup/Cookie");

                XmlNode sameNode = null;
                foreach (XmlNode cookie in cookies)
                {
                    string id = cookie.Attributes["id"].InnerText.Trim();
                    if (id == info.Id.ToString())
                    {
                        //已经存在该账号，则更新
                        sameNode = cookie;
                        break;
                    }
                }
                if (sameNode == null)
                {
                    //不存在该账号，则新增
                    sameNode = doc.CreateElement("Cookie");
                    sameNode.Attributes.Append(doc.CreateAttribute("id"));
                    sameNode.Attributes.Append(doc.CreateAttribute("name"));
                    sameNode.Attributes.Append(doc.CreateAttribute("certData"));
                    var parentNode = rootNode.SelectSingleNode("ItemGroup");
                    parentNode.AppendChild(sameNode);
                }
                if (info.Id != null)
                {
                    SetNodeAttribute(sameNode, "id", info.Id);
                }
                if (!Util.StringTool.IsNullOrWhitespace(info.Name))
                {
                    SetNodeAttribute(sameNode, "name", info.Name);
                }
                if (!Util.StringTool.IsNullOrWhitespace(info.CertData))
                {
                    SetNodeAttribute(sameNode, "certData", info.CertData);
                }
                if (!Util.StringTool.IsNullOrWhitespace(info.Cookie))
                {
                    sameNode.InnerText = info.Cookie;
                }

                doc.Save(this.fileName);
            }
            catch (Exception ex)
            {

            }
        }

        public void ClearUserCert(long userId)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);
                XmlNode root = doc.DocumentElement;

                //历史Cookies
                XmlNodeList historyCookieNodes = root.SelectNodes("ItemGroup/Cookie");
                foreach (XmlNode cookieNode in historyCookieNodes)
                {
                    long temp = 0;
                    if (!long.TryParse(GetNodeAttribute(cookieNode, "id", null), out temp) || temp != userId)
                    {
                        continue;
                    }

                    // 清除Cert属性
                    SetNodeAttribute(cookieNode, "certData", "");
                }

                doc.Save(this.fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public CookieInfo GetCookieInfoByCookieUserToken(string userToken)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);
                XmlNode root = doc.DocumentElement;

                //历史Cookies
                XmlNodeList historyCookieNodes = root.SelectNodes("ItemGroup/Cookie");
                foreach (XmlNode cookieNode in historyCookieNodes)
                {
                    string cookie = cookieNode.InnerText.Trim();
                    string tk = CookieUtil.GetCookieValue(cookie, "_tk");
                    if (!tk.Equals(userToken, StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }

                    return XmlNode2CookieInfo(cookieNode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public CookieInfo GetCookieInfoByUserId(long userId)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);
                XmlNode root = doc.DocumentElement;

                //历史Cookies
                XmlNodeList historyCookieNodes = root.SelectNodes("ItemGroup/Cookie");
                foreach (XmlNode cookieNode in historyCookieNodes)
                {
                    long temp = 0;
                    if (!long.TryParse(GetNodeAttribute(cookieNode, "id", null), out temp) || temp != userId)
                    {
                        continue;
                    }

                    return XmlNode2CookieInfo(cookieNode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private CookieInfo XmlNode2CookieInfo(XmlNode userNode)
        {
            var cookieInfo = new CookieInfo();

            cookieInfo.Cookie = userNode.InnerText;
            cookieInfo.Name = GetNodeAttribute(userNode, "name", "");
            long temp = 0;
            if (long.TryParse(GetNodeAttribute(userNode, "id", null), out temp))
            {
                cookieInfo.Id = temp;
            }
            cookieInfo.CertData = GetNodeAttribute(userNode, "certData", null);
            
            return cookieInfo;
        }

        private string GetNodeAttribute(XmlNode node, string key, string defaultValue)
        {
            if(node==null)
                return defaultValue;

            XmlAttribute attrib = node.Attributes[key];
            if (attrib == null || attrib.Value.Trim().Length<1)
                return defaultValue;

            return attrib.Value;
        }

        private string GetNodeValue(XmlNode node, string defaultValue)
        {
            if (node == null)
                return defaultValue;

            return node.InnerText;
        }

        private XmlNode SetNodeValue(XmlNode parentNode, string childNodeName, string value)
        {
            if (parentNode == null)
                return null;

            var childNode = parentNode.SelectSingleNode(childNodeName);
            if (childNode == null)
            {
                childNode = parentNode.OwnerDocument.CreateElement(childNodeName);
                parentNode.AppendChild(childNode);
            }

            childNode.InnerText = value;

            return childNode;
        }

        private void SetNodeAttribute(XmlNode node, string key, object value)
        {
            if (value == null) // value为空时，移除节点属性
            {
                var attr = node.Attributes[key];
                if (attr != null)
                {
                    node.Attributes.Remove(attr);
                }
                return;
            }
            if (node.Attributes[key] == null) // 节点属性不存在时，则添加
            {
                node.Attributes.Append(node.OwnerDocument.CreateAttribute(key));
            }
            node.Attributes[key].Value = value.ToString();
        }

        /// <summary>
        /// 创建新的配置文件
        /// </summary>
        public void CreateNewFile()
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                builder.AppendLine("<Papd>");
                builder.AppendLine("<PropertyGroup>");
                builder.AppendLine("<IsTestMode>false</IsTestMode>");
                builder.AppendLine(string.Format("<RandomStep min=\"{0}\" max=\"{1}\"/>", ConfigInfo.Default_Random_Min_Step, ConfigInfo.Default_Random_Max_Step));
                builder.AppendLine(string.Format("<Request timeout=\"{0}\"/>", ConfigInfo.Default_Request_Timeout));
                builder.AppendLine("</PropertyGroup>");
                builder.AppendLine("<ItemGroup>");
                builder.AppendLine("</ItemGroup>");
                builder.AppendLine("</Papd>");

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(builder.ToString());
                doc.Save(this.fileName);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 配置文件是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsFileValid()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);

                XmlNode root = doc.DocumentElement;
                if (root.Name != "Papd")
                    return false;
                if (root.SelectSingleNode("ItemGroup") == null)
                    return false;
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除Cookie信息
        /// </summary>
        /// <param name="info">Cookie信息，其中必须设置Name或Cookie属性</param>
        public void RemoveCookieInfo(CookieInfo info)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.fileName);
                XmlNode root = doc.DocumentElement;

                //获取所有Cookie节点
                XmlNodeList cookies = root.SelectNodes("ItemGroup/Cookie");

                //寻找同一Cookie
                XmlNode removeNeededNode = null;
                foreach (XmlNode cookie in cookies)
                {
                    if (cookie.Attributes["name"].Value == info.Name ||
                        cookie.InnerText == info.Cookie)
                    {
                        removeNeededNode = cookie;
                    }
                }
                if (removeNeededNode != null)
                {
                    //删除Cookie
                    removeNeededNode.ParentNode.RemoveChild(removeNeededNode);
                    doc.Save(this.fileName);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
