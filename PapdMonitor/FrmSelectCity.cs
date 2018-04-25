using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PapdLib;
using PapdLib.Info;

namespace PapdMonitor
{
    public partial class FrmSelectCity : FrmBase
    {
        /// <summary>
        /// 选择的城市信息
        /// </summary>
        public CityInfo SelectedCityInfo { get; private set; }

        private Dictionary<string,List<CityInfo>> CityDic { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmSelectCity(List<CityInfo> cities)
        {
            InitializeComponent();
            InitCities(cities);
        }

        /// <summary>
        /// 初始化所有城市
        /// </summary>
        private void InitCities(List<CityInfo> list)
        {
            try
            {
                //排序
                list = list.OrderBy(info => info.initial).ToList();
                //分组
                this.CityDic = new Dictionary<string, List<CityInfo>>();
                foreach (var cityInfo in list)
                {
                    if (!this.CityDic.Keys.Contains(cityInfo.initial))
                        this.CityDic.Add(cityInfo.initial, new List<CityInfo>());
                    this.CityDic[cityInfo.initial].Add(cityInfo);
                }
                LoadCities(this.CityDic);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载城市字典
        /// </summary>
        /// <param name="dic"></param>
        private void LoadCities(Dictionary<string, List<CityInfo>> dic)
        {
            this.listView1.Items.Clear();
            //加载
            foreach (KeyValuePair<string, List<CityInfo>> item in dic)
            {
                var key = item.Key;
                var value = item.Value;
                //添加组
                var group = new ListViewGroup(key);
                this.listView1.Groups.Add(group);
                //添加Item
                value.ForEach(cityInfo =>
                {
                    var listViewItem = new ListViewItem(new string[] { cityInfo.cityName, cityInfo.cityCode, cityInfo.provinceCode });
                    listViewItem.Tag = cityInfo;
                    group.Items.Add(listViewItem);
                    this.listView1.Items.Add(listViewItem);
                });
            }
        }

        /// <summary>
        /// 双击城市，选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                var item = this.listView1.SelectedItems[0];
                var cityInfo = item.Tag as CityInfo;
                if (cityInfo != null)
                {
                    this.SelectedCityInfo = cityInfo;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// 模糊查询城市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var cityName = this.txtCity.Text.Trim();
            var dic = new Dictionary<string, List<CityInfo>>();
            foreach (KeyValuePair<string, List<CityInfo>> item in this.CityDic)
            {
                var list = new List<CityInfo>();
                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (item.Value[i].cityName.Contains(cityName))
                    {
                        list.Add(item.Value[i]);
                    }
                }
                dic.Add(item.Key,list);
            }
            LoadCities(dic);
        }
    }
}
