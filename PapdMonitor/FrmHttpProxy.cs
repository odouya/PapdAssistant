using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Fiddler;
using Newtonsoft.Json;
using PapdLib.Info;
using PapdLib.Util;
using PapdMonitor.Properties;

namespace PapdMonitor
{
    public partial class FrmHttpProxy : FrmBase
    {
        private HttpListener _listener = null;
        private int _port = 8888;
        private Dictionary<string,string> _userDic = new Dictionary<string, string>(); 
        public string Cookie { get; private set; }
        private bool _stopNeeded = false;
        private int _fetchCount = 0;

        public FrmHttpProxy()
        {
            InitializeComponent();
        }

        private void FrmHttpProxy_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void FrmHttpProxy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private bool isStartOk = false;
        private void Start()
        {
            // 启动代理
            isStartOk = true;
            try
            {
                Fiddler.FiddlerApplication.OnNotification += delegate(object sender, NotificationEventArgs oNEA) 
                { 
                    Console.WriteLine("** NotifyUser: " + oNEA.NotifyString);
                    if (oNEA.NotifyString.Contains("Unable to bind to port"))
                    {
                        MsgBox.ShowInfo("Cookie抓取服务启动失败，请关闭其他代理！");
                        base.SetControlText(this.toolStripStatusLabel1, "");
                        isStartOk = false;
                    }
                };
                Fiddler.FiddlerApplication.Log.OnLogString += delegate(object sender, LogEventArgs oLEA) { Console.WriteLine("** LogString: " + oLEA.LogString); };
                Fiddler.FiddlerApplication.Startup(_port, false, false, true);
            }
            catch (Exception ex)
            {
                isStartOk = false;
                MsgBox.ShowInfo("Cookie抓取服务启动失败，" + ex.Message);
            }
            if (!isStartOk) return;

            // 获取本机ip
            List<string> ips = GetIPAddressV4();
            base.SetControlText(this.toolStripStatusLabel1, "Cookie抓取服务已启动！");
            base.SetControlText(this.textBox1, ips.Find(match => match.StartsWith("192.")) ?? ips[0]);
            base.SetControlText(this.textBox2, _port.ToString());

            // 捕获请求
            Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oSession)
            {
                oSession.bBufferResponse = true;
                base.SetControlText(this.toolStripStatusLabel3, "已抓取" + (++_fetchCount) + " 个数据包");

                string url = oSession.fullUrl;
                string body = oSession.GetRequestBodyAsString();
                Console.WriteLine(url);
                Console.WriteLine(body);

                // 获取cookie并处理
                string cookie = oSession.RequestHeaders[HttpRequestHeader.Cookie.ToString()];
                Console.WriteLine(cookie);
                HandleCookie(cookie);
            };

            // 捕获响应
            Fiddler.FiddlerApplication.BeforeResponse += delegate(Session session)
            {
                session.utilDecodeResponse();
                string requestBody = session.GetRequestBodyAsString();

                // 屏蔽更新请求
                if (requestBody != null && requestBody.Contains("sims.checkAppUpgrade"))
                {
                    var result = JsonConvert.DeserializeObject<PajkResultList<PajkCheckUpdateResult>>(
                        session.GetResponseBodyAsString());
                    result.Content = new List<PajkCheckUpdateResult>();
                    //result.Content.Add(new PajkCheckUpdateResult(){forceUpgrade = false});

                    string responseBody = JsonConvert.SerializeObject(result);
                    session.ResponseBody = System.Text.Encoding.UTF8.GetBytes(responseBody);
                }
            };
        }

        private void Stop()
        {
            try
            {
                // 关闭代理
                Fiddler.FiddlerApplication.Shutdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine("代理关闭异常：" + ex.Message);
            }
        }

        private void HandleCookie(string cookieString)
        {
            if (cookieString == null)
                return;

            string userToken = CookieUtil.GetCookieValue(cookieString, "_tk", false);
            string webToken = CookieUtil.GetCookieValue(cookieString, "_wtk", false);
            if (userToken != null)
            {
                AddCookie(userToken, webToken);
            }
        }

        private void HandleCookie(CookieCollection cookieCollection)
        {
            if (cookieCollection == null)
                return;

            string userToken = CookieUtil.GetCookieValue(cookieCollection, "_tk", false);
            string webToken = CookieUtil.GetCookieValue(cookieCollection, "_wtk", false);
            if (userToken != null)
            {
                AddCookie(userToken, webToken);
            }
        }

