using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    public partial class ItemControl : UserControl
    {
        public ItemControl()
        {
            InitializeComponent();
        }

        public void SetImage(Image img)
        {
            this.pictureBox1.BackgroundImage = img;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private int width = 277;
        public void SetTitle(string title)
        {
            this.label1.Text = title;
            if (this.label1.Width > width)
            {
                width = this.label1.Width;
            }
        }

        public void SetDecription(string desc)
        {
            this.label2.Text = desc;
            if (this.label2.Width > width)
            {
                width = this.label2.Width;
            }
        }
    }
}
