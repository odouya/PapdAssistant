using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PapdLib;
using PapdLib.Info;

namespace PapdMonitor
{
    public partial class FrmOrderDetail : FrmBase
    {
        private FrmOrderDetail()
        {
            InitializeComponent();
        }

        public FrmOrderDetail(OrderDetailInfo info)
            : this()
        {
            Init(info);
        }

        private void Init(OrderDetailInfo info)
        {
            object[] values = new object[]
            {
                info.tradeOrder.GetOrderStatus(),
                info.address==null?string.Empty:info.address.mobile,
                info.tradeOrder.items[0].itemTitle,
                info.tradeOrder.items.Length,
                info.tradeOrder.bizType,
                "￥" + info.tradeOrder.useGold*0.01,
                "￥" + info.tradeOrder.postFee,
                "￥" + info.tradeOrder.tradeItemTotalFee*0.01,
                info.tradeOrder.tradeId,
                PapdHelper.ConvertFromUnixTime(info.tradeOrder.createTime),
                info.tradeOrder.payTime==0? "无" : PapdHelper.ConvertFromUnixTime(info.tradeOrder.payTime).ToString()
            };
            Type type = this.GetType();
            for (int i = 0; i < values.Length; i++)
            {
                FieldInfo textBoxField = type.GetField("textBox" + (i + 1),BindingFlags.Instance|BindingFlags.NonPublic);
                if (textBoxField != null)
                {
                    TextBox txt = (TextBox)textBoxField.GetValue(this);
                    if (txt != null)
                    {
                        txt.Text = values[i].ToString();
                    }
                }
            }

            if (info.IsNeedAddress())
            {
                this.label10.Text = "收货信息：";
                this.label10.Left = 10;
                this.textBox2.Text = info.address.ToString();
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("收件人：" + info.address.name);
                builder.AppendLine("收货地址：" + info.address.detail);
                builder.AppendLine("收件人手机号：" + info.address.mobile);
                this.toolTip1.SetToolTip(this.textBox2, builder.ToString());
            }
        }

        private void FrmOrderDetail_Shown(object sender, EventArgs e)
        {
            this.textBox1.Select(this.textBox1.TextLength, 1);
        }
    }
}
