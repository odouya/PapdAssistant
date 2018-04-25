using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PapdLib;

namespace PapdMonitor
{
    /// <summary>
    /// 定位窗体
    /// </summary>
    [ComVisible(true)]
    public partial class FrmLocation : Form
    {

        #region 属性和字段

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailAddress { get; set; }

        /// <summary>
        /// 经度纬度
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }

        private string city;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmLocation(string city)
        {
            InitializeComponent();
            this.city = city;
            SetHintText(this.textBox1, "请输入地址");
            InitWebBrowser();
        } 
        #endregion

        #region 初始化

        #region 为控件设置灰色提示信息API
        /// <summary>
        /// 发送Message消息API
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 为控件设置灰色提示信息
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="text">灰色提示信息内容</param>
        public static void SetHintText(Control control, string text)
        {
            SendMessage(control.Handle, 0x1501, 0, text);
        } 
        #endregion

        /// <summary>
        /// 初始化WebBrowser
        /// </summary>
        private void InitWebBrowser()
        {
            this.webBrowser1.Navigate(new Uri(GlobalContext.MapHtmPath));
            this.webBrowser1.ObjectForScripting = this;
        }

        /// <summary>
        /// 重新绘制ListBoxItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxAddress_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            ListBox lstBox = sender as ListBox;
            object item = lstBox.Items[e.Index];
            string num = (e.Index + 1).ToString("00") + ".";
            if (item is LocationInfo)
            {
                LocationInfo info = item as LocationInfo;
                if (info.IsDefault)
                {
                    e.Graphics.DrawString(num + item.ToString(), e.Font, new SolidBrush(Color.OrangeRed), e.Bounds);
                }
                else
                {
                    e.Graphics.DrawString(num + item.ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                }
            }
            e.DrawFocusRectangle();
        }
        #endregion

        #region 拖动点时，搜索附近的地址
        /// <summary>
        /// 根据经纬度，查询附近的地址
        /// </summary>
        /// <param name="lng">经度</param>
        /// <param name="lat">纬度 </param>
        public void SearchNearlyAddressByLngLat(double lng, double lat)
        {
            this.lstBoxAddress.Items.Clear();

            try
            {
                var list = GetAddressInfoByLngLat(lng, lat);
                LocationInfo2Control(list);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 根据经纬度，获取附近的地址
        /// </summary>
        /// <param name="lng">经度值</param>
        /// <param name="lat">纬度值</param>
        /// <returns></returns>
        private List<LocationInfo> GetAddressInfoByLngLat(double lng, double lat)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("ak", "lf1Gq5WI7vUjqhR6W6IBqAXNVjI0V4F7");
            pc.Add("location", lat + "," + lng);
            pc.Add("output", "json");
            pc.Add("pois", "1");
            pc.Add("coordtype", "bd09ll");
            pc.Add("callback", "jsonP.callback_4");

            string url = "http://api.map.baidu.com/geocoder/v2/?" + pc.ToString();
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(url);
            string json = System.Text.Encoding.UTF8.GetString(data);

            int startIndex = json.IndexOf("(") + 1;
            int endIndex = json.LastIndexOf(")");
            string json2 = json.Substring(startIndex, endIndex - startIndex);

            JObject obj = JsonConvert.DeserializeObject(json2) as JObject;
            JObject result = obj["result"] as JObject;

            List<LocationInfo> list = new List<LocationInfo>();

            list.Add(new LocationInfo()
            {
                IsDefault = true,
                Longitude = Convert.ToDouble(result["location"]["lng"].ToString()),
                Latitude = Convert.ToDouble(result["location"]["lat"].ToString()),
                Name = result["formatted_address"].ToString()
            });

            string province = result["addressComponent"]["province"].ToString();
            string city = result["addressComponent"]["city"].ToString();
            string district = result["addressComponent"]["district"].ToString();

            JArray poisArray = result["pois"] as JArray;
            for (int i = 0; i < poisArray.Count; i++)
            {
                JObject pois = poisArray[i] as JObject;
                list.Add(new LocationInfo()
                {
                    Longitude = Convert.ToDouble(pois["point"]["x"].ToString()),
                    Latitude = Convert.ToDouble(pois["point"]["y"].ToString()),
                    Name = pois["addr"].ToString() + pois["name"].ToString(),
                });
            }

            return list;
        }

        /// <summary>
        /// 将位置信息填充到控件上
        /// </summary>
        /// <param name="list"></param>
        private void LocationInfo2Control(List<LocationInfo> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                this.lstBoxAddress.Items.Add(list[i]);
            }
        }
        #endregion

