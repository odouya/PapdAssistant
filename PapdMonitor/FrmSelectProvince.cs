using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PapdLib.Info;

namespace PapdMonitor
{
    public partial class FrmSelectProvince : FrmBase
    {
        public ProvinceInfo ProvinceInfo;
        private List<ProvinceInfo> Provinces; 

        public FrmSelectProvince(List<ProvinceInfo> list)
        {
            InitializeComponent();
            this.Provinces = list;
            Provinces2Control(list);
        }

        private void Provinces2Control(List<ProvinceInfo> list)
        {
            this.listView1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                var item = new ListViewItem(new string[]{list[i].provinceName,list[i].provinceCode});
                item.Tag = list[i];
                this.listView1.Items.Add(item);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //双击选择
            if (this.listView1.SelectedItems.Count < 1)
                return;
            var selectedItem = this.listView1.SelectedItems[0];
            var info = selectedItem.Tag as ProvinceInfo;

            this.ProvinceInfo = info;

            this.DialogResult = DialogResult.OK;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var list = new List<ProvinceInfo>();
            foreach (var provinceInfo in this.Provinces)
            {
                if (provinceInfo.provinceName.Contains(this.txtInput.Text))
                {
                    list.Add(provinceInfo);
                }
            }

            Provinces2Control(list);
        }
    }
}
