using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PapdLib.Info;
using System.IO;
using PapdLib;

namespace PapdMonitor
{
    /// <summary>
    /// 商品详细信息窗体
    /// </summary>
    public partial class FrmProductDetail : FrmBase
    {
        #region 属性和字段
        private PapdLib.PapdHelper PH = new PapdHelper();
        private ProductDetail detailInfo;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        private FrmProductDetail()
        {
            InitializeComponent();
            InitCancelButton();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">商品详细信息</param>
        public FrmProductDetail(ProductDetail info)
            : this()
        {
            this.detailInfo = info;
            ProductDetail2Control(info);
        } 
        #endregion

        /// <summary>
        /// 初始化窗体的CancelButton
        /// </summary>
        private void InitCancelButton()
        {
            Button btn = new Button();
            btn.Click += (s, e) =>
                {
                    if (this.Modal)
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    else
                        this.Close();
                };
            this.CancelButton = btn;
        }

        /// <summary>
        /// 将商品详细信息填充到控件
        /// </summary>
        /// <param name="info">商品详细信息</param>
        private void ProductDetail2Control(ProductDetail info)
        {
            try
            {
                //填充信息
                this.txtTitle.Text = info.title;
                this.txtDesc.Text = info.items[0].level1Spec;
                this.txtPrice.Text = (info.items[0].price / 100).ToString();
                this.txtGold.Text = (info.items[0].healthGoldDeductibleAmount / 100).ToString();

                //下载商品图片
                var client = new System.Net.WebClient();
                var imgUrl = PapdLib.PapdHelper.GetImageUrl(info.items[0].pictures);
                var data = client.DownloadData(imgUrl);
                using (var ms = new MemoryStream())
                {
                    ms.Write(data, 0, data.Length);
                    this.pbPicture.BackgroundImage = Image.FromStream(ms);
                    this.pbPicture.BackgroundImageLayout = ImageLayout.Stretch;
                }

                //获取验证码
                Image img = this.PH.GetVerifyCode(MyCookie);
                this.pbVerifyCode.Image = img;
                this.pbVerifyCode.Size = img.Size;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// “确定”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string verifyCode = this.txtVerifyCode.Text.Trim();
            try
            {
                var result = PH.CheckVerifyCode(MyCookie,
                    this.detailInfo.items[0].id.ToString(),
                    this.detailInfo.items[0].storeStock.id.ToString(),
                    verifyCode.ToString());
                MessageBox.Show(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
