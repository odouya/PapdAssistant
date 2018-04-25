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
    public partial class FrmLottery : FrmBase
    {
        public FrmLottery()
        {
            InitializeComponent();
        }

        private void toolStripButtonQuery_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            new Thread(() =>
            {
                try
                {
                    base.ClearListView(this.listView1);
                    var list = PH.QueryPrizeList(base.MyCookie);
                    for (int i = 0; i < list.Content[0].prizes.Count; i++)
                    {
                        var item = list.Content[0].prizes[i];
                        base.AddListViewmItem(this.listView1, new object[]
                        {
                            i+1,
                            item.name,
                            item.costGold + "金/次",
                            ""
                        });
                        base.SetListViewItemTag(this.listView1, i, item);
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInfo("查询失败，" + ex.Message);
                }
            }){IsBackground = true}.Start();
        }

        private void toolStripButtonLottery_Click(object sender, EventArgs e)
        {
            if (!CheckLoginState())
                return;

            if (this.listView1.CheckedItems.Count < 1)
            {
                MsgBox.ShowInfo("请勾选需要抽奖的项目！");
                return;
            }

            List<int> list = new List<int>();
            for (int i = 0; i < this.listView1.CheckedItems.Count; i++)
            {
                list.Add(this.listView1.CheckedItems[i].Index);
            }

            new Thread(() =>
            {
                SetControlEnabled(this.toolStrip1,false);
                SetControlEnabled(this.listView1,false);
                foreach (var index in list)
                {
                    SetListViewItemValue(this.listView1, index, 3, "正在抽奖...");
                    try
                    {
                        var info = GetListViewItemTag<PajkPrizeItemInfo>(this.listView1, index);
                        var result = PH.DoLottery(base.MyCookie, info.id.ToString());
                        if (result.Content[0].isPrized ||
                                     result.Content[0].prize ||
                                     result.Content[0].prized)
                        {
                            SetListViewItemValue(this.listView1, index, 3, "抽奖成功，" + result.Content[0].winRecordId);
                        }
                        else
                        {
                            SetListViewItemValue(this.listView1, index, 3, "抽奖失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        SetListViewItemValue(this.listView1, index, 3, "抽奖失败，" + ex.Message);
                    }
                    Thread.Sleep(500);
                }
                SetControlEnabled(this.toolStrip1, true);
                SetControlEnabled(this.listView1,true);
            }){IsBackground = true}.Start();
        }
    }
}
