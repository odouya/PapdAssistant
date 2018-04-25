using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    /// <summary>
    /// 关于窗体
    /// </summary>
    public partial class FrmAbout : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmAbout()
        {
            InitializeComponent();
            InitCancelButton();
            InitClickEvent();
        }

        /// <summary>
        /// 初始化窗体的CancelButton
        /// </summary>
        private void InitCancelButton()
        {
            var btn = new Button();
            this.CancelButton = btn;
            btn.Click += (sender, args) =>
            {
                if(this.Modal)
                    this.DialogResult = DialogResult.Cancel;
                else
                    this.Close();
            };
        }

        /// <summary>
        /// 初始化点击事件
        /// </summary>
        private void InitClickEvent()
        {
            Control[] controls = new Control[]{this,this.pbLogo,this.lblVersion,this.panel1};
            foreach (var control in controls)
            {
                control.Click += (sender, args) =>
                {
                    if (this.Modal)
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        this.Close();
                    }
                };
            }
        }
    }
}
