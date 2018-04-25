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
    public partial class FrmSetting : FrmBase
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void Init()
        {
            var configInfo = ConfigStorage.GetInstance().GetConfigInfo();
            this.checkBox1.Checked = configInfo.IsAutoUploadWalkData;
            this.checkBox2.Checked = configInfo.IsAutoGrabGold;
            this.checkBox3.Checked = configInfo.IsAutoFetchYesterdayBonus;
            this.checkBox4.Checked = configInfo.IsAutoGrabTreasure;
            this.numericUpDown1.Minimum = 100;
            this.numericUpDown1.Maximum = 100000;
            this.numericUpDown1.Value = configInfo.RandomMinStep;
            this.numericUpDown2.Minimum = 100;
            this.numericUpDown2.Maximum = 100000;
            this.numericUpDown2.Value = configInfo.RandomMaxStep;
            this.numericUpDown3.Value = configInfo.CreateOrderTimespan;
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            Init();
            base.EnableCancelButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var configInfo = ConfigStorage.GetInstance().GetConfigInfo();
            configInfo.IsAutoUploadWalkData = this.checkBox1.Checked;
            configInfo.IsAutoGrabGold = this.checkBox2.Checked;
            configInfo.IsAutoFetchYesterdayBonus = this.checkBox3.Checked;
            configInfo.IsAutoGrabTreasure = this.checkBox4.Checked;
            configInfo.RandomMinStep = Convert.ToInt32(this.numericUpDown1.Value);
            configInfo.RandomMaxStep = Convert.ToInt32(this.numericUpDown2.Value);
            configInfo.CreateOrderTimespan = Convert.ToInt32(this.numericUpDown3.Value);
            ConfigStorage.GetInstance().UpdateAutoConfigInfo(configInfo);

            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
