using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PapdLib.Info;
using PapdLib;

namespace PapdMonitor
{
    public partial class FrmMyBoxDetail : FrmBase
    {
        public FrmMyBoxDetail()
        {
            InitializeComponent();
            base.EnableCancelButton();
            this.label2.Text = "";
        }

        public FrmMyBoxDetail(List<PajkGetMyBoxDetailItem> list) : this()
        {
            this.label2.Text = list.Count.ToString();

            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var itemControl = new ItemControl();
                itemControl.SetImage(this.imageList1.Images[0]);
                itemControl.SetTitle(item.BoxGiftList[0].GiftName);
                itemControl.SetDecription(item.BoxCode + PapdHelper.ConvertFromUnixTime(item.BoxDate));
                itemControl.Visible = true;
                this.flowLayoutPanel1.Controls.Add(itemControl);
            }
        }
    }
}
