using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PapdLib;

namespace PapdMonitor
{
    /// <summary>
    /// 步数输入窗体
    /// </summary>
    public partial class FrmStepDataGen : Form
    {
        /// <summary>
        /// 设置的步数
        /// </summary>
        public int StepCount { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmStepDataGen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// “确定”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.StepCount = Convert.ToInt32(this.textBox1.Text);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// “取消”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 当步数修改时，调整对应的“距离值”和“卡路里值”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 调整距离值和卡路里值
                this.textBox2.Text = (Convert.ToInt32(this.textBox1.Text) * PapdHelper.DefaultDistanceScale).ToString();
                this.textBox3.Text = (Convert.ToInt32(this.textBox1.Text) * PapdHelper.DefaultCaloryScale).ToString();
                // 步数有效时，启用确定按钮
                this.button1.Enabled = true;
            }
            catch (Exception ex)
            {
                // 步数无效时，重置控件状态
                this.textBox2.Text = string.Empty;
                this.textBox3.Text = string.Empty;
                this.button1.Enabled = false;
            }
        }

        /// <summary>
        /// 窗体载入函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStepDataGen_Load(object sender, EventArgs e)
        {
            // 初始化步数
            var configInfo = ConfigStorage.GetInstance().GetConfigInfo();
            this.textBox1.Text = new Random().Next(configInfo.RandomMinStep, configInfo.RandomMaxStep) + "";
            this.textBox1.Select(this.textBox1.TextLength,1);
        }
    }
}
