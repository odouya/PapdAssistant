namespace PapdMonitor
{
    partial class FrmQRCode
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInviteCode = new System.Windows.Forms.Label();
            this.btnQuickInvite = new System.Windows.Forms.Button();
            this.btnTip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 210);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // lblInviteCode
            // 
            this.lblInviteCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInviteCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInviteCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInviteCode.ForeColor = System.Drawing.Color.Blue;
            this.lblInviteCode.Location = new System.Drawing.Point(75, 216);
            this.lblInviteCode.Name = "lblInviteCode";
            this.lblInviteCode.Size = new System.Drawing.Size(61, 17);
            this.lblInviteCode.TabIndex = 1;
            this.lblInviteCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInviteCode.Click += new System.EventHandler(this.lblInviteCode_Click);
            // 
            // btnQuickInvite
            // 
            this.btnQuickInvite.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuickInvite.Location = new System.Drawing.Point(68, 243);
            this.btnQuickInvite.Name = "btnQuickInvite";
            this.btnQuickInvite.Size = new System.Drawing.Size(75, 23);
            this.btnQuickInvite.TabIndex = 2;
            this.btnQuickInvite.Text = "快速邀请";
            this.btnQuickInvite.UseVisualStyleBackColor = true;
            this.btnQuickInvite.Click += new System.EventHandler(this.btnQuickInvite_Click);
            // 
            // btnTip
            // 
            this.btnTip.Location = new System.Drawing.Point(149, 243);
            this.btnTip.Name = "btnTip";
            this.btnTip.Size = new System.Drawing.Size(22, 23);
            this.btnTip.TabIndex = 3;
            this.btnTip.Text = "?";
            this.btnTip.UseVisualStyleBackColor = true;
            this.btnTip.Click += new System.EventHandler(this.btnTip_Click);
            // 
            // FrmQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 273);
            this.Controls.Add(this.btnTip);
            this.Controls.Add(this.btnQuickInvite);
            this.Controls.Add(this.lblInviteCode);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQRCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的邀请二维码";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblInviteCode;
        private System.Windows.Forms.Button btnQuickInvite;
        private System.Windows.Forms.Button btnTip;
    }
}