namespace PapdMonitor
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.labelCookie = new System.Windows.Forms.Label();
            this.textBoxCookie = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonHistoryCookies = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReadFromDb = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFetchCookie = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCookie
            // 
            this.labelCookie.AutoSize = true;
            this.labelCookie.Location = new System.Drawing.Point(89, 9);
            this.labelCookie.Name = "labelCookie";
            this.labelCookie.Size = new System.Drawing.Size(77, 12);
            this.labelCookie.TabIndex = 0;
            this.labelCookie.Text = "请输入Cookie";
            // 
            // textBoxCookie
            // 
            this.textBoxCookie.AllowDrop = true;
            this.textBoxCookie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCookie.Location = new System.Drawing.Point(89, 29);
            this.textBoxCookie.Multiline = true;
            this.textBoxCookie.Name = "textBoxCookie";
            this.textBoxCookie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCookie.Size = new System.Drawing.Size(428, 124);
            this.textBoxCookie.TabIndex = 1;
            this.textBoxCookie.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCookie_DragDrop);
            this.textBoxCookie.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCookie_DragEnter);
            this.textBoxCookie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCookie_KeyPress);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(351, 160);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(95, 30);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "登录";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(454, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 30);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonHistoryCookies
            // 
            this.buttonHistoryCookies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHistoryCookies.Location = new System.Drawing.Point(89, 160);
            this.buttonHistoryCookies.Name = "buttonHistoryCookies";
            this.buttonHistoryCookies.Size = new System.Drawing.Size(95, 30);
            this.buttonHistoryCookies.TabIndex = 4;
            this.buttonHistoryCookies.Text = "历史Cookie";
            this.toolTip1.SetToolTip(this.buttonHistoryCookies, "获取已经使用过的Cookie");
            this.buttonHistoryCookies.UseVisualStyleBackColor = true;
            this.buttonHistoryCookies.Click += new System.EventHandler(this.buttonHistoryCookies_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(98, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem2.Text = "121";
            // 
            // btnReadFromDb
            // 
            this.btnReadFromDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReadFromDb.Location = new System.Drawing.Point(194, 160);
            this.btnReadFromDb.Name = "btnReadFromDb";
            this.btnReadFromDb.Size = new System.Drawing.Size(95, 30);
            this.btnReadFromDb.TabIndex = 4;
            this.btnReadFromDb.Text = "从文件读取";
            this.toolTip1.SetToolTip(this.btnReadFromDb, "从Cookies文件中读取");
            this.btnReadFromDb.UseVisualStyleBackColor = true;
            this.btnReadFromDb.Visible = false;
            this.btnReadFromDb.Click += new System.EventHandler(this.btnReadFromDb_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "温馨提示";
            // 
            // btnFetchCookie
            // 
            this.btnFetchCookie.ImageIndex = 0;
            this.btnFetchCookie.ImageList = this.imageList1;
            this.btnFetchCookie.Location = new System.Drawing.Point(525, 28);
            this.btnFetchCookie.Name = "btnFetchCookie";
            this.btnFetchCookie.Size = new System.Drawing.Size(24, 25);
            this.btnFetchCookie.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnFetchCookie, "Cookie抓取");
            this.btnFetchCookie.UseVisualStyleBackColor = true;
            this.btnFetchCookie.Click += new System.EventHandler(this.btnFetchCookie_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImage = global::PapdMonitor.Properties.Resources._1671BGV697Z1;
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxLogo.Location = new System.Drawing.Point(11, 13);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(60, 56);
            this.pictureBoxLogo.TabIndex = 2;
            this.pictureBoxLogo.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxLogo, "Cookie，指网站为了辨别用户身份、进行session跟踪而储存在用户本地终端上的数据（通常经过加密）。");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fetch.ico");
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(561, 197);
            this.Controls.Add(this.btnFetchCookie);
            this.Controls.Add(this.btnReadFromDb);
            this.Controls.Add(this.buttonHistoryCookies);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.textBoxCookie);
            this.Controls.Add(this.labelCookie);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCookie;
        private System.Windows.Forms.TextBox textBoxCookie;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonHistoryCookies;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btnReadFromDb;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnFetchCookie;
        private System.Windows.Forms.ImageList imageList1;
    }
}