using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PapdLib;
using PapdLib.Info;

namespace PapdMonitor
{
    class GlobalContext
    {
        public static int LoopDays = 14;

        /// <summary>
        /// 应用程序名称
        /// </summary>
        public const string AppName = "平安好医生助手";

        /// <summary>
        /// 当前Cookie
        /// </summary>
        public static string CurrentCookieString;

        /// <summary>
        /// 当前证书私钥
        /// </summary>
        public static string CurrentPfxPrivateKey;

        /// <summary>
        /// 当前证书数据
        /// </summary>
        private static string CurrentCertData;

        /// <summary>
        /// 当前证书文件路径
        /// </summary>
        public static string CurrentCertPath
        {
            get { return CookieInfo.CertData2CertPath(CurrentCertData); }
            set { CurrentCertData = CookieInfo.CertPath2CertData(value); }
        }


        /// <summary>
        /// 当前用户信息
        /// </summary>
        public static UserInfo CurrentUserInfo;

        #region 配置信息

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string ConfigFileName = System.IO.Path.GetFullPath("config.xml");

        /// <summary>
        /// 是否为测试模式 
        /// </summary>
        public static bool IsTestMode = false;

        /// <summary>
        /// 当前配置信息
        /// </summary>
        public static ConfigInfo CurrentConfigInfo;

        /// <summary>
        /// 历史Cookies
        /// </summary>
        public static List<CookieInfo> HistoryCookies = new List<CookieInfo>();

        /// <summary>
        /// 重新读取配置文件
        /// </summary>
        public static void RereadConfig()
        {
            CurrentConfigInfo = ConfigStorage.GetInstance().GetConfigInfo();
            HistoryCookies = CurrentConfigInfo.HistoryCookies;
            IsTestMode = CurrentConfigInfo.IsTestMode;
        }

        #endregion

        /// <summary>
        /// 声音文件路径
        /// </summary>
        public static string AudioPath = System.IO.Path.GetFullPath("Audio");

        /// <summary>
        /// Map.htm文件路径
        /// </summary>
        public static string MapHtmPath;

        /// <summary>
        /// 当前充值手机号
        /// </summary>
        public static string CurrentRechargePhone;

        /// <summary>
        /// 当前收货地址
        /// </summary>
        public static AddressInfo CurrentAddressInfo;

        /// <summary>
        /// 历史充值手机号
        /// </summary>
        public static List<string> HistoryRechargeMobile = new List<string>(); 

        public static PapdLib.PapdHelper PH = new PapdHelper();

        public static FrmMain MainForm;

        public static void Output(string info)
        {
            if (MainForm != null)
            {
                MainForm.Output(info);
            }
        }

        public static bool IsLogin()
        {
            if (GlobalContext.CurrentCookieString == null ||
                GlobalContext.CurrentCookieString.Trim().Length < 1)
            {
                return false;
            }
            return true;
        }

        public static bool CheckLoginState()
        {
            if (!IsLogin())
            {
                MsgBox.ShowInfo("请先登录！");
                return false;
            }
            return true;
        }

        public static void ClearCurrentUserInfo()
        {
            GlobalContext.CurrentRechargePhone = null;
            GlobalContext.CurrentAddressInfo = null;
            GlobalContext.CurrentPfxPrivateKey = null;
            GlobalContext.CurrentCertPath = null;
            lock (GlobalContext.HistoryRechargeMobile)
            {
                GlobalContext.HistoryRechargeMobile.Clear();
            }
        }
    }
}
