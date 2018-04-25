namespace PapdMonitor
{
    partial class FrmFetchBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFetchBox));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.兑换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFetchMapBox = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonKanVideo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShangClas = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShareZB = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShareVideo = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看图片ToolStripMenuItem,
            this.兑换ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 查看图片ToolStripMenuItem
            // 
            this.查看图片ToolStripMenuItem.Name = "查看图片ToolStripMenuItem";
            this.查看图片ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看图片ToolStripMenuItem.Text = "查看图片";
            this.查看图片ToolStripMenuItem.Click += new System.EventHandler(this.查看图片ToolStripMenuItem_Click);
            // 
            // 兑换ToolStripMenuItem
            // 
            this.兑换ToolStripMenuItem.Name = "兑换ToolStripMenuItem";
            this.兑换ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.兑换ToolStripMenuItem.Text = "兑换";
            this.兑换ToolStripMenuItem.Click += new System.EventHandler(this.兑换ToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(866, 315);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "价格";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "所需碎片数";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "已得碎片数";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "完成率(%)";
            this.columnHeader6.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripLabel1,
            this.toolStripButton5,
            this.toolStripButton7,
            this.toolStripButtonFetchMapBox,
            this.toolStripButtonKanVideo,
            this.toolStripButtonShangClas,
            this.toolStripButtonShareZB,
            this.toolStripButtonShareVideo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(866, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton1.Text = "查询礼品";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton2.Text = "分享头条";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton3.Text = "逛商场";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton4.Text = "邀好友";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.IsLink = true;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel1.Text = "我的碎片数：";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton5.Text = "看直播";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton7.Text = "砸蛋";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButtonFetchMapBox
            // 
            this.toolStripButtonFetchMapBox.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFetchMapBox.Image")));
            this.toolStripButtonFetchMapBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFetchMapBox.Name = "toolStripButtonFetchMapBox";
            this.toolStripButtonFetchMapBox.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonFetchMapBox.Text = "地图宝箱";
            this.toolStripButtonFetchMapBox.Click += new System.EventHandler(this.toolStripButtonFetchMapBox_Click);
            // 
            // toolStripButtonKanVideo
            // 
            this.toolStripButtonKanVideo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonKanVideo.Image")));
            this.toolStripButtonKanVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonKanVideo.Name = "toolStripButtonKanVideo";
            this.toolStripButtonKanVideo.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonKanVideo.Text = "看视频";
            this.toolStripButtonKanVideo.Click += new System.EventHandler(this.toolStripButtonKanVideo_Click);
            // 
            // toolStripButtonShangClas
            // 
            this.toolStripButtonShangClas.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShangClas.Image")));
            this.toolStripButtonShangClas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShangClas.Name = "toolStripButtonShangClas";
            this.toolStripButtonShangClas.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonShangClas.Text = "去上课";
            this.toolStripButtonShangClas.Click += new System.EventHandler(this.toolStripButtonShangClas_Click);
            // 
            // toolStripButtonShareZB
            // 
            this.toolStripButtonShareZB.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShareZB.Image")));
            this.toolStripButtonShareZB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShareZB.Name = "toolStripButtonShareZB";
            this.toolStripButtonShareZB.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonShareZB.Text = "分享直播";
            this.toolStripButtonShareZB.Click += new System.EventHandler(this.toolStripButtonShareZB_Click);
            // 
            // toolStripButtonShareVideo
            // 
            this.toolStripButtonShareVideo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShareVideo.Image")));
            this.toolStripButtonShareVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShareVideo.Name = "toolStripButtonShareVideo";
            this.toolStripButtonShareVideo.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonShareVideo.Text = "分享视频";
            this.toolStripButtonShareVideo.Click += new System.EventHandler(this.toolStripButtonShareVideo_Click);
            // 
            // FrmFetchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 340);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmFetchBox";
            this.Text = "步步夺宝";
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem 兑换ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripButton toolStripButtonFetchMapBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonKanVideo;
        private System.Windows.Forms.ToolStripButton toolStripButtonShangClas;
        private System.Windows.Forms.ToolStripButton toolStripButtonShareZB;
        private System.Windows.Forms.ToolStripButton toolStripButtonShareVideo;
    }
}