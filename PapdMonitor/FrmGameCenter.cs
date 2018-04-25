using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PapdLib;

namespace PapdMonitor
{
    public partial class FrmGameCenter : Form
    {
        #region 属性和字段

        /// <summary>
        /// 记录游戏Cookie
        /// </summary>
        private string m_gameCookie = null;

        /// <summary>
        /// 记录Cookie
        /// </summary>
        private string m_cookie = null;

        /// <summary>
        /// 输出事件
        /// </summary>
        public event EventHandler<OutputEventArgs> OutputEvent; 
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmGameCenter()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            List<string[]> games = new List<string[]>();
            //games.Add(new string[] { "game_步步竞猜.jpg", "http://wap.pahys.com/?act=zhongchao&isShow=1", "0"});
            //games.Add(new string[] { "game_步步招财.jpg", "http://gc.jk.cn/duojin/slot.html", "0" });
            games.Add(new string[] { "game_步步成名.jpg", "http://wap.pahys.com/?act=game_zcsm", "1" });
            //games.Add(new string[] { "game_步步为赢.jpg", "http://wap.pahys.com/?act=game_sanguo", "0" });
        

            int topoff = 3;
            for(int i=0;i<games.Count;i++)
            {
                var game = games[i];
                var gameImage = game[0];
                var gameUrl = game[1];
                var gameEnabled = game[2] == "1";

                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Transparent;
                pb.Tag = gameUrl;
                pb.Visible = true;
                if (gameEnabled)
                {
                    pb.MouseClick += GamePictureOnClick;
                    pb.BackgroundImage = GetResImage(gameImage);
                }
                else
                {
                    pb.BackgroundImage = ToGrayImage(pb.BackgroundImage);
                }
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Width = this.tabPage1.Width - 30;
                pb.Height = this.tabPage1.Height / 3;
                pb.Anchor = AnchorStyles.Top;
                pb.Left = (this.tabPage1.Width - pb.Width)/2;
                pb.Top = topoff;
                pb.Cursor = Cursors.Hand;
                this.tabPage1.Controls.Add(pb);

                topoff = pb.Bottom + 2;

                this.btnKick.Tag = game[1];
            }

            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;

            this.m_cookie = GlobalContext.CurrentCookieString;
        }

        /// <summary>
        /// 游戏图片点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GamePictureOnClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!GlobalContext.CheckLoginState())
                return;

            string gameUrl = (sender as PictureBox).Tag.ToString();

            //var frmWeb = new FrmWeb(gameUrl);
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    this.m_cookie = GlobalContext.CurrentCookieString;
                    if (gameUrl.Contains("http://wap.pahys.com"))
                    {
                        Output("正在获取游戏Cookie...");
                        this.m_gameCookie = GlobalContext.PH.GetGameCookie(
                                                GlobalContext.CurrentCookieString,
                                                gameUrl);
                        this.m_cookie = this.m_gameCookie;
                    }
                    Output("获取成功，正在打开页面...");
                    PapdHelper.SetIECookie(gameUrl, this.m_cookie);
                    //frmWeb.Show();
                    System.Diagnostics.Process.Start("iexplore.exe", gameUrl);
                    Output("执行成功！");
                }
                catch (Exception ex)
                {
                    Output("执行失败，" + ex.Message);
                    //frmWeb.Dispose();
                }
            });
            
        }

        /// <summary>
        /// 输出函数
        /// </summary>
        /// <param name="info"></param>
        private void Output(string info)
        {
            if (this.OutputEvent != null)
            {
                OutputEventArgs args = new OutputEventArgs();
                args.Info = info;
                this.OutputEvent(this, args);
            }
        }

        /// <summary>
        /// “来一脚”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKick_Click(object sender, EventArgs e)
        {
            if (!GlobalContext.CheckLoginState())
                return;

            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    if (this.m_gameCookie == null ||
                        this.m_cookie != GlobalContext.CurrentCookieString)
                    {
                        Output("正在获取游戏Cookie...");
                        this.m_gameCookie = GlobalContext.PH.GetGameCookie(
                            GlobalContext.CurrentCookieString,
                            this.btnKick.Tag as string);
                        this.m_cookie = GlobalContext.CurrentCookieString;
                    }

                    Output("正在踢球...");
                    var usedAmount = float.Parse(this.comboBox1.Text);
                    var playResult = GlobalContext.PH.PlayBBCM(this.m_gameCookie, usedAmount);
                    var leftAmount = playResult.prizeAmount - usedAmount;
                    Output(string.Format("{0}了 {1} 金！",
                        leftAmount >= 0 ? "赢" : "输",
                        Math.Abs(leftAmount)));
                }
                catch (Exception ex)
                {
                    Output("踢球失败，" + ex.Message);
                }
            });
        }

        /// <summary>
        /// “摇一摇”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShake_Click(object sender, EventArgs e)
        {
            if (!GlobalContext.CheckLoginState())
                return;

            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    Output("正在摇一摇...");
                    var usedAmount = float.Parse(this.comboBox2.Text);
                    var playResult = GlobalContext.PH.PlayBBZC(GlobalContext.CurrentCookieString, usedAmount);
                    var leftAmount = playResult.money - usedAmount;
                    Output(string.Format("{0}了 {1} 金！",
                            leftAmount >= 0 ? "赢" : "输",
                            Math.Abs(leftAmount)));
                }
                catch (Exception ex)
                {
                    Output("摇一摇失败，" + ex.Message);
                }
            });
        }

        #region 图像相关函数

        /// <summary>
        /// 从内嵌资源中获取图像
        /// </summary>
        /// <param name="resName"></param>
        /// <returns></returns>
        private Image GetResImage(string resName)
        {
            System.IO.Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PapdMonitor.Resources." + resName);
            if (stream != null)
            {
                return Image.FromStream(stream);
            }
            return null;
        }

        /// <summary>
        /// 将图片转换为灰色
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private Image ToGrayImage(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pixel = bmp.GetPixel(i, j);
                    int grayValue = GetGrayColorValue(pixel);
                    bmp.SetPixel(i, j, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }

            return bmp;
        }

        /// <summary>
        /// 获取颜色对应的灰度值
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private int GetGrayColorValue(Color color)
        {
            return (int)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
        } 
        #endregion
    }
}
