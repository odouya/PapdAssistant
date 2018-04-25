using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    public partial class FrmViewPic : FrmBase
    {
        private List<Image> _images ;
        private int _imageIndex = -1;

        public FrmViewPic(ImageList imageList)
            : this(GetImages(imageList))
        {
            
        }

        public FrmViewPic(Image img) : this(new List<Image>(){img})
        {
            
        }

        public FrmViewPic(List<Image> imgs)
        {
            InitializeComponent();
            base.EnableCancelButton();
            _images = imgs;
            NextPic();
        }

        private static List<Image> GetImages(ImageList li)
        {
            var list = new List<Image>();

            for (int i = 0; i < li.Images.Count; i++)
            {
                list.Add(li.Images[i]);
            }

            return list;
        }

        private void NextPic()
        {
            if (++_imageIndex > _images.Count - 1)
            {
                _imageIndex = _images.Count - 1;
            }
            ChangeImage(_imageIndex);
            RefreshStatus();
        }

        private void LastPic()
        {
            if (--_imageIndex < 0)
            {
                _imageIndex = 0;
            }
            ChangeImage(_imageIndex);
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            this.label1.Text = string.Format("{0}/{1}", _imageIndex + 1, _images.Count);
        }

        private void ChangeImage(int index)
        {
            if (_images == null || _images.Count < 1)
                return;

            Image image = _images[index];
            try
            {
                if (image.GetFrameCount(FrameDimension.Time) > 1) // 表示动图
                {
                    this.pictureBox1.Image = image;
                }
            }
            catch (Exception ex)
            {
                
                this.pictureBox1.BackgroundImage = image; // 静图
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < this.pictureBox1.Width/2)
                pictureBox1.Cursor = Cursors.PanWest;
            else
                pictureBox1.Cursor = Cursors.PanEast;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < this.pictureBox1.Width/2)
                LastPic();
            else
                NextPic();
        }

        /// <summary>
        /// 图片另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    _images[_imageIndex].Save(this.saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInfo("保存失败，" + ex.Message);
                }
            }
        }
    }
}
