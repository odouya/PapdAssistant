using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PapdLib.Info;

namespace PapdMonitor
{
    /// <summary>
    /// 选择收货地址窗体
    /// </summary>
    public partial class FrmSelectAddress : FrmBase
    {
        public AddressInfo CurrentAddressInfo;
        private bool isShown = true;//是否显示窗体

        public FrmSelectAddress(string cookie)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            bool isThreadRunning = true;
            Thread thread = new Thread(() =>
            {
                try
                {
                    List<AddressInfo> list = GlobalContext.PH.GetAllAddress(cookie);

                    Addresses2Control(list);
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInfo("加载收货地址失败，" + ex.Message);
                    this.isShown = false;
                }
                finally
                {
                    isThreadRunning = false;
                }
            });
            thread.IsBackground = true;
            thread.Start();

            while(isThreadRunning) Application.DoEvents();
        }

        public new DialogResult ShowDialog()
        {
            if (!this.isShown)
            {
                this.DialogResult = DialogResult.Cancel;
                return this.DialogResult;
            }
            return base.ShowDialog();
        }

        private void Addresses2Control(List<AddressInfo> list)
        {
            if (list.Count < 1)
            {
                MessageBox.Show("没有收货地址！");
                this.isShown = false;
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                var address = list[i];

                var item = new ListViewItem(new string[]{
                    (i+1).ToString(),
                    address.recipientName,
                    address.recipientPhone,
                    address.province,
                    address.city,
                    address.streetAddress,
                });
                item.Tag = address;
                this.lvAddresses.Items.Add(item);
            }
        }

        private void lvAddresses_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvAddresses.SelectedItems.Count < 1)
                return;

            var item = this.lvAddresses.SelectedItems[0];
            var info = item.Tag as AddressInfo;
            this.CurrentAddressInfo = info;

            this.DialogResult = DialogResult.OK;
        }
    }
}