        #region 根据地名和所在城市，搜索附近的地址
        /// <summary>
        /// “查询”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.lstBoxAddress.Items.Clear();
                var list = GetAddressInfoByName(this.textBox1.Text, this.city);
                LocationInfo2Control(list);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 在地址栏上按回车，调用“查询”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// 根据地名和所在城市，获取相关地址
        /// </summary>
        /// <param name="addressName">地名</param>
        /// <param name="city">所在城市</param>
        private List<LocationInfo> GetAddressInfoByName(string addressName, string city)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("ak", "lf1Gq5WI7vUjqhR6W6IBqAXNVjI0V4F7");
            pc.Add("q", addressName);
            pc.Add("output", "json");
            pc.Add("scope", "2");
            pc.Add("city_limit", "true");
            pc.Add("region", city);
            pc.Add("callback", "jsonP.callback_13");

            string url = "http://api.map.baidu.com/place/v2/suggestion?" + pc.ToString();
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(url);
            string json = System.Text.Encoding.UTF8.GetString(data);
            int startIndex = json.IndexOf("(") + 1;
            int endIndex = json.LastIndexOf(")");
            string json2 = json.Substring(startIndex, endIndex - startIndex);

            JObject obj = JsonConvert.DeserializeObject(json2) as JObject;
            JArray result = obj["result"] as JArray;

            List<LocationInfo> list = new List<LocationInfo>();
            for (int i = 0; i < result.Count; i++)
            {
                JObject addr = result[i] as JObject;
                list.Add(new LocationInfo()
                {
                    Longitude = Convert.ToDouble(addr["location"]["lng"].ToString()),
                    Latitude = Convert.ToDouble(addr["location"]["lat"].ToString()),
                    Name = "" + addr["city"] + addr["district"] + addr["name"],
                });
            }
            if (this.lstBoxAddress.Items.Count > 0)
            {
                (this.lstBoxAddress.Items[0] as LocationInfo).IsDefault = true;
            }

            return list;
        } 
        #endregion

        #region 选择列表中地址时，移动地图上的位置点
        /// <summary>
        /// 选择列表中的地址时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstBoxAddress.SelectedItems.Count < 1)
                return;
            var item = this.lstBoxAddress.SelectedItems[0];
            var locationInfo = item as LocationInfo;

            try
            {
                this.webBrowser1.Document.InvokeScript("centerAndZoom",
                        new object[] { locationInfo.Longitude, locationInfo.Latitude });
            }
            catch (Exception ex)
            {

            }
        } 
        #endregion

        #region 选择地址
        /// <summary>
        /// 双击地址列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lstBoxAddress.SelectedItems.Count < 1)
                return;

            var info = this.lstBoxAddress.SelectedItem as LocationInfo;
            this.DetailAddress = info.Name;
            this.Longitude = info.Longitude;
            this.Latitude = info.Latitude;

            this.DialogResult = DialogResult.OK;
        } 
        #endregion

    }

    #region 位置信息类
    /// <summary>
    /// 位置信息类
    /// </summary>
    public class LocationInfo
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsDefault { get; set; }

        public override string ToString()
        {
            return this.Name + (IsDefault ? "[当前]" : string.Empty);
        }
    } 
    #endregion
}
