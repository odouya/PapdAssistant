using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PapdLib.Info;

namespace PapdMonitor
{
    public partial class FrmFetchBox : FrmBase
    {
        public FrmFetchBox()
        {
            InitializeComponent();
            this.toolStripLabel1.Text = "";
        }

        /// <summary>
        /// 查询礼品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!base.CheckLoginState())
                return;
            this.listView1.Items.Clear();
            DoTask(() =>
            {
                var result = base.PH.GetDepot(base.MyCookie);
                result.Content[0].depotItems = result.Content[0].depotItems.OrderByDescending(s => s.OwnNum * 1.0 / s.NeedNum).ToArray(); // 按完成率降序排列
                double percent = 0;
                string percentStr = string.Empty;
                for (int i = 0; i < result.Content[0].depotItems.Length; i++)
                {
                    var depoItem = result.Content[0].depotItems[i];
                    percent = depoItem.OwnNum * 1.0 / depoItem.NeedNum*100;
                    percentStr = percent.ToString("0");
                    base.AddListViewmItem(this.listView1, new object[] {
                            i+1,
                            depoItem.SpuTitle,
                            depoItem.PriceGold*0.01,
                            depoItem.NeedNum,
                            depoItem.OwnNum,
                            percentStr
                        });
                    base.SetListViewItemTag(this.listView1, i, depoItem);
                    if (percent >= 100)
                    {
                        base.HighlightListViewRow(this.listView1, i);
                    }
                }

                // 获取碎片数
                var result2 = PH.FetchMyBoxNum(base.MyCookie);
                this.toolStripLabel1.Text = "我的碎片数：" + result2.Content[0].TotalBox;
            }, "查询失败");
        }

