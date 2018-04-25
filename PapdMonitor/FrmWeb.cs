using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    /// <summary>
    /// 浏览器窗体
    /// </summary>
    public partial class FrmWeb : FrmBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">需要访问的网页</param>
        public FrmWeb(string url)
        {
            InitializeComponent();
            this.webBrowser1.ScriptErrorsSuppressed = true;//屏蔽js脚本错误
            this.webBrowser1.Navigate(url);//打开网页
        }

        /// <summary>
        /// 网页加载完成后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBrowser1.Document == null)
                return;
            Size r = this.webBrowser1.Document.Window.Size;
            Console.WriteLine(r.Width+","+r.Height);
            Console.WriteLine(this.webBrowser1.Document.Body.ScrollRectangle);
            this.Text = this.webBrowser1.DocumentTitle;//将网页标题设为窗体的标题
        }
    }
}
