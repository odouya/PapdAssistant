using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    /// <summary>
    /// 彩色标签
    /// </summary>
    class ColorLabel:Label
    {
        /*
         * 实现思路：
         * 1、将Text属性内容分割不同的行；
         * 2、在每行内用|分割，依次为：颜色代码|文本|颜色代码|文本
         */

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.Refresh();
            }
        }

        public int StartX = 0;
        public int StartY = 0;
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            string[] lines = this.Text.Split("\n".ToCharArray());//分割成不同行
            float yoffset = StartY;//y轴
            foreach (var line in lines)
            {
                if (line.Contains("|"))//该行需要根据不同颜色进行绘制
                {
                    float xoffset = StartX;
                    string[] parts = line.Split("|".ToCharArray());//用|分割
                    for (int i = 0; i < parts.Length; i+=2)//每两个为一组
                    {
                        Color color = this.ForeColor;
                        if (parts[i].Trim().Length > 0)
                        {
                            color = ColorTranslator.FromHtml(parts[i]);
                        }
                        Brush brush = new SolidBrush(color);
                        g.DrawString(parts[i+1],this.Font,brush,xoffset,yoffset);

                        xoffset += g.MeasureString(parts[i + 1], this.Font).Width - 5;
                    }
                }
                else//该行直接绘制
                {
                    Brush brush = new SolidBrush(this.ForeColor);
                    g.DrawString(line, this.Font, brush,this.StartX, yoffset);
                    brush.Dispose();
                }

                yoffset += g.MeasureString(line, this.Font).Height;
            }
        }
    }
}