        private void Start2()
        {
            new Thread(() =>
            {
                try
                {
                    // 创建监听器.
                    _listener = new HttpListener();
                    // 增加监听的前缀
                    List<string> ips = GetIPAddressV4();
                    if (ips.Count < 1)
                    {
                        throw new Exception("获取IP地址失败");
                    }
                    foreach (string ip in ips)
                    {
                        _listener.Prefixes.Add(string.Format("http://{0}:{1}/", ip, _port)); // 注意前缀必须以 / 正斜杠结尾

                    }
                    // 开始监听
                    _listener.Start();
                    base.SetControlText(this.toolStripStatusLabel1, "Cookie抓取服务已启动！");
                    base.SetControlText(this.textBox1, ips.Find(match=>match.StartsWith("192."))?? ips[0]);
                    base.SetControlText(this.textBox2, _port.ToString());
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInfo("Cookie抓取服务启动失败，" + ex.Message);
                    base.SetControlText(this.toolStripStatusLabel1, "Cookie抓取服务启动失败！");
                    return;
                }
                while (true)
                {
                    try
                    {
                        // 阻塞直到请求到来
                        HttpListenerContext context = _listener.GetContext();
                        base.SetControlText(this.toolStripStatusLabel3, "已抓取" + (++_fetchCount) + " 个数据包");
                        // 获取请求
                        HttpListenerRequest request = context.Request;
                        Console.WriteLine(request.HttpMethod + ":" + request.RawUrl);
                        HandleCookie(request.Cookies);
                        // 取得回应对象
                        HttpListenerResponse response = context.Response;
                        // 构造回应内容
                        string responseString
                            = @"<html>
            <head><title></title></head>
            <body><h1>Hello, world.</h1></body>
        </html>";
                        // 设置回应头部内容，长度，编码
                        response.ContentLength64
                            = System.Text.Encoding.UTF8.GetByteCount(responseString);
                        response.ContentType = "text/html; charset=UTF-8";
                        // 输出回应内容
                        System.IO.Stream output = response.OutputStream;
                        System.IO.StreamWriter writer = new System.IO.StreamWriter(output);
                        writer.Write(responseString);
                        // 必须关闭输出流
                        writer.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("数据抓取发生错误：" + ex.Message + "\r\n" + ex.StackTrace);
                    }

                    if (_stopNeeded)
                        break;
                }
            }) { IsBackground = true }.Start();
        }

        private void Stop2()
        {
            _stopNeeded = true;
            try
            {
                if (_listener != null)
                {
                    _listener.Stop();
                    _listener = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("停止代理服务发生异常：" + ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private List<string> GetIPAddressV4()
        {
            List<string> list = new List<string>();

            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ip in ips)
            {
                if (ip.AddressFamily != AddressFamily.InterNetwork)
                    continue;

                list.Add(ip.ToString());
            }

            return list;
        }

        private void AddCookie(string userToken, string webToken)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string>(AddCookie), userToken, webToken);
                return;
            }

            if (_userDic.ContainsKey(userToken))
                return;
            _userDic.Add(userToken, webToken);

            this.dataGridView1.Rows.Add(new object[]
            {
                this.dataGridView1.Rows.Count + 1,
                string.Format("_tk={0};_wtk={1}", userToken, webToken??"1"),
                "无",
                webToken==null?"使用此Cookie(仅UserToken)" : "使用此Cookie"
            });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.Cookie = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void linkLabelShutdownFirewall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Thread(() =>
            {
                base.SetControlEnabled(this.linkLabelShutdownFirewall,false);
                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.Start();
                    var writer = p.StandardInput;
                    writer.WriteLine("netsh firewall set opmode disable");
                    writer.Close();
                    var reader = p.StandardOutput;
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    reader.Close();
                    if (result.Contains("成功") || result.Contains("已弃用"))
                    {
                        MsgBox.ShowInfo("已关闭防火墙！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MsgBox.ShowInfo("关闭防火墙失败！");
                }
                base.SetControlEnabled(this.linkLabelShutdownFirewall,true);
            }){IsBackground = true}.Start();
        }

        private void linkLabelMobileManualProxy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //new FrmViewPic(this.imageList1).ShowDialog();
            new FrmViewPic(Resources.mobile_proxy){Size = new Size(403,678)}.ShowDialog();
        }
    }
}
