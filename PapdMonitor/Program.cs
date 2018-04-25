using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using PapdLib;
using PapdLib.Info;
using PapdLib.Util;
using System.Net;
using System.Net.Sockets;
using PapdMonitor.Util;

namespace PapdMonitor
{
    static class Program
    {
        #region 应用程序的主入口点
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AntiCode.Init();
            if (args.Length == 1 && args[0] == "vcodesvr")
            {
                TestVCode();
                return;
            }
            SetWorkingDirectory();
            SetGlobalExcptionHandler();
            ReadConfig();
            HandleArgs(args);
            ReleaseMapResources();
            StartMainForm();
        }
        #endregion

        static void TestVCode()
        {
            ConsoleHelper.Init();
            Console.Title = "Papd验证码服务";
            HttpListener _listener;
            List<string> ipList =
                Dns.GetHostAddresses(Dns.GetHostName())
                    .ToList()
                    .FindAll(m => m.AddressFamily == AddressFamily.InterNetwork)
                    .Select(s => s.ToString())
                    .ToList();
            int port = 9123;
            try
            {
                // 创建监听器.
                _listener = new HttpListener();
                // 开始监听(注意前缀必须以 / 正斜杠结尾)
                ipList.ForEach(a => _listener.Prefixes.Add(string.Format("http://{0}:{1}/", a, port)));
                _listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务开启失败，" + ex.Message);
                return;
            }
            Console.WriteLine("服务开启成功：");
            ipList.ForEach(a => Console.WriteLine("{0}:{1}", a, port));
            byte[] data = null;
            while (true)
            {
                try
                {
                    // 阻塞直到请求到来
                    HttpListenerContext context = _listener.GetContext();
                    Console.WriteLine("接收到请求：" + context.Request.RawUrl);
                    // 获取请求
                    HttpListenerRequest request = context.Request;
                    // 取得回应对象
                    HttpListenerResponse response = context.Response;
                    // 设置回应头部内容，长度，编码
                    response.ContentType = "image/png";
                    // 输出回应内容
                    data = GlobalContext.PH.GetVerifyCodeInByteArray("");
                    System.IO.Stream output = response.OutputStream;
                    output.Write(data,0,data.Length);
                    output.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void Test()
        {
            string did, privateKey;
            var result = CertificateUtil.GetPfxPrivateKeyAndDidValue(@"C:\Users\Administrator\Desktop\pfx\weibo\api.jk.cn(2).pfx",
                out privateKey, out did);

            if (result)
            {
                ParaCollection pc = new ParaCollection();
                pc.Add("_did", did);
                pc.Add("_dtk", "Ly/4WjYKFOqZuYtY739SvsOkR73FUuy6heTKB3lm/T6xYBYhnXcRBvkvZ/WEQFEX2yN3F4+x3uvsDuSs/nnij+SSeH2JLTMYhMnLaa8Crc4kGWvZHbuRSK/whrQ2ceCRdKSGVm3PfamQQ9MPBh/r4AvM9wt5Paduw+FxxT+6mH60vlSU7utJV4xDuuBByvAi/cYU6hAqwxYTDMv3tOS3V6qm0LhlRxJHExMGrPgzCIqctsspemin04iurHDOkG30x+VN0CkuWdcpk7PsBQVIQA==", true);
                pc.Add("_mt", "user.weiboLogin");
                pc.Add("_chl", "MZSD");
                pc.Add("accessToken", "2.00vpN7TBvqH7EDbd3ddc819a7Xdi2C");
                pc.Add("_sm", "rsa");
                pc.Add("_aid", "1");
                pc.Add("_vc", "30803");
                pc.Add("_ft", "json");

                //pc.Add("_did", did);
                //pc.Add("_mt", "user.getWebUserToken");
                //pc.Add("_uid", "12651160806");
                //pc.Add("_chl", "MZSD");
                //pc.Add("_sm", "rsa");
                //pc.Add("_tk", "KUUKALUWp9fVZCwkLXeJ4SIU1coPRWzcMjqoOj5+/I/SVJn8iplPyatsGiqmfw2kY0J5E/HFPKy6KFQ6zZ3BX8PogJsuLWZHH4J1g7gK4sI6EY6Dur2+fZKAfJqwsmuaZGrfO7tuzmE+JrWo27dbaLUnIQgG77ALu3UvgSSt2mqfHfQCFXnNaKglAuiBUETWptWunj4aasJ4G9ctwC+74Bd4n1d5jxHxjtxXdRUAZDFoawxDfeM8oZZPj4aH9OMwa8Hn2nX2g2O8DvGuDytat11mF6zqzJL52tggonHHRrXX6YxgO9188gNZQUwLXbkoDjKSJ7LlO9XrQ6iPlwiKH90HKvgKzQWhReweynjc73i4rnqVx7gUGV9xfpyXxYi6");
                //pc.Add("_aid", "1");
                //pc.Add("_vc", "30803");
                //pc.Add("_ft", "json");

                var sig = PapdHelper.CalcSig(pc.ToString(),null, privateKey);

                Console.WriteLine(sig); 
            }
        }

        #region 设置工作目录
        /// <summary>
        /// 设置工作目录
        /// </summary>
        private static void SetWorkingDirectory()
        {
            Environment.CurrentDirectory = Application.StartupPath;
        } 
        #endregion

        #region 全局异常处理

        /// <summary>
        /// 安装全局异常处理器
        /// </summary>
        private static void SetGlobalExcptionHandler()
        {
            //捕获全局异常
            System.AppDomain.CurrentDomain.UnhandledException +=
                (sender, args) => ShowException(args.ExceptionObject as Exception, args.ToString());
            Application.ThreadException += (sender, args) => ShowException(args.Exception, args.ToString());
        }

        /// <summary>
        /// 显示异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="backupEx"></param>
        private static void ShowException(Exception ex, string backupEx)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("异常信息：");
            if (ex != null)
            {
                builder.AppendLine(ex.Message);
                builder.AppendLine("调用堆栈：");
                builder.AppendLine(ex.StackTrace);
            }
            else
            {
                builder.AppendLine(backupEx);
            }

            MsgBox.ShowWarnning(builder.ToString());
        }
        #endregion

        #region 读取配置信息
        /// <summary>
        /// 读取配置信息
        /// </summary>
        static void ReadConfig()
        {
            var config = new ConfigStorage(GlobalContext.ConfigFileName);
            ConfigInfo configInfo = config.GetConfigInfo();
            GlobalContext.HistoryCookies = configInfo.HistoryCookies;
            GlobalContext.IsTestMode = configInfo.IsTestMode;
            GlobalContext.CurrentConfigInfo = configInfo;
            PapdHelper.DEFAULT_TIMEOUT = configInfo.RequestTimeoutInSeconds;
        }
        #endregion

        #region 处理程序参数
        /// <summary>
        /// 处理程序参数
        /// </summary>
        /// <param name="args"></param>
        private static void HandleArgs(string[] args)
        {
            if (args.Length == 1 && args[0].StartsWith("/u:"))
            {
                string name = args[0].Substring(3);
                CookieInfo cookieInfoFound = GlobalContext.HistoryCookies.Find(
                    match => match.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
                if (cookieInfoFound != null)
                {
                    var helper = new PapdHelper();
                    var info = helper.QueryRewardInfo(cookieInfoFound.Cookie, 3000);
                    if (!info.IsPreMoneyFetch())
                    {
                        helper.FetchReward(cookieInfoFound.Cookie, info.preRewardId);
                    }
                }
                Environment.Exit(0);
            }
        } 
        #endregion

        #region 释放地图资源文件
        /// <summary>
        /// 释放地图资源文件到
        /// </summary>
        static void ReleaseMapResources()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resNames = assembly.GetManifestResourceNames();
            foreach (var resName in resNames)
            {
                if (resName.Contains("map.htm"))
                {
                    //获取资源文件
                    var stream = assembly.GetManifestResourceStream(resName);
                    var data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);

                    //写入
                    var fileName = Path.GetTempFileName();
                    fileName = fileName.Replace(".tmp", ".htm");
                    File.WriteAllBytes(fileName, data);
                    GlobalContext.MapHtmPath = fileName;
                    break;
                }
            }
        } 
        #endregion

        #region 启动主窗体
        private static void StartMainForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        } 
        #endregion
    }
}
