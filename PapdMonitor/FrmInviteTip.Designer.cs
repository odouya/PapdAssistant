namespace PapdMonitor
{
    partial class FrmInviteTip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIKnow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorLabel1 = new PapdMonitor.ColorLabel();
            this.SuspendLayout();
            // 
            // btnIKnow
            // 
            this.btnIKnow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnIKnow.Location = new System.Drawing.Point(105, 82);
            this.btnIKnow.Name = "btnIKnow";
            this.btnIKnow.Size = new System.Drawing.Size(85, 23);
            this.btnIKnow.TabIndex = 0;
            this.btnIKnow.Text = "我知道了";
            this.btnIKnow.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "1、输入好友手机号，点击邀请；\r\n2、好友下载平安好医生APP，并用同一手机号注册\r\n3、好友在步步夺金页领取起步基金0.2金；\r\n成功邀请后，奖金将在36小时内" +
                "到账。";
            // 
            // colorLabel1
            // 
            this.colorLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.colorLabel1.Location = new System.Drawing.Point(8, 9);
            this.colorLabel1.Name = "colorLabel1";
            this.colorLabel1.Size = new System.Drawing.Size(279, 65);
            this.colorLabel1.TabIndex = 2;
            this.colorLabel1.Text = "1、输入好友手机号，点击邀请；\r\n|2、好友下载平安好医生APP，并用|#ffcc00|同一手机号注册||；\r\n|3、好友在步步夺金页领取|#66ccff|起步基" +
                "金0.2金||；\r\n|成功邀请后，奖金将在|#ff0000|36小时内||到账。";
            // 
            // FrmInviteTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(295, 111);
            this.Controls.Add(this.colorLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIKnow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInviteTip";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "如何获取邀请奖励";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIKnow;
        private System.Windows.Forms.Label label1;
        private ColorLabel colorLabel1;
    }
}