namespace PapdMonitor
{
    partial class FrmStepManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStepManager));
            this.listView1 = new PapdMonitor.ListViewFz();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDownloadStepData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUploadStepData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearCert = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonViewCertDetail = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectCert = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxCurCertPath = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripButtonSaveCert = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader7,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(852, 329);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "#";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Id";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "日期";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "距离(公里)";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "步数";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "卡路里";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "目标步数";
            this.columnHeader5.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDownloadStepData,
            this.toolStripButtonUploadStepData,
            this.toolStripButtonHelp,
            this.toolStripButtonSaveCert,
            this.toolStripButtonViewCertDetail,
            this.toolStripButtonClearCert,
            this.toolStripButtonSelectCert,
            this.toolStripTextBoxCurCertPath,
            this.toolStripLabel1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(852, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDownloadStepData
            // 
            this.toolStripButtonDownloadStepData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDownloadStepData.Image")));
            this.toolStripButtonDownloadStepData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDownloadStepData.Name = "toolStripButtonDownloadStepData";
            this.toolStripButtonDownloadStepData.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonDownloadStepData.Text = "获取走步数据";
            this.toolStripButtonDownloadStepData.Click += new System.EventHandler(this.toolStripButtonDownloadStepData_Click);
            // 
            // toolStripButtonUploadStepData
            // 
            this.toolStripButtonUploadStepData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUploadStepData.Image")));
            this.toolStripButtonUploadStepData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUploadStepData.Name = "toolStripButtonUploadStepData";
            this.toolStripButtonUploadStepData.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonUploadStepData.Text = "上传走步数据";
            this.toolStripButtonUploadStepData.Click += new System.EventHandler(this.toolStripButtonUploadStepData_Click);
            // 
            // toolStripButtonHelp
            // 
            this.toolStripButtonHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHelp.Image")));
            this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHelp.Name = "toolStripButtonHelp";
            this.toolStripButtonHelp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHelp.Text = "帮助";
            this.toolStripButtonHelp.Click += new System.EventHandler(this.toolStripButtonHelp_Click);
            // 
            // toolStripButtonClearCert
            // 
            this.toolStripButtonClearCert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClearCert.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearCert.Image")));
            this.toolStripButtonClearCert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearCert.Name = "toolStripButtonClearCert";
            this.toolStripButtonClearCert.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonClearCert.Text = "清除证书";
            this.toolStripButtonClearCert.Click += new System.EventHandler(this.toolStripButtonClearCert_Click);
            // 
            // toolStripButtonViewCertDetail
            // 
            this.toolStripButtonViewCertDetail.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonViewCertDetail.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonViewCertDetail.Image")));
            this.toolStripButtonViewCertDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewCertDetail.Name = "toolStripButtonViewCertDetail";
            this.toolStripButtonViewCertDetail.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonViewCertDetail.Text = "查看证书";
            this.toolStripButtonViewCertDetail.Click += new System.EventHandler(this.toolStripButtonViewCertDetail_Click);
            // 
            // toolStripButtonSelectCert
            // 
            this.toolStripButtonSelectCert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSelectCert.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectCert.Image")));
            this.toolStripButtonSelectCert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectCert.Name = "toolStripButtonSelectCert";
            this.toolStripButtonSelectCert.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonSelectCert.Text = "选择证书";
            this.toolStripButtonSelectCert.Click += new System.EventHandler(this.toolStripButtonSelectCert_Click);
            // 
            // toolStripTextBoxCurCertPath
            // 
            this.toolStripTextBoxCurCertPath.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBoxCurCertPath.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripTextBoxCurCertPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxCurCertPath.Name = "toolStripTextBoxCurCertPath";
            this.toolStripTextBoxCurCertPath.ReadOnly = true;
            this.toolStripTextBoxCurCertPath.Size = new System.Drawing.Size(200, 25);
            this.toolStripTextBoxCurCertPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxCurCertPath_KeyDown);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.IsLink = true;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "查看路径";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "证书文件(*.pfx)|*.pfx";
            this.openFileDialog1.Title = "请选择证书文件";
            // 
            // toolStripButtonSaveCert
            // 
            this.toolStripButtonSaveCert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSaveCert.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveCert.Image")));
            this.toolStripButtonSaveCert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveCert.Name = "toolStripButtonSaveCert";
            this.toolStripButtonSaveCert.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonSaveCert.Text = "另存证书";
            this.toolStripButtonSaveCert.Click += new System.EventHandler(this.toolStripButtonSaveCert_Click);
            // 
            // FrmStepManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 354);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStepManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "走步数据管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStepManager_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewFz listView1;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonUploadStepData;
        private System.Windows.Forms.ToolStripButton toolStripButtonDownloadStepData;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButtonHelp;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCurCertPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectCert;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearCert;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewCertDetail;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveCert;
    }
}