        /// <summary>
        /// 分享头条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!base.CheckLoginState())
                return;
            DoTask(() =>
                {
                    var result = PH.FetchBoxByShareReading(base.MyCookie);
                    ShowFetchBoxResult(result);
                }, "领取失败");
        }

        /// <summary>
        /// 逛商场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!base.CheckLoginState())
                return;
            DoTask(() =>
            {
                var result = PH.FetchBoxByWalkMall(base.MyCookie);
                ShowFetchBoxResult(result);
            }, "领取失败");
        }

        /// <summary>
        /// 邀好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!base.CheckLoginState())
                return;
            DoTask(() =>
            {
                var result = PH.FetchBoxByInviteFriend(base.MyCookie);
                ShowFetchBoxResult(result);
            }, "领取失败");
        }

        private void ShowFetchBoxResult(PajkResultList<PajkFetchBoxResult> result)
        {
            if (result.Content.Count > 0)
            {
                StringBuilder b = new StringBuilder();
                b.AppendLine("获取奖励：");
                for (int i = 0; i < result.Content[0].BoxGiftList.Length; i++)
                {
                    b.AppendLine(result.Content[0].BoxGiftList[i].GiftName);
                }
                MsgBox.ShowInfo(b.ToString());
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
                return;
            if (this.listView1.SelectedItems.Count < 1)
                return;

            this.contextMenuStrip1.Show(this.listView1, e.Location);
        }

        /// <summary>
        /// 查看图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 查看图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count < 1)
                return;

            var item = this.listView1.SelectedItems[0];
            var itemInfo = item.Tag as PajkGetDepotResultItem;

            DoTask(() => {
                Image img = base.PH.GetImageByPapdCode(itemInfo.Img);
                var frm = new FrmViewPic(img);
                frm.ShowDialog();
            }, "查看图片失败");
        }

        /// <summary>
        /// 兑换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 兑换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count < 1)
                return;

            var item = this.listView1.SelectedItems[0];
            var itemInfo = item.Tag as PajkGetDepotResultItem;

            if (itemInfo.NeedNum > itemInfo.OwnNum)
            {
                MsgBox.ShowInfo("碎片个数不够，无法兑换！");
                return;
            }

            if (MsgBox.ShowOkCancel("确定要兑换-" + itemInfo.SpuTitle + "?", "提示") != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            DoTask(() =>
                {
                    ProductInfo info = new ProductInfo();
                    info.name = itemInfo.SpuTitle;
                    info.id = itemInfo.SkuId;

                    var frm = new FrmCreateOrder(info);
                    frm.CreateOrder += (o,args)=>{
                        var obj = o as FrmCreateOrder;
                        GlobalContext.Output("正在下单...");
                        PH.CreateOrder2(base.MyCookie, itemInfo.SkuId.ToString(), obj.SelectedMobile, obj.SelectedAddress);
                        GlobalContext.Output("已下单，详情请在【订单信息】中查询！");
                    };
                    frm.ShowDialog();
                }, "兑换失败");
        } 

        /// <summary>
        /// 查看我的宝箱详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            DoTask(() => {
                var result = PH.GetMyBoxDetail(base.MyCookie);

                var frm = new FrmMyBoxDetail(result.Content[0].Value);
                frm.ShowDialog();
                frm.Dispose();
            }, "查看失败", false);
        }

        /// <summary>
        /// 看直播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (!base.CheckLoginState())
                return;
            DoTask(() =>
            {
                var result = PH.FetchBoxByVideo(base.MyCookie);
                ShowFetchBoxResult(result);
            }, "领取失败");
        }

        /// <summary>
        /// 砸蛋
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (!base.CheckLoginState())
                return;
            DoTask(() =>
            {
                var result = PH.ZaEgg(base.MyCookie);
                ShowZaEggResult(result);
            }, "领取失败");
        }

        private void ShowZaEggResult(PajkResultList<PajkZaEggResult> result)
        {
            if (result.Content.Count > 0)
            {
                StringBuilder b = new StringBuilder();
                b.AppendLine("获取奖励：");
                for (int i = 0; i < result.Content[0].pockets.Count; i++)
                {
                    var rewardInfo = result.Content[0].pockets[i];
                    string amount = rewardInfo.RewardAmount.ToString();
                    if(rewardInfo.RewardName=="健康金")
                    {
                        amount = rewardInfo.RewardAmount*0.01 + "";
                    }
                    b.AppendLine(rewardInfo.RewardName + " x" + amount);
                }
                MsgBox.ShowInfo(b.ToString());
            }
        }

        private void toolStripButtonFetchMapBox_Click(object sender, EventArgs e)
        {
            if (!base.CheckLoginState())
                return;
            DoTask(() =>
            {
                var result = PH.GenerateMapTrusureBox(base.MyCookie);
                if (result.Content[0].boxVO == null)
                {
                    if (result.Content[0].targetStep == 0)
                    {
                        DoOutput("获取地图宝箱已达到上限!");
                    }
                    else
                    {
                        DoOutput("必须达到" + result.Content[0].targetStep + "步才能领取宝箱!");
                    }
                }
                else
                {
                    var fetchResult = PH.FetchMapTrusureBox(base.MyCookie, result.Content[0].boxVO.id, result.Content[0].boxVO.lng, result.Content[0].boxVO.lat);
                    MessageBox.Show("获取健康金：" + fetchResult.Content[0].boxGiftList[0].gold * 0.01);
                }
            }, "领取失败");
        }

        private void toolStripButtonKanVideo_Click(object sender, EventArgs e)
        {
            MsgBox.ShowInfo("功能未开发！");
        }

        private void toolStripButtonShangClas_Click(object sender, EventArgs e)
        {
            MsgBox.ShowInfo("功能未开发！");
        }

        private void toolStripButtonShareZB_Click(object sender, EventArgs e)
        {
            MsgBox.ShowInfo("功能未开发！");
        }

        private void toolStripButtonShareVideo_Click(object sender, EventArgs e)
        {
            MsgBox.ShowInfo("功能未开发！");
        }
    }
}
