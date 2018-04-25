namespace PapdMonitor
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCloseFind = new System.Windows.Forms.Button();
            this.btnCreateInviteQRImage = new System.Windows.Forms.Button();
            this.btnQueryPreRewardInfo = new System.Windows.Forms.Button();
            this.btnQueryGrabGold = new System.Windows.Forms.Button();
            this.checkBoxCheckVerifyCodeByOrdering = new System.Windows.Forms.CheckBox();
            this.btnRecommandDate = new System.Windows.Forms.Button();
            this.numericUpDownLoopInternal = new System.Windows.Forms.NumericUpDown();
            this.tabControlQueryInfo = new System.Windows.Forms.TabControl();
            this.tabPageMonitor = new System.Windows.Forms.TabPage();
            this.listViewProduct = new PapdMonitor.ListViewFz();
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelFindProduct = new System.Windows.Forms.Panel();
            this.txtFindProduct = new System.Windows.Forms.TextBox();
            this.btnFindProduct = new System.Windows.Forms.Button();
            this.tabPageMyInfo = new System.Windows.Forms.TabPage();
            this.btnQueryUserInfo = new System.Windows.Forms.Button();
            this.txtUserMobile = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUserGender = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUserNick = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.tabPageGoldInfo = new System.Windows.Forms.TabPage();
            this.buttonDelayGoldExpiredTime = new System.Windows.Forms.Button();
            this.btnQueryGoldInfo = new System.Windows.Forms.Button();
            this.txtStepReward = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtInvitationReward = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCumulativeReward = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBanlance = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPageInvite = new System.Windows.Forms.TabPage();
            this.lvInvitees = new System.Windows.Forms.ListView();
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnQueryInvitees = new System.Windows.Forms.Button();
            this.tabPageLastBonus = new System.Windows.Forms.TabPage();
            this.btnFetchReward = new System.Windows.Forms.Button();
            this.txtPreSteps = new System.Windows.Forms.TextBox();
            this.txtIsPreMoneyFetch = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtPreRewardID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIsPreDoubleMoney = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPreMoney = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageFriendRank = new System.Windows.Forms.TabPage();
            this.txtRankingDate = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnQueryFriendRanking = new System.Windows.Forms.Button();
            this.lvFriendRanking = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageGrabGold = new System.Windows.Forms.TabPage();
            this.txtTotalGrabGold = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtGrabGoldRankingDate = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lvGrabGoldRanking = new System.Windows.Forms.ListView();
            this.columnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageBonusRank = new System.Windows.Forms.TabPage();
            this.txtBonusRankingDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQueryBonusRankingList = new System.Windows.Forms.Button();
            this.lvBonusRankingList = new PapdMonitor.ListViewFz();
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageOrderInfo = new System.Windows.Forms.TabPage();
            this.tabControlOrders = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.lvAllOrders = new PapdMonitor.ListViewFz();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.lvWaitingPayOrders = new System.Windows.Forms.ListView();
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.lvPaidOrders = new System.Windows.Forms.ListView();
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.lvFinishOrders = new System.Windows.Forms.ListView();
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnViewOrderInfoInWeb = new System.Windows.Forms.Button();
            this.btnQueryOrders = new System.Windows.Forms.Button();
            this.tabPageRewardRecord = new System.Windows.Forms.TabPage();
            this.lvRewardRecord = new PapdMonitor.ListViewFz();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnQueryRewardRecord = new System.Windows.Forms.Button();
            this.tabPageInOutRecord = new System.Windows.Forms.TabPage();
            this.lvBatchOrderRecord = new PapdMonitor.ListViewFz();
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnQueryBatchOrderRecord = new System.Windows.Forms.Button();
            this.tabPageAddress = new System.Windows.Forms.TabPage();
            this.lvAddresses = new System.Windows.Forms.ListView();
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnQueryAddresses = new System.Windows.Forms.Button();
            this.tabPageGameCenter = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLogin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMonitor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStepManager = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHelp = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemViewActivityRules = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.tabControlSetting = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnChangeCurrentAddress = new System.Windows.Forms.Button();
            this.txtCurrentAddress = new System.Windows.Forms.TextBox();
            this.txtRechargePhone = new System.Windows.Forms.TextBox();
            this.btnChangeRechargePhone = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.listBoxMonitor = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.groupBoxAudio = new System.Windows.Forms.GroupBox();
            this.btnTestPlay = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbAudioList = new System.Windows.Forms.ComboBox();
            this.chbEnableAudio = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxQQ = new System.Windows.Forms.GroupBox();
            this.btnGetQQHwnd = new System.Windows.Forms.Button();
            this.btnTestQQSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoBtnCtrlEnter = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoBtnEnter = new System.Windows.Forms.RadioButton();
            this.cmboxQQWindow = new System.Windows.Forms.ComboBox();
            this.chbEnableQQMsg = new System.Windows.Forms.CheckBox();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.chkboxlstSearchInterface = new System.Windows.Forms.CheckedListBox();
            this.chkBoxOnlyInRecommandTime = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoVerifyCode = new System.Windows.Forms.CheckBox();
            this.cmbBoxGrabMode = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.chkboxEnableTimerStart = new System.Windows.Forms.CheckBox();
            this.chkboxIsOnlyShowHealthGoldProduct = new System.Windows.Forms.CheckBox();
            this.chkboxEnableLoopInternal = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTimer = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoopInternal)).BeginInit();
            this.tabControlQueryInfo.SuspendLayout();
            this.tabPageMonitor.SuspendLayout();
            this.panelFindProduct.SuspendLayout();
            this.tabPageMyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.tabPageGoldInfo.SuspendLayout();
            this.tabPageInvite.SuspendLayout();
            this.tabPageLastBonus.SuspendLayout();
            this.tabPageFriendRank.SuspendLayout();
            this.tabPageGrabGold.SuspendLayout();
            this.tabPageBonusRank.SuspendLayout();
            this.tabPageOrderInfo.SuspendLayout();
            this.tabControlOrders.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPageRewardRecord.SuspendLayout();
            this.tabPageInOutRecord.SuspendLayout();
            this.tabPageAddress.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlSetting.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxQQ.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "温馨提示";
            // 
            // btnCloseFind
            // 
            this.btnCloseFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseFind.Location = new System.Drawing.Point(0, 0);
            this.btnCloseFind.Name = "btnCloseFind";
            this.btnCloseFind.Size = new System.Drawing.Size(24, 22);
            this.btnCloseFind.TabIndex = 0;
            this.btnCloseFind.Text = "X";
            this.toolTip1.SetToolTip(this.btnCloseFind, "关闭");
            this.btnCloseFind.UseVisualStyleBackColor = true;
            this.btnCloseFind.Click += new System.EventHandler(this.btnCloseFind_Click);
            // 
            // btnCreateInviteQRImage
            // 
            this.btnCreateInviteQRImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateInviteQRImage.Location = new System.Drawing.Point(404, 5);
            this.btnCreateInviteQRImage.Name = "btnCreateInviteQRImage";
            this.btnCreateInviteQRImage.Size = new System.Drawing.Size(118, 30);
            this.btnCreateInviteQRImage.TabIndex = 8;
            this.btnCreateInviteQRImage.Text = "生成邀请二维码";
            this.toolTip1.SetToolTip(this.btnCreateInviteQRImage, "成功邀请一个好友+5金噢^_^");
            this.btnCreateInviteQRImage.UseVisualStyleBackColor = true;
            this.btnCreateInviteQRImage.Click += new System.EventHandler(this.btnCreateInviteQRImage_Click);
            // 
            // btnQueryPreRewardInfo
            // 
            this.btnQueryPreRewardInfo.Location = new System.Drawing.Point(417, 25);
            this.btnQueryPreRewardInfo.Name = "btnQueryPreRewardInfo";
            this.btnQueryPreRewardInfo.Size = new System.Drawing.Size(118, 30);
            this.btnQueryPreRewardInfo.TabIndex = 3;
            this.btnQueryPreRewardInfo.Text = "查询昨日奖励";
            this.toolTip1.SetToolTip(this.btnQueryPreRewardInfo, "每天至少走1000步才能领取奖励噢，并且连续领取3天还可以翻倍！");
            this.btnQueryPreRewardInfo.UseVisualStyleBackColor = true;
            this.btnQueryPreRewardInfo.Click += new System.EventHandler(this.btnQueryPreRewardInfo_Click);
            // 
            // btnQueryGrabGold
            // 
            this.btnQueryGrabGold.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryGrabGold.Location = new System.Drawing.Point(335, 5);
            this.btnQueryGrabGold.Name = "btnQueryGrabGold";
            this.btnQueryGrabGold.Size = new System.Drawing.Size(118, 30);
            this.btnQueryGrabGold.TabIndex = 8;
            this.btnQueryGrabGold.Text = "查询步步抢金";
            this.toolTip1.SetToolTip(this.btnQueryGrabGold, "每天只能抢5次噢O(∩_∩)O");
            this.btnQueryGrabGold.UseVisualStyleBackColor = true;
            this.btnQueryGrabGold.Click += new System.EventHandler(this.btnQueryGrabGold_Click);
            // 
            // checkBoxCheckVerifyCodeByOrdering
            // 
            this.checkBoxCheckVerifyCodeByOrdering.AutoSize = true;
            this.checkBoxCheckVerifyCodeByOrdering.Checked = true;
            this.checkBoxCheckVerifyCodeByOrdering.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCheckVerifyCodeByOrdering.Location = new System.Drawing.Point(16, 15);
            this.checkBoxCheckVerifyCodeByOrdering.Name = "checkBoxCheckVerifyCodeByOrdering";
            this.checkBoxCheckVerifyCodeByOrdering.Size = new System.Drawing.Size(108, 16);
            this.checkBoxCheckVerifyCodeByOrdering.TabIndex = 9;
            this.checkBoxCheckVerifyCodeByOrdering.Text = "智能拉取验证码";
            this.toolTip1.SetToolTip(this.checkBoxCheckVerifyCodeByOrdering, "采用提前输入或智能跳过验证码（注：验证码有效期为5分钟）");
            this.checkBoxCheckVerifyCodeByOrdering.UseVisualStyleBackColor = true;
            this.checkBoxCheckVerifyCodeByOrdering.CheckedChanged += new System.EventHandler(this.checkBoxCheckVerifyCodeByOrdering_CheckedChanged);
            // 
            // btnRecommandDate
            // 
            this.btnRecommandDate.Location = new System.Drawing.Point(236, 107);
            this.btnRecommandDate.Name = "btnRecommandDate";
            this.btnRecommandDate.Size = new System.Drawing.Size(30, 23);
            this.btnRecommandDate.TabIndex = 8;
            this.btnRecommandDate.Text = "R";
            this.toolTip1.SetToolTip(this.btnRecommandDate, "推荐定时抢购时间");
            this.btnRecommandDate.UseVisualStyleBackColor = true;
            this.btnRecommandDate.Click += new System.EventHandler(this.btnRecommandDate_Click);
            // 
            // numericUpDownLoopInternal
            // 
            this.numericUpDownLoopInternal.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLoopInternal.Location = new System.Drawing.Point(92, 45);
            this.numericUpDownLoopInternal.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownLoopInternal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLoopInternal.Name = "numericUpDownLoopInternal";
            this.numericUpDownLoopInternal.Size = new System.Drawing.Size(68, 21);
            this.numericUpDownLoopInternal.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numericUpDownLoopInternal, "检测间隔时间");
            this.numericUpDownLoopInternal.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownLoopInternal.ValueChanged += new System.EventHandler(this.numericUpDownCustomLoopInternal_ValueChanged);
            // 
            // tabControlQueryInfo
            // 
            this.tabControlQueryInfo.Controls.Add(this.tabPageMonitor);
            this.tabControlQueryInfo.Controls.Add(this.tabPageMyInfo);
            this.tabControlQueryInfo.Controls.Add(this.tabPageGoldInfo);
            this.tabControlQueryInfo.Controls.Add(this.tabPageInvite);
            this.tabControlQueryInfo.Controls.Add(this.tabPageLastBonus);
            this.tabControlQueryInfo.Controls.Add(this.tabPageFriendRank);
            this.tabControlQueryInfo.Controls.Add(this.tabPageGrabGold);
            this.tabControlQueryInfo.Controls.Add(this.tabPageBonusRank);
            this.tabControlQueryInfo.Controls.Add(this.tabPageOrderInfo);
            this.tabControlQueryInfo.Controls.Add(this.tabPageRewardRecord);
            this.tabControlQueryInfo.Controls.Add(this.tabPageInOutRecord);
            this.tabControlQueryInfo.Controls.Add(this.tabPageAddress);
            this.tabControlQueryInfo.Controls.Add(this.tabPageGameCenter);
            this.tabControlQueryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlQueryInfo.Location = new System.Drawing.Point(0, 25);
            this.tabControlQueryInfo.Name = "tabControlQueryInfo";
            this.tabControlQueryInfo.SelectedIndex = 0;
            this.tabControlQueryInfo.Size = new System.Drawing.Size(1034, 396);
            this.tabControlQueryInfo.TabIndex = 12;
            // 
            // tabPageMonitor
            // 
            this.tabPageMonitor.Controls.Add(this.listViewProduct);
            this.tabPageMonitor.Controls.Add(this.panelFindProduct);
            this.tabPageMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonitor.Name = "tabPageMonitor";
            this.tabPageMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonitor.Size = new System.Drawing.Size(1026, 370);
            this.tabPageMonitor.TabIndex = 0;
            this.tabPageMonitor.Text = "抢购页面";
            this.tabPageMonitor.UseVisualStyleBackColor = true;
            // 
            // listViewProduct
            // 
            this.listViewProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProduct.FullRowSelect = true;
            this.listViewProduct.GridLines = true;
            this.listViewProduct.Location = new System.Drawing.Point(3, 3);
            this.listViewProduct.Name = "listViewProduct";
            this.listViewProduct.Size = new System.Drawing.Size(1020, 342);
            this.listViewProduct.TabIndex = 7;
            this.listViewProduct.UseCompatibleStateImageBehavior = false;
            this.listViewProduct.View = System.Windows.Forms.View.Details;
            this.listViewProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewProduct_KeyDown);
            this.listViewProduct.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewProduct_MouseDoubleClick);
            this.listViewProduct.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewProduct_MouseUp);
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "序号";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 230;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "库存量";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "价格(元)";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "健康金可抵(元)";
            this.columnHeader5.Width = 100;
            // 
            // panelFindProduct
            // 
            this.panelFindProduct.Controls.Add(this.txtFindProduct);
            this.panelFindProduct.Controls.Add(this.btnCloseFind);
            this.panelFindProduct.Controls.Add(this.btnFindProduct);
            this.panelFindProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFindProduct.Location = new System.Drawing.Point(3, 345);
            this.panelFindProduct.Name = "panelFindProduct";
            this.panelFindProduct.Size = new System.Drawing.Size(1020, 22);
            this.panelFindProduct.TabIndex = 8;
            this.panelFindProduct.Visible = false;
            // 
            // txtFindProduct
            // 
            this.txtFindProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFindProduct.Location = new System.Drawing.Point(24, 0);
            this.txtFindProduct.Name = "txtFindProduct";
            this.txtFindProduct.Size = new System.Drawing.Size(921, 21);
            this.txtFindProduct.TabIndex = 1;
            this.txtFindProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindProduct_KeyDown);
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindProduct.Location = new System.Drawing.Point(945, 0);
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Size = new System.Drawing.Size(75, 22);
            this.btnFindProduct.TabIndex = 2;
            this.btnFindProduct.Text = "查询";
            this.btnFindProduct.UseVisualStyleBackColor = true;
            this.btnFindProduct.Click += new System.EventHandler(this.btnFindProduct_Click);
            // 
            // tabPageMyInfo
            // 
            this.tabPageMyInfo.Controls.Add(this.btnQueryUserInfo);
            this.tabPageMyInfo.Controls.Add(this.txtUserMobile);
            this.tabPageMyInfo.Controls.Add(this.label14);
            this.tabPageMyInfo.Controls.Add(this.label13);
            this.tabPageMyInfo.Controls.Add(this.txtUserGender);
            this.tabPageMyInfo.Controls.Add(this.label12);
            this.tabPageMyInfo.Controls.Add(this.txtUserNick);
            this.tabPageMyInfo.Controls.Add(this.label11);
            this.tabPageMyInfo.Controls.Add(this.txtUserId);
            this.tabPageMyInfo.Controls.Add(this.label10);
            this.tabPageMyInfo.Controls.Add(this.pbAvatar);
            this.tabPageMyInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageMyInfo.Name = "tabPageMyInfo";
            this.tabPageMyInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMyInfo.Size = new System.Drawing.Size(1026, 370);
            this.tabPageMyInfo.TabIndex = 2;
            this.tabPageMyInfo.Text = "我的信息";
            this.tabPageMyInfo.UseVisualStyleBackColor = true;
            // 
            // btnQueryUserInfo
            // 
            this.btnQueryUserInfo.Location = new System.Drawing.Point(550, 30);
            this.btnQueryUserInfo.Name = "btnQueryUserInfo";
            this.btnQueryUserInfo.Size = new System.Drawing.Size(106, 30);
            this.btnQueryUserInfo.TabIndex = 5;
            this.btnQueryUserInfo.Text = "查询用户信息";
            this.btnQueryUserInfo.UseVisualStyleBackColor = true;
            this.btnQueryUserInfo.Click += new System.EventHandler(this.btnQueryUserInfo_Click);
            // 
            // txtUserMobile
            // 
            this.txtUserMobile.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserMobile.Location = new System.Drawing.Point(131, 139);
            this.txtUserMobile.Name = "txtUserMobile";
            this.txtUserMobile.ReadOnly = true;
            this.txtUserMobile.Size = new System.Drawing.Size(120, 21);
            this.txtUserMobile.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(72, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "手机号：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(307, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "头像：";
            // 
            // txtUserGender
            // 
            this.txtUserGender.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserGender.Location = new System.Drawing.Point(131, 101);
            this.txtUserGender.Name = "txtUserGender";
            this.txtUserGender.ReadOnly = true;
            this.txtUserGender.Size = new System.Drawing.Size(120, 21);
            this.txtUserGender.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "性别：";
            // 
            // txtUserNick
            // 
            this.txtUserNick.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserNick.Location = new System.Drawing.Point(131, 64);
            this.txtUserNick.Name = "txtUserNick";
            this.txtUserNick.ReadOnly = true;
            this.txtUserNick.Size = new System.Drawing.Size(120, 21);
            this.txtUserNick.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(72, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "用户名：";
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserId.Location = new System.Drawing.Point(131, 27);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(120, 21);
            this.txtUserId.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "用户ID：";
            // 
            // pbAvatar
            // 
            this.pbAvatar.Location = new System.Drawing.Point(353, 28);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(127, 111);
            this.pbAvatar.TabIndex = 4;
            this.pbAvatar.TabStop = false;
            // 
            // tabPageGoldInfo
            // 
            this.tabPageGoldInfo.Controls.Add(this.buttonDelayGoldExpiredTime);
            this.tabPageGoldInfo.Controls.Add(this.btnQueryGoldInfo);
            this.tabPageGoldInfo.Controls.Add(this.txtStepReward);
            this.tabPageGoldInfo.Controls.Add(this.label18);
            this.tabPageGoldInfo.Controls.Add(this.txtInvitationReward);
            this.tabPageGoldInfo.Controls.Add(this.label17);
            this.tabPageGoldInfo.Controls.Add(this.txtCumulativeReward);
            this.tabPageGoldInfo.Controls.Add(this.label16);
            this.tabPageGoldInfo.Controls.Add(this.txtBanlance);
            this.tabPageGoldInfo.Controls.Add(this.label15);
            this.tabPageGoldInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageGoldInfo.Name = "tabPageGoldInfo";
            this.tabPageGoldInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGoldInfo.Size = new System.Drawing.Size(1026, 370);
            this.tabPageGoldInfo.TabIndex = 3;
            this.tabPageGoldInfo.Text = "我的幸福金";
            this.tabPageGoldInfo.UseVisualStyleBackColor = true;
            // 
            // buttonDelayGoldExpiredTime
            // 
            this.buttonDelayGoldExpiredTime.Location = new System.Drawing.Point(417, 69);
            this.buttonDelayGoldExpiredTime.Name = "buttonDelayGoldExpiredTime";
            this.buttonDelayGoldExpiredTime.Size = new System.Drawing.Size(106, 30);
            this.buttonDelayGoldExpiredTime.TabIndex = 7;
            this.buttonDelayGoldExpiredTime.Text = "幸福金续期";
            this.buttonDelayGoldExpiredTime.UseVisualStyleBackColor = true;
            this.buttonDelayGoldExpiredTime.Click += new System.EventHandler(this.buttonDelayGoldExpiredTime_Click);
            // 
            // btnQueryGoldInfo
            // 
            this.btnQueryGoldInfo.Location = new System.Drawing.Point(417, 25);
            this.btnQueryGoldInfo.Name = "btnQueryGoldInfo";
            this.btnQueryGoldInfo.Size = new System.Drawing.Size(106, 30);
            this.btnQueryGoldInfo.TabIndex = 6;
            this.btnQueryGoldInfo.Text = "查询幸福金";
            this.btnQueryGoldInfo.UseVisualStyleBackColor = true;
            this.btnQueryGoldInfo.Click += new System.EventHandler(this.btnQueryGoldInfo_Click);
            // 
            // txtStepReward
            // 
            this.txtStepReward.BackColor = System.Drawing.SystemColors.Control;
            this.txtStepReward.Location = new System.Drawing.Point(136, 154);
            this.txtStepReward.Name = "txtStepReward";
            this.txtStepReward.ReadOnly = true;
            this.txtStepReward.Size = new System.Drawing.Size(100, 21);
            this.txtStepReward.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(68, 158);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "走步奖励：";
            // 
            // txtInvitationReward
            // 
            this.txtInvitationReward.BackColor = System.Drawing.SystemColors.Control;
            this.txtInvitationReward.Location = new System.Drawing.Point(136, 110);
            this.txtInvitationReward.Name = "txtInvitationReward";
            this.txtInvitationReward.ReadOnly = true;
            this.txtInvitationReward.Size = new System.Drawing.Size(100, 21);
            this.txtInvitationReward.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(68, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 2;
            this.label17.Text = "邀请奖励：";
            // 
            // txtCumulativeReward
            // 
            this.txtCumulativeReward.BackColor = System.Drawing.SystemColors.Control;
            this.txtCumulativeReward.Location = new System.Drawing.Point(136, 65);
            this.txtCumulativeReward.Name = "txtCumulativeReward";
            this.txtCumulativeReward.ReadOnly = true;
            this.txtCumulativeReward.Size = new System.Drawing.Size(100, 21);
            this.txtCumulativeReward.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(68, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "累计金额：";
            // 
            // txtBanlance
            // 
            this.txtBanlance.BackColor = System.Drawing.SystemColors.Control;
            this.txtBanlance.Location = new System.Drawing.Point(136, 25);
            this.txtBanlance.Name = "txtBanlance";
            this.txtBanlance.ReadOnly = true;
            this.txtBanlance.Size = new System.Drawing.Size(100, 21);
            this.txtBanlance.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(92, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "余额：";
            // 
            // tabPageInvite
            // 
            this.tabPageInvite.Controls.Add(this.lvInvitees);
            this.tabPageInvite.Controls.Add(this.btnCreateInviteQRImage);
            this.tabPageInvite.Controls.Add(this.btnQueryInvitees);
            this.tabPageInvite.Location = new System.Drawing.Point(4, 22);
            this.tabPageInvite.Name = "tabPageInvite";
            this.tabPageInvite.Size = new System.Drawing.Size(1026, 370);
            this.tabPageInvite.TabIndex = 8;
            this.tabPageInvite.Text = "我的邀请";
            this.tabPageInvite.UseVisualStyleBackColor = true;
            // 
            // lvInvitees
            // 
            this.lvInvitees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInvitees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48});
            this.lvInvitees.FullRowSelect = true;
            this.lvInvitees.GridLines = true;
            this.lvInvitees.Location = new System.Drawing.Point(2, 39);
            this.lvInvitees.Name = "lvInvitees";
            this.lvInvitees.Size = new System.Drawing.Size(783, 245);
            this.lvInvitees.TabIndex = 9;
            this.lvInvitees.UseCompatibleStateImageBehavior = false;
            this.lvInvitees.View = System.Windows.Forms.View.Details;
            this.lvInvitees.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvInvitees_MouseUp);
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "序号";
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "昵称";
            this.columnHeader43.Width = 150;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "手机号";
            this.columnHeader44.Width = 120;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "邀请状态";
            this.columnHeader45.Width = 80;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "是否已提醒";
            this.columnHeader46.Width = 100;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "用户ID";
            this.columnHeader47.Width = 120;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "Stage";
            // 
            // btnQueryInvitees
            // 
            this.btnQueryInvitees.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryInvitees.Location = new System.Drawing.Point(267, 5);
            this.btnQueryInvitees.Name = "btnQueryInvitees";
            this.btnQueryInvitees.Size = new System.Drawing.Size(118, 30);
            this.btnQueryInvitees.TabIndex = 8;
            this.btnQueryInvitees.Text = "查询我的邀请";
            this.btnQueryInvitees.UseVisualStyleBackColor = true;
            this.btnQueryInvitees.Click += new System.EventHandler(this.btnQueryInvitees_Click);
            // 
            // tabPageLastBonus
            // 
            this.tabPageLastBonus.Controls.Add(this.btnFetchReward);
            this.tabPageLastBonus.Controls.Add(this.btnQueryPreRewardInfo);
            this.tabPageLastBonus.Controls.Add(this.txtPreSteps);
            this.tabPageLastBonus.Controls.Add(this.txtIsPreMoneyFetch);
            this.tabPageLastBonus.Controls.Add(this.label26);
            this.tabPageLastBonus.Controls.Add(this.txtPreRewardID);
            this.tabPageLastBonus.Controls.Add(this.label9);
            this.tabPageLastBonus.Controls.Add(this.txtIsPreDoubleMoney);
            this.tabPageLastBonus.Controls.Add(this.label8);
            this.tabPageLastBonus.Controls.Add(this.txtPreMoney);
            this.tabPageLastBonus.Controls.Add(this.label7);
            this.tabPageLastBonus.Controls.Add(this.label5);
            this.tabPageLastBonus.Location = new System.Drawing.Point(4, 22);
            this.tabPageLastBonus.Name = "tabPageLastBonus";
            this.tabPageLastBonus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLastBonus.Size = new System.Drawing.Size(1026, 370);
            this.tabPageLastBonus.TabIndex = 1;
            this.tabPageLastBonus.Text = "昨日计步奖励";
            this.tabPageLastBonus.UseVisualStyleBackColor = true;
            // 
            // btnFetchReward
            // 
            this.btnFetchReward.Location = new System.Drawing.Point(282, 146);
            this.btnFetchReward.Name = "btnFetchReward";
            this.btnFetchReward.Size = new System.Drawing.Size(70, 23);
            this.btnFetchReward.TabIndex = 4;
            this.btnFetchReward.Text = "领取";
            this.btnFetchReward.UseVisualStyleBackColor = true;
            this.btnFetchReward.Visible = false;
            this.btnFetchReward.Click += new System.EventHandler(this.btnFetchReward_Click);
            // 
            // txtPreSteps
            // 
            this.txtPreSteps.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreSteps.Location = new System.Drawing.Point(172, 182);
            this.txtPreSteps.Name = "txtPreSteps";
            this.txtPreSteps.ReadOnly = true;
            this.txtPreSteps.Size = new System.Drawing.Size(101, 21);
            this.txtPreSteps.TabIndex = 2;
            // 
            // txtIsPreMoneyFetch
            // 
            this.txtIsPreMoneyFetch.BackColor = System.Drawing.SystemColors.Control;
            this.txtIsPreMoneyFetch.Location = new System.Drawing.Point(173, 146);
            this.txtIsPreMoneyFetch.Name = "txtIsPreMoneyFetch";
            this.txtIsPreMoneyFetch.ReadOnly = true;
            this.txtIsPreMoneyFetch.Size = new System.Drawing.Size(101, 21);
            this.txtIsPreMoneyFetch.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(104, 187);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 0;
            this.label26.Text = "预计步数：";
            // 
            // txtPreRewardID
            // 
            this.txtPreRewardID.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreRewardID.Location = new System.Drawing.Point(172, 110);
            this.txtPreRewardID.Name = "txtPreRewardID";
            this.txtPreRewardID.ReadOnly = true;
            this.txtPreRewardID.Size = new System.Drawing.Size(101, 21);
            this.txtPreRewardID.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "昨日奖励是否领取：";
            // 
            // txtIsPreDoubleMoney
            // 
            this.txtIsPreDoubleMoney.BackColor = System.Drawing.SystemColors.Control;
            this.txtIsPreDoubleMoney.Location = new System.Drawing.Point(173, 68);
            this.txtIsPreDoubleMoney.Name = "txtIsPreDoubleMoney";
            this.txtIsPreDoubleMoney.ReadOnly = true;
            this.txtIsPreDoubleMoney.Size = new System.Drawing.Size(101, 21);
            this.txtIsPreDoubleMoney.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "昨日奖励ID：";
            // 
            // txtPreMoney
            // 
            this.txtPreMoney.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreMoney.Location = new System.Drawing.Point(173, 30);
            this.txtPreMoney.Name = "txtPreMoney";
            this.txtPreMoney.ReadOnly = true;
            this.txtPreMoney.Size = new System.Drawing.Size(100, 21);
            this.txtPreMoney.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "昨日是否翻倍：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "昨日计步奖励：";
            // 
            // tabPageFriendRank
            // 
            this.tabPageFriendRank.Controls.Add(this.txtRankingDate);
            this.tabPageFriendRank.Controls.Add(this.label19);
            this.tabPageFriendRank.Controls.Add(this.btnQueryFriendRanking);
            this.tabPageFriendRank.Controls.Add(this.lvFriendRanking);
            this.tabPageFriendRank.Location = new System.Drawing.Point(4, 22);
            this.tabPageFriendRank.Name = "tabPageFriendRank";
            this.tabPageFriendRank.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFriendRank.Size = new System.Drawing.Size(1026, 370);
            this.tabPageFriendRank.TabIndex = 4;
            this.tabPageFriendRank.Text = "好友排行榜";
            this.tabPageFriendRank.UseVisualStyleBackColor = true;
            // 
            // txtRankingDate
            // 
            this.txtRankingDate.Location = new System.Drawing.Point(75, 9);
            this.txtRankingDate.Name = "txtRankingDate";
            this.txtRankingDate.ReadOnly = true;
            this.txtRankingDate.Size = new System.Drawing.Size(139, 21);
            this.txtRankingDate.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 5;
            this.label19.Text = "排行时间：";
            // 
            // btnQueryFriendRanking
            // 
            this.btnQueryFriendRanking.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryFriendRanking.Location = new System.Drawing.Point(335, 5);
            this.btnQueryFriendRanking.Name = "btnQueryFriendRanking";
            this.btnQueryFriendRanking.Size = new System.Drawing.Size(118, 30);
            this.btnQueryFriendRanking.TabIndex = 4;
            this.btnQueryFriendRanking.Text = "查询好友排行";
            this.btnQueryFriendRanking.UseVisualStyleBackColor = true;
            this.btnQueryFriendRanking.Click += new System.EventHandler(this.btnQueryFriendRanking_Click);
            // 
            // lvFriendRanking
            // 
            this.lvFriendRanking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFriendRanking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvFriendRanking.FullRowSelect = true;
            this.lvFriendRanking.GridLines = true;
            this.lvFriendRanking.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFriendRanking.Location = new System.Drawing.Point(3, 39);
            this.lvFriendRanking.Name = "lvFriendRanking";
            this.lvFriendRanking.Size = new System.Drawing.Size(783, 245);
            this.lvFriendRanking.TabIndex = 0;
            this.lvFriendRanking.UseCompatibleStateImageBehavior = false;
            this.lvFriendRanking.View = System.Windows.Forms.View.Details;
            this.lvFriendRanking.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvFriendRanking_MouseUp);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "排名";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "名称";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "步数";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "金额(元)";
            this.columnHeader9.Width = 150;
            // 
            // tabPageGrabGold
            // 
            this.tabPageGrabGold.Controls.Add(this.txtTotalGrabGold);
            this.tabPageGrabGold.Controls.Add(this.label25);
            this.tabPageGrabGold.Controls.Add(this.txtGrabGoldRankingDate);
            this.tabPageGrabGold.Controls.Add(this.label24);
            this.tabPageGrabGold.Controls.Add(this.btnQueryGrabGold);
            this.tabPageGrabGold.Controls.Add(this.lvGrabGoldRanking);
            this.tabPageGrabGold.Location = new System.Drawing.Point(4, 22);
            this.tabPageGrabGold.Name = "tabPageGrabGold";
            this.tabPageGrabGold.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGrabGold.Size = new System.Drawing.Size(1026, 370);
            this.tabPageGrabGold.TabIndex = 11;
            this.tabPageGrabGold.Text = "步步抢金";
            this.tabPageGrabGold.UseVisualStyleBackColor = true;
            // 
            // txtTotalGrabGold
            // 
            this.txtTotalGrabGold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalGrabGold.Location = new System.Drawing.Point(667, 9);
            this.txtTotalGrabGold.Name = "txtTotalGrabGold";
            this.txtTotalGrabGold.ReadOnly = true;
            this.txtTotalGrabGold.Size = new System.Drawing.Size(114, 21);
            this.txtTotalGrabGold.TabIndex = 10;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(599, 14);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 12);
            this.label25.TabIndex = 9;
            this.label25.Text = "累计抢金：";
            // 
            // txtGrabGoldRankingDate
            // 
            this.txtGrabGoldRankingDate.Location = new System.Drawing.Point(75, 9);
            this.txtGrabGoldRankingDate.Name = "txtGrabGoldRankingDate";
            this.txtGrabGoldRankingDate.ReadOnly = true;
            this.txtGrabGoldRankingDate.Size = new System.Drawing.Size(139, 21);
            this.txtGrabGoldRankingDate.TabIndex = 10;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 12);
            this.label24.TabIndex = 9;
            this.label24.Text = "排行时间：";
            // 
            // lvGrabGoldRanking
            // 
            this.lvGrabGoldRanking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGrabGoldRanking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader59,
            this.columnHeader60,
            this.columnHeader61,
            this.columnHeader62,
            this.columnHeader58});
            this.lvGrabGoldRanking.FullRowSelect = true;
            this.lvGrabGoldRanking.GridLines = true;
            this.lvGrabGoldRanking.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvGrabGoldRanking.Location = new System.Drawing.Point(3, 39);
            this.lvGrabGoldRanking.Name = "lvGrabGoldRanking";
            this.lvGrabGoldRanking.Size = new System.Drawing.Size(783, 245);
            this.lvGrabGoldRanking.TabIndex = 7;
            this.lvGrabGoldRanking.UseCompatibleStateImageBehavior = false;
            this.lvGrabGoldRanking.View = System.Windows.Forms.View.Details;
            this.lvGrabGoldRanking.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvGrabGoldRanking_MouseUp);
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "名称";
            this.columnHeader59.Width = 200;
            // 
            // columnHeader60
            // 
            this.columnHeader60.Text = "步数";
            this.columnHeader60.Width = 150;
            // 
            // columnHeader61
            // 
            this.columnHeader61.Text = "是否领取奖励";
            this.columnHeader61.Width = 100;
            // 
            // columnHeader62
            // 
            this.columnHeader62.Text = "是否可抢";
            this.columnHeader62.Width = 150;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "可抢金额(元)";
            this.columnHeader58.Width = 100;
            // 
            // tabPageBonusRank
            // 
            this.tabPageBonusRank.Controls.Add(this.txtBonusRankingDate);
            this.tabPageBonusRank.Controls.Add(this.label4);
            this.tabPageBonusRank.Controls.Add(this.btnQueryBonusRankingList);
            this.tabPageBonusRank.Controls.Add(this.lvBonusRankingList);
            this.tabPageBonusRank.Location = new System.Drawing.Point(4, 22);
            this.tabPageBonusRank.Name = "tabPageBonusRank";
            this.tabPageBonusRank.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBonusRank.Size = new System.Drawing.Size(1026, 370);
            this.tabPageBonusRank.TabIndex = 9;
            this.tabPageBonusRank.Text = "赚钱排行榜";
            this.tabPageBonusRank.UseVisualStyleBackColor = true;
            // 
            // txtBonusRankingDate
            // 
            this.txtBonusRankingDate.Location = new System.Drawing.Point(75, 9);
            this.txtBonusRankingDate.Name = "txtBonusRankingDate";
            this.txtBonusRankingDate.ReadOnly = true;
            this.txtBonusRankingDate.Size = new System.Drawing.Size(139, 21);
            this.txtBonusRankingDate.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "排行时间：";
            // 
            // btnQueryBonusRankingList
            // 
            this.btnQueryBonusRankingList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryBonusRankingList.Location = new System.Drawing.Point(335, 5);
            this.btnQueryBonusRankingList.Name = "btnQueryBonusRankingList";
            this.btnQueryBonusRankingList.Size = new System.Drawing.Size(118, 30);
            this.btnQueryBonusRankingList.TabIndex = 8;
            this.btnQueryBonusRankingList.Text = "查询赚钱排行";
            this.btnQueryBonusRankingList.UseVisualStyleBackColor = true;
            this.btnQueryBonusRankingList.Click += new System.EventHandler(this.btnQueryBonusRankingList_Click);
            // 
            // lvBonusRankingList
            // 
            this.lvBonusRankingList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBonusRankingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52});
            this.lvBonusRankingList.FullRowSelect = true;
            this.lvBonusRankingList.GridLines = true;
            this.lvBonusRankingList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBonusRankingList.Location = new System.Drawing.Point(3, 39);
            this.lvBonusRankingList.Name = "lvBonusRankingList";
            this.lvBonusRankingList.Size = new System.Drawing.Size(783, 245);
            this.lvBonusRankingList.TabIndex = 7;
            this.lvBonusRankingList.UseCompatibleStateImageBehavior = false;
            this.lvBonusRankingList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "排名";
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "名称";
            this.columnHeader50.Width = 200;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "累计步数";
            this.columnHeader51.Width = 150;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "累计金额(元)";
            this.columnHeader52.Width = 150;
            // 
            // tabPageOrderInfo
            // 
            this.tabPageOrderInfo.Controls.Add(this.tabControlOrders);
            this.tabPageOrderInfo.Controls.Add(this.btnViewOrderInfoInWeb);
            this.tabPageOrderInfo.Controls.Add(this.btnQueryOrders);
            this.tabPageOrderInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrderInfo.Name = "tabPageOrderInfo";
            this.tabPageOrderInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrderInfo.Size = new System.Drawing.Size(1026, 370);
            this.tabPageOrderInfo.TabIndex = 5;
            this.tabPageOrderInfo.Text = "订单信息";
            this.tabPageOrderInfo.UseVisualStyleBackColor = true;
            // 
            // tabControlOrders
            // 
            this.tabControlOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOrders.Controls.Add(this.tabPage11);
            this.tabControlOrders.Controls.Add(this.tabPage12);
            this.tabControlOrders.Controls.Add(this.tabPage13);
            this.tabControlOrders.Controls.Add(this.tabPage14);
            this.tabControlOrders.Location = new System.Drawing.Point(3, 39);
            this.tabControlOrders.Multiline = true;
            this.tabControlOrders.Name = "tabControlOrders";
            this.tabControlOrders.SelectedIndex = 0;
            this.tabControlOrders.Size = new System.Drawing.Size(783, 245);
            this.tabControlOrders.TabIndex = 6;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.lvAllOrders);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(775, 219);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "全部";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // lvAllOrders
            // 
            this.lvAllOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader18,
            this.columnHeader13,
            this.columnHeader16,
            this.columnHeader15});
            this.lvAllOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAllOrders.FullRowSelect = true;
            this.lvAllOrders.GridLines = true;
            this.lvAllOrders.Location = new System.Drawing.Point(3, 3);
            this.lvAllOrders.Name = "lvAllOrders";
            this.lvAllOrders.Size = new System.Drawing.Size(769, 213);
            this.lvAllOrders.TabIndex = 0;
            this.lvAllOrders.UseCompatibleStateImageBehavior = false;
            this.lvAllOrders.View = System.Windows.Forms.View.Details;
            this.lvAllOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAllOrders_MouseDoubleClick);
            this.lvAllOrders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvAllOrders_MouseUp);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "序号";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "订单时间";
            this.columnHeader18.Width = 200;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "商品名称";
            this.columnHeader13.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "总价(元)";
            this.columnHeader16.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "订单状态";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.lvWaitingPayOrders);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(775, 219);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "待付款";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // lvWaitingPayOrders
            // 
            this.lvWaitingPayOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31});
            this.lvWaitingPayOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWaitingPayOrders.FullRowSelect = true;
            this.lvWaitingPayOrders.GridLines = true;
            this.lvWaitingPayOrders.Location = new System.Drawing.Point(3, 3);
            this.lvWaitingPayOrders.Name = "lvWaitingPayOrders";
            this.lvWaitingPayOrders.Size = new System.Drawing.Size(769, 213);
            this.lvWaitingPayOrders.TabIndex = 1;
            this.lvWaitingPayOrders.UseCompatibleStateImageBehavior = false;
            this.lvWaitingPayOrders.View = System.Windows.Forms.View.Details;
            this.lvWaitingPayOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAllOrders_MouseDoubleClick);
            this.lvWaitingPayOrders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvAllOrders_MouseUp);
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "序号";
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "订单时间";
            this.columnHeader28.Width = 200;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "商品名称";
            this.columnHeader29.Width = 200;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "总价";
            this.columnHeader30.Width = 80;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "订单状态";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.lvPaidOrders);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(775, 219);
            this.tabPage13.TabIndex = 2;
            this.tabPage13.Text = "进行中";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // lvPaidOrders
            // 
            this.lvPaidOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36});
            this.lvPaidOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPaidOrders.FullRowSelect = true;
            this.lvPaidOrders.GridLines = true;
            this.lvPaidOrders.Location = new System.Drawing.Point(3, 3);
            this.lvPaidOrders.Name = "lvPaidOrders";
            this.lvPaidOrders.Size = new System.Drawing.Size(769, 213);
            this.lvPaidOrders.TabIndex = 1;
            this.lvPaidOrders.UseCompatibleStateImageBehavior = false;
            this.lvPaidOrders.View = System.Windows.Forms.View.Details;
            this.lvPaidOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAllOrders_MouseDoubleClick);
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "序号";
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "订单时间";
            this.columnHeader33.Width = 200;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "商品名称";
            this.columnHeader34.Width = 200;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "总价";
            this.columnHeader35.Width = 80;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "订单状态";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.lvFinishOrders);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(775, 219);
            this.tabPage14.TabIndex = 3;
            this.tabPage14.Text = "已完成";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // lvFinishOrders
            // 
            this.lvFinishOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41});
            this.lvFinishOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFinishOrders.FullRowSelect = true;
            this.lvFinishOrders.GridLines = true;
            this.lvFinishOrders.Location = new System.Drawing.Point(3, 3);
            this.lvFinishOrders.Name = "lvFinishOrders";
            this.lvFinishOrders.Size = new System.Drawing.Size(769, 213);
            this.lvFinishOrders.TabIndex = 1;
            this.lvFinishOrders.UseCompatibleStateImageBehavior = false;
            this.lvFinishOrders.View = System.Windows.Forms.View.Details;
            this.lvFinishOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAllOrders_MouseDoubleClick);
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "序号";
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "订单时间";
            this.columnHeader38.Width = 200;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "商品名称";
            this.columnHeader39.Width = 200;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "总价";
            this.columnHeader40.Width = 80;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "订单状态";
            // 
            // btnViewOrderInfoInWeb
            // 
            this.btnViewOrderInfoInWeb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnViewOrderInfoInWeb.Location = new System.Drawing.Point(399, 5);
            this.btnViewOrderInfoInWeb.Name = "btnViewOrderInfoInWeb";
            this.btnViewOrderInfoInWeb.Size = new System.Drawing.Size(118, 30);
            this.btnViewOrderInfoInWeb.TabIndex = 5;
            this.btnViewOrderInfoInWeb.Text = "内置浏览订单";
            this.btnViewOrderInfoInWeb.UseVisualStyleBackColor = true;
            this.btnViewOrderInfoInWeb.Click += new System.EventHandler(this.btnViewOrderInfoInWeb_Click);
            // 
            // btnQueryOrders
            // 
            this.btnQueryOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryOrders.Location = new System.Drawing.Point(272, 5);
            this.btnQueryOrders.Name = "btnQueryOrders";
            this.btnQueryOrders.Size = new System.Drawing.Size(118, 30);
            this.btnQueryOrders.TabIndex = 5;
            this.btnQueryOrders.Text = "查询订单";
            this.btnQueryOrders.UseVisualStyleBackColor = true;
            this.btnQueryOrders.Click += new System.EventHandler(this.btnQueryOrders_Click);
            // 
            // tabPageRewardRecord
            // 
            this.tabPageRewardRecord.Controls.Add(this.lvRewardRecord);
            this.tabPageRewardRecord.Controls.Add(this.btnQueryRewardRecord);
            this.tabPageRewardRecord.Location = new System.Drawing.Point(4, 22);
            this.tabPageRewardRecord.Name = "tabPageRewardRecord";
            this.tabPageRewardRecord.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRewardRecord.Size = new System.Drawing.Size(1026, 370);
            this.tabPageRewardRecord.TabIndex = 6;
            this.tabPageRewardRecord.Text = "夺金明细";
            this.tabPageRewardRecord.UseVisualStyleBackColor = true;
            // 
            // lvRewardRecord
            // 
            this.lvRewardRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRewardRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader12,
            this.columnHeader10,
            this.columnHeader57,
            this.columnHeader11});
            this.lvRewardRecord.FullRowSelect = true;
            this.lvRewardRecord.GridLines = true;
            this.lvRewardRecord.Location = new System.Drawing.Point(3, 39);
            this.lvRewardRecord.Name = "lvRewardRecord";
            this.lvRewardRecord.Size = new System.Drawing.Size(783, 245);
            this.lvRewardRecord.TabIndex = 7;
            this.lvRewardRecord.UseCompatibleStateImageBehavior = false;
            this.lvRewardRecord.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "序号";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "时间";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "信息";
            this.columnHeader10.Width = 300;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "奖励";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "领取状态";
            this.columnHeader11.Width = 150;
            // 
            // btnQueryRewardRecord
            // 
            this.btnQueryRewardRecord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryRewardRecord.Location = new System.Drawing.Point(335, 5);
            this.btnQueryRewardRecord.Name = "btnQueryRewardRecord";
            this.btnQueryRewardRecord.Size = new System.Drawing.Size(118, 30);
            this.btnQueryRewardRecord.TabIndex = 6;
            this.btnQueryRewardRecord.Text = "查询夺金明细";
            this.btnQueryRewardRecord.UseVisualStyleBackColor = true;
            this.btnQueryRewardRecord.Click += new System.EventHandler(this.btnQueryRewardRecord_Click);
            // 
            // tabPageInOutRecord
            // 
            this.tabPageInOutRecord.Controls.Add(this.lvBatchOrderRecord);
            this.tabPageInOutRecord.Controls.Add(this.btnQueryBatchOrderRecord);
            this.tabPageInOutRecord.Location = new System.Drawing.Point(4, 22);
            this.tabPageInOutRecord.Name = "tabPageInOutRecord";
            this.tabPageInOutRecord.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInOutRecord.Size = new System.Drawing.Size(1026, 370);
            this.tabPageInOutRecord.TabIndex = 10;
            this.tabPageInOutRecord.Text = "收支明细";
            this.tabPageInOutRecord.UseVisualStyleBackColor = true;
            // 
            // lvBatchOrderRecord
            // 
            this.lvBatchOrderRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBatchOrderRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader56});
            this.lvBatchOrderRecord.FullRowSelect = true;
            this.lvBatchOrderRecord.GridLines = true;
            this.lvBatchOrderRecord.Location = new System.Drawing.Point(3, 39);
            this.lvBatchOrderRecord.Name = "lvBatchOrderRecord";
            this.lvBatchOrderRecord.Size = new System.Drawing.Size(783, 245);
            this.lvBatchOrderRecord.TabIndex = 9;
            this.lvBatchOrderRecord.UseCompatibleStateImageBehavior = false;
            this.lvBatchOrderRecord.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "序号";
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "时间";
            this.columnHeader54.Width = 150;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "信息";
            this.columnHeader55.Width = 300;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "收支";
            this.columnHeader56.Width = 150;
            // 
            // btnQueryBatchOrderRecord
            // 
            this.btnQueryBatchOrderRecord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryBatchOrderRecord.Location = new System.Drawing.Point(335, 5);
            this.btnQueryBatchOrderRecord.Name = "btnQueryBatchOrderRecord";
            this.btnQueryBatchOrderRecord.Size = new System.Drawing.Size(118, 30);
            this.btnQueryBatchOrderRecord.TabIndex = 8;
            this.btnQueryBatchOrderRecord.Text = "查询收支明细";
            this.btnQueryBatchOrderRecord.UseVisualStyleBackColor = true;
            this.btnQueryBatchOrderRecord.Click += new System.EventHandler(this.btnQueryBatchOrderRecord_Click);
            // 
            // tabPageAddress
            // 
            this.tabPageAddress.Controls.Add(this.lvAddresses);
            this.tabPageAddress.Controls.Add(this.btnQueryAddresses);
            this.tabPageAddress.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddress.Name = "tabPageAddress";
            this.tabPageAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddress.Size = new System.Drawing.Size(1026, 370);
            this.tabPageAddress.TabIndex = 7;
            this.tabPageAddress.Text = "收货地址";
            this.tabPageAddress.UseVisualStyleBackColor = true;
            // 
            // lvAddresses
            // 
            this.lvAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAddresses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader20,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader26});
            this.lvAddresses.FullRowSelect = true;
            this.lvAddresses.GridLines = true;
            this.lvAddresses.Location = new System.Drawing.Point(3, 39);
            this.lvAddresses.Name = "lvAddresses";
            this.lvAddresses.Size = new System.Drawing.Size(783, 245);
            this.lvAddresses.TabIndex = 8;
            this.lvAddresses.UseCompatibleStateImageBehavior = false;
            this.lvAddresses.View = System.Windows.Forms.View.Details;
            this.lvAddresses.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvAddresses_MouseUp);
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "序号";
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "收件人";
            this.columnHeader24.Width = 80;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "收件人手机号";
            this.columnHeader25.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "省";
            this.columnHeader21.Width = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "市";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "街道";
            this.columnHeader23.Width = 300;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "默认";
            // 
            // btnQueryAddresses
            // 
            this.btnQueryAddresses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQueryAddresses.Location = new System.Drawing.Point(335, 5);
            this.btnQueryAddresses.Name = "btnQueryAddresses";
            this.btnQueryAddresses.Size = new System.Drawing.Size(118, 30);
            this.btnQueryAddresses.TabIndex = 7;
            this.btnQueryAddresses.Text = "查询收货地址";
            this.btnQueryAddresses.UseVisualStyleBackColor = true;
            this.btnQueryAddresses.Click += new System.EventHandler(this.btnQueryAddresses_Click);
            // 
            // tabPageGameCenter
            // 
            this.tabPageGameCenter.Location = new System.Drawing.Point(4, 22);
            this.tabPageGameCenter.Name = "tabPageGameCenter";
            this.tabPageGameCenter.Size = new System.Drawing.Size(1026, 370);
            this.tabPageGameCenter.TabIndex = 13;
            this.tabPageGameCenter.Text = "游戏中心";
            this.tabPageGameCenter.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1034, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "↓隐藏设置区域↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLogin,
            this.toolStripButtonSearch,
            this.toolStripButtonMonitor,
            this.toolStripButtonStepManager,
            this.toolStripButtonTest,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButtonHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1034, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLogin
            // 
            this.toolStripButtonLogin.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLogin.Image")));
            this.toolStripButtonLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLogin.Name = "toolStripButtonLogin";
            this.toolStripButtonLogin.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonLogin.Text = "登录";
            this.toolStripButtonLogin.Click += new System.EventHandler(this.toolStripButtonLogin_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonSearch.Text = "查询";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonMonitor
            // 
            this.toolStripButtonMonitor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMonitor.Image")));
            this.toolStripButtonMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMonitor.Name = "toolStripButtonMonitor";
            this.toolStripButtonMonitor.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonMonitor.Text = "开始抢购";
            this.toolStripButtonMonitor.Click += new System.EventHandler(this.toolStripButtonMonitor_Click);
            // 
            // toolStripButtonStepManager
            // 
            this.toolStripButtonStepManager.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStepManager.Image")));
            this.toolStripButtonStepManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStepManager.Name = "toolStripButtonStepManager";
            this.toolStripButtonStepManager.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonStepManager.Text = "走步数据管理";
            this.toolStripButtonStepManager.Click += new System.EventHandler(this.toolStripButtonStepManager_Click);
            // 
            // toolStripButtonTest
            // 
            this.toolStripButtonTest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTest.Image")));
            this.toolStripButtonTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTest.Name = "toolStripButtonTest";
            this.toolStripButtonTest.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonTest.Text = "测试";
            this.toolStripButtonTest.Click += new System.EventHandler(this.toolStripButtonTest_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton2.Text = "代理设置";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton1.Text = "通用设置";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonHelp
            // 
            this.toolStripButtonHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemViewActivityRules,
            this.toolStripMenuItemAbout});
            this.toolStripButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHelp.Image")));
            this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHelp.Name = "toolStripButtonHelp";
            this.toolStripButtonHelp.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonHelp.Text = "帮助";
            this.toolStripButtonHelp.ButtonClick += new System.EventHandler(this.toolStripButtonHelp_ButtonClick);
            // 
            // toolStripMenuItemViewActivityRules
            // 
            this.toolStripMenuItemViewActivityRules.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItemViewActivityRules.Name = "toolStripMenuItemViewActivityRules";
            this.toolStripMenuItemViewActivityRules.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemViewActivityRules.Text = "活动规则";
            this.toolStripMenuItemViewActivityRules.Click += new System.EventHandler(this.toolStripMenuItemViewActivityRules_Click);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemAbout.Text = "关于";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.groupBox1);
            this.panelBottom.Controls.Add(this.tabControlSetting);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 444);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1034, 196);
            this.panelBottom.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxOutput);
            this.groupBox1.Location = new System.Drawing.Point(539, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 188);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出区";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BackColor = System.Drawing.Color.White;
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(3, 17);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(489, 168);
            this.textBoxOutput.TabIndex = 0;
            this.textBoxOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOutput_KeyDown);
            this.textBoxOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxOutput_MouseDown);
            // 
            // tabControlSetting
            // 
            this.tabControlSetting.Controls.Add(this.tabPage1);
            this.tabControlSetting.Controls.Add(this.tabPage15);
            this.tabControlSetting.Controls.Add(this.tabPage2);
            this.tabControlSetting.Controls.Add(this.tabPage17);
            this.tabControlSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlSetting.Location = new System.Drawing.Point(0, 0);
            this.tabControlSetting.Name = "tabControlSetting";
            this.tabControlSetting.SelectedIndex = 0;
            this.tabControlSetting.Size = new System.Drawing.Size(531, 196);
            this.tabControlSetting.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnChangeCurrentAddress);
            this.tabPage1.Controls.Add(this.txtCurrentAddress);
            this.tabPage1.Controls.Add(this.txtRechargePhone);
            this.tabPage1.Controls.Add(this.btnChangeRechargePhone);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.listBoxMonitor);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(523, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "抢购设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnChangeCurrentAddress
            // 
            this.btnChangeCurrentAddress.Location = new System.Drawing.Point(487, 104);
            this.btnChangeCurrentAddress.Name = "btnChangeCurrentAddress";
            this.btnChangeCurrentAddress.Size = new System.Drawing.Size(28, 23);
            this.btnChangeCurrentAddress.TabIndex = 5;
            this.btnChangeCurrentAddress.Text = "改";
            this.btnChangeCurrentAddress.UseVisualStyleBackColor = true;
            this.btnChangeCurrentAddress.Click += new System.EventHandler(this.btnChangeCurrentAddress_Click);
            // 
            // txtCurrentAddress
            // 
            this.txtCurrentAddress.Location = new System.Drawing.Point(333, 105);
            this.txtCurrentAddress.Name = "txtCurrentAddress";
            this.txtCurrentAddress.ReadOnly = true;
            this.txtCurrentAddress.Size = new System.Drawing.Size(149, 21);
            this.txtCurrentAddress.TabIndex = 4;
            // 
            // txtRechargePhone
            // 
            this.txtRechargePhone.Location = new System.Drawing.Point(333, 33);
            this.txtRechargePhone.Name = "txtRechargePhone";
            this.txtRechargePhone.ReadOnly = true;
            this.txtRechargePhone.Size = new System.Drawing.Size(149, 21);
            this.txtRechargePhone.TabIndex = 4;
            // 
            // btnChangeRechargePhone
            // 
            this.btnChangeRechargePhone.Location = new System.Drawing.Point(487, 32);
            this.btnChangeRechargePhone.Name = "btnChangeRechargePhone";
            this.btnChangeRechargePhone.Size = new System.Drawing.Size(28, 23);
            this.btnChangeRechargePhone.TabIndex = 5;
            this.btnChangeRechargePhone.Text = "改";
            this.btnChangeRechargePhone.UseVisualStyleBackColor = true;
            this.btnChangeRechargePhone.Click += new System.EventHandler(this.btnChangeRechargePhone_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(332, 85);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 3;
            this.label22.Text = "收货地址：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(332, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 3;
            this.label21.Text = "充值手机号：";
            // 
            // listBoxMonitor
            // 
            this.listBoxMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxMonitor.FormattingEnabled = true;
            this.listBoxMonitor.ItemHeight = 12;
            this.listBoxMonitor.Location = new System.Drawing.Point(9, 26);
            this.listBoxMonitor.Name = "listBoxMonitor";
            this.listBoxMonitor.Size = new System.Drawing.Size(301, 136);
            this.listBoxMonitor.TabIndex = 2;
            this.listBoxMonitor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxMonitor_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "抢购列表:";
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.groupBoxAudio);
            this.tabPage15.Controls.Add(this.chbEnableAudio);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(523, 170);
            this.tabPage15.TabIndex = 3;
            this.tabPage15.Text = "声音提醒";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.Controls.Add(this.btnTestPlay);
            this.groupBoxAudio.Controls.Add(this.label20);
            this.groupBoxAudio.Controls.Add(this.cmbAudioList);
            this.groupBoxAudio.Location = new System.Drawing.Point(34, 39);
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.Size = new System.Drawing.Size(336, 45);
            this.groupBoxAudio.TabIndex = 9;
            this.groupBoxAudio.TabStop = false;
            this.groupBoxAudio.Text = "设置";
            // 
            // btnTestPlay
            // 
            this.btnTestPlay.Location = new System.Drawing.Point(254, 13);
            this.btnTestPlay.Name = "btnTestPlay";
            this.btnTestPlay.Size = new System.Drawing.Size(75, 23);
            this.btnTestPlay.TabIndex = 2;
            this.btnTestPlay.Text = "试听";
            this.btnTestPlay.UseVisualStyleBackColor = true;
            this.btnTestPlay.Click += new System.EventHandler(this.btnTestPlay_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "选择声音：";
            // 
            // cmbAudioList
            // 
            this.cmbAudioList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudioList.FormattingEnabled = true;
            this.cmbAudioList.Location = new System.Drawing.Point(79, 15);
            this.cmbAudioList.Name = "cmbAudioList";
            this.cmbAudioList.Size = new System.Drawing.Size(159, 20);
            this.cmbAudioList.TabIndex = 1;
            this.cmbAudioList.SelectedIndexChanged += new System.EventHandler(this.cmbAudioList_SelectedIndexChanged);
            // 
            // chbEnableAudio
            // 
            this.chbEnableAudio.AutoSize = true;
            this.chbEnableAudio.Checked = true;
            this.chbEnableAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnableAudio.Location = new System.Drawing.Point(34, 17);
            this.chbEnableAudio.Name = "chbEnableAudio";
            this.chbEnableAudio.Size = new System.Drawing.Size(48, 16);
            this.chbEnableAudio.TabIndex = 7;
            this.chbEnableAudio.Text = "启用";
            this.chbEnableAudio.UseVisualStyleBackColor = true;
            this.chbEnableAudio.CheckedChanged += new System.EventHandler(this.chbEnableAudio_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxQQ);
            this.tabPage2.Controls.Add(this.chbEnableQQMsg);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(523, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "QQ通知";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxQQ
            // 
            this.groupBoxQQ.Controls.Add(this.btnGetQQHwnd);
            this.groupBoxQQ.Controls.Add(this.btnTestQQSend);
            this.groupBoxQQ.Controls.Add(this.label1);
            this.groupBoxQQ.Controls.Add(this.rdoBtnCtrlEnter);
            this.groupBoxQQ.Controls.Add(this.label2);
            this.groupBoxQQ.Controls.Add(this.rdoBtnEnter);
            this.groupBoxQQ.Controls.Add(this.cmboxQQWindow);
            this.groupBoxQQ.Location = new System.Drawing.Point(34, 39);
            this.groupBoxQQ.Name = "groupBoxQQ";
            this.groupBoxQQ.Size = new System.Drawing.Size(457, 98);
            this.groupBoxQQ.TabIndex = 8;
            this.groupBoxQQ.TabStop = false;
            this.groupBoxQQ.Text = "设置";
            // 
            // btnGetQQHwnd
            // 
            this.btnGetQQHwnd.Location = new System.Drawing.Point(298, 19);
            this.btnGetQQHwnd.Name = "btnGetQQHwnd";
            this.btnGetQQHwnd.Size = new System.Drawing.Size(142, 25);
            this.btnGetQQHwnd.TabIndex = 2;
            this.btnGetQQHwnd.Text = "获取QQ聊天窗口";
            this.btnGetQQHwnd.UseVisualStyleBackColor = true;
            this.btnGetQQHwnd.Click += new System.EventHandler(this.btnGetQQHwnd_Click);
            // 
            // btnTestQQSend
            // 
            this.btnTestQQSend.Location = new System.Drawing.Point(298, 60);
            this.btnTestQQSend.Name = "btnTestQQSend";
            this.btnTestQQSend.Size = new System.Drawing.Size(142, 25);
            this.btnTestQQSend.TabIndex = 5;
            this.btnTestQQSend.Text = "测试";
            this.btnTestQQSend.UseVisualStyleBackColor = true;
            this.btnTestQQSend.Click += new System.EventHandler(this.btnTestQQSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择QQ聊天窗口:";
            // 
            // rdoBtnCtrlEnter
            // 
            this.rdoBtnCtrlEnter.AutoSize = true;
            this.rdoBtnCtrlEnter.Checked = true;
            this.rdoBtnCtrlEnter.Location = new System.Drawing.Point(188, 65);
            this.rdoBtnCtrlEnter.Name = "rdoBtnCtrlEnter";
            this.rdoBtnCtrlEnter.Size = new System.Drawing.Size(83, 16);
            this.rdoBtnCtrlEnter.TabIndex = 3;
            this.rdoBtnCtrlEnter.TabStop = true;
            this.rdoBtnCtrlEnter.Text = "Ctrl+Enter";
            this.rdoBtnCtrlEnter.UseVisualStyleBackColor = true;
            this.rdoBtnCtrlEnter.CheckedChanged += new System.EventHandler(this.rdoBtnCtrlEnter_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择发送按键:";
            // 
            // rdoBtnEnter
            // 
            this.rdoBtnEnter.AutoSize = true;
            this.rdoBtnEnter.Location = new System.Drawing.Point(123, 65);
            this.rdoBtnEnter.Name = "rdoBtnEnter";
            this.rdoBtnEnter.Size = new System.Drawing.Size(53, 16);
            this.rdoBtnEnter.TabIndex = 3;
            this.rdoBtnEnter.Text = "Enter";
            this.rdoBtnEnter.UseVisualStyleBackColor = true;
            this.rdoBtnEnter.CheckedChanged += new System.EventHandler(this.rdoBtnEnter_CheckedChanged);
            // 
            // cmboxQQWindow
            // 
            this.cmboxQQWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxQQWindow.FormattingEnabled = true;
            this.cmboxQQWindow.Location = new System.Drawing.Point(120, 23);
            this.cmboxQQWindow.Name = "cmboxQQWindow";
            this.cmboxQQWindow.Size = new System.Drawing.Size(151, 20);
            this.cmboxQQWindow.TabIndex = 1;
            this.cmboxQQWindow.SelectedIndexChanged += new System.EventHandler(this.cmboxQQWindow_SelectedIndexChanged);
            // 
            // chbEnableQQMsg
            // 
            this.chbEnableQQMsg.AutoSize = true;
            this.chbEnableQQMsg.Checked = true;
            this.chbEnableQQMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnableQQMsg.Location = new System.Drawing.Point(34, 17);
            this.chbEnableQQMsg.Name = "chbEnableQQMsg";
            this.chbEnableQQMsg.Size = new System.Drawing.Size(48, 16);
            this.chbEnableQQMsg.TabIndex = 6;
            this.chbEnableQQMsg.Text = "启用";
            this.chbEnableQQMsg.UseVisualStyleBackColor = true;
            this.chbEnableQQMsg.CheckedChanged += new System.EventHandler(this.chbEnableQQMsg_CheckedChanged);
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.chkboxlstSearchInterface);
            this.tabPage17.Controls.Add(this.chkBoxOnlyInRecommandTime);
            this.tabPage17.Controls.Add(this.checkBoxAutoVerifyCode);
            this.tabPage17.Controls.Add(this.checkBoxCheckVerifyCodeByOrdering);
            this.tabPage17.Controls.Add(this.btnRecommandDate);
            this.tabPage17.Controls.Add(this.cmbBoxGrabMode);
            this.tabPage17.Controls.Add(this.label27);
            this.tabPage17.Controls.Add(this.label23);
            this.tabPage17.Controls.Add(this.dateTimePickerStartTime);
            this.tabPage17.Controls.Add(this.chkboxEnableTimerStart);
            this.tabPage17.Controls.Add(this.chkboxIsOnlyShowHealthGoldProduct);
            this.tabPage17.Controls.Add(this.chkboxEnableLoopInternal);
            this.tabPage17.Controls.Add(this.numericUpDownLoopInternal);
            this.tabPage17.Controls.Add(this.label6);
            this.tabPage17.Location = new System.Drawing.Point(4, 22);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(523, 170);
            this.tabPage17.TabIndex = 4;
            this.tabPage17.Text = "系统设置";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // chkboxlstSearchInterface
            // 
            this.chkboxlstSearchInterface.CheckOnClick = true;
            this.chkboxlstSearchInterface.FormattingEnabled = true;
            this.chkboxlstSearchInterface.Items.AddRange(new object[] {
            "接口1",
            "全额兑换",
            "半价兑换",
            "超值兑换"});
            this.chkboxlstSearchInterface.Location = new System.Drawing.Point(285, 35);
            this.chkboxlstSearchInterface.Name = "chkboxlstSearchInterface";
            this.chkboxlstSearchInterface.Size = new System.Drawing.Size(215, 84);
            this.chkboxlstSearchInterface.TabIndex = 11;
            this.chkboxlstSearchInterface.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkboxlstSearchInterface_ItemCheck);
            // 
            // chkBoxOnlyInRecommandTime
            // 
            this.chkBoxOnlyInRecommandTime.AutoSize = true;
            this.chkBoxOnlyInRecommandTime.Location = new System.Drawing.Point(16, 143);
            this.chkBoxOnlyInRecommandTime.Name = "chkBoxOnlyInRecommandTime";
            this.chkBoxOnlyInRecommandTime.Size = new System.Drawing.Size(120, 16);
            this.chkBoxOnlyInRecommandTime.TabIndex = 10;
            this.chkBoxOnlyInRecommandTime.Text = "只在推荐时间抢购";
            this.chkBoxOnlyInRecommandTime.UseVisualStyleBackColor = true;
            this.chkBoxOnlyInRecommandTime.Visible = false;
            // 
            // checkBoxAutoVerifyCode
            // 
            this.checkBoxAutoVerifyCode.AutoSize = true;
            this.checkBoxAutoVerifyCode.Checked = true;
            this.checkBoxAutoVerifyCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoVerifyCode.Location = new System.Drawing.Point(141, 15);
            this.checkBoxAutoVerifyCode.Name = "checkBoxAutoVerifyCode";
            this.checkBoxAutoVerifyCode.Size = new System.Drawing.Size(108, 16);
            this.checkBoxAutoVerifyCode.TabIndex = 9;
            this.checkBoxAutoVerifyCode.Text = "自动识别验证码";
            this.checkBoxAutoVerifyCode.UseVisualStyleBackColor = true;
            this.checkBoxAutoVerifyCode.CheckedChanged += new System.EventHandler(this.checkBoxAutoVerifyCode_CheckedChanged);
            // 
            // cmbBoxGrabMode
            // 
            this.cmbBoxGrabMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxGrabMode.FormattingEnabled = true;
            this.cmbBoxGrabMode.Items.AddRange(new object[] {
            "根据商品信息",
            "根据详细商品信息"});
            this.cmbBoxGrabMode.Location = new System.Drawing.Point(350, 129);
            this.cmbBoxGrabMode.Name = "cmbBoxGrabMode";
            this.cmbBoxGrabMode.Size = new System.Drawing.Size(150, 20);
            this.cmbBoxGrabMode.TabIndex = 7;
            this.cmbBoxGrabMode.SelectedIndexChanged += new System.EventHandler(this.cmbBoxGrabMode_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(281, 133);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 6;
            this.label27.Text = "抢购模式：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(281, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 12);
            this.label23.TabIndex = 6;
            this.label23.Text = "商品查询接口模式：";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(89, 108);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(142, 21);
            this.dateTimePickerStartTime.TabIndex = 5;
            this.dateTimePickerStartTime.Value = new System.DateTime(2016, 6, 19, 10, 24, 0, 0);
            // 
            // chkboxEnableTimerStart
            // 
            this.chkboxEnableTimerStart.AutoSize = true;
            this.chkboxEnableTimerStart.Location = new System.Drawing.Point(16, 111);
            this.chkboxEnableTimerStart.Name = "chkboxEnableTimerStart";
            this.chkboxEnableTimerStart.Size = new System.Drawing.Size(72, 16);
            this.chkboxEnableTimerStart.TabIndex = 4;
            this.chkboxEnableTimerStart.Text = "定时抢购";
            this.chkboxEnableTimerStart.UseVisualStyleBackColor = true;
            this.chkboxEnableTimerStart.CheckedChanged += new System.EventHandler(this.chkboxEnableTimerStart_CheckedChanged);
            // 
            // chkboxIsOnlyShowHealthGoldProduct
            // 
            this.chkboxIsOnlyShowHealthGoldProduct.AutoSize = true;
            this.chkboxIsOnlyShowHealthGoldProduct.Location = new System.Drawing.Point(16, 79);
            this.chkboxIsOnlyShowHealthGoldProduct.Name = "chkboxIsOnlyShowHealthGoldProduct";
            this.chkboxIsOnlyShowHealthGoldProduct.Size = new System.Drawing.Size(192, 16);
            this.chkboxIsOnlyShowHealthGoldProduct.TabIndex = 3;
            this.chkboxIsOnlyShowHealthGoldProduct.Text = "只显示可健康金全额兑换的商品";
            this.chkboxIsOnlyShowHealthGoldProduct.UseVisualStyleBackColor = true;
            this.chkboxIsOnlyShowHealthGoldProduct.CheckedChanged += new System.EventHandler(this.chbIsOnlyShowHealthGoldProduct_CheckedChanged);
            // 
            // chkboxEnableLoopInternal
            // 
            this.chkboxEnableLoopInternal.AutoSize = true;
            this.chkboxEnableLoopInternal.Checked = true;
            this.chkboxEnableLoopInternal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxEnableLoopInternal.Location = new System.Drawing.Point(16, 47);
            this.chkboxEnableLoopInternal.Name = "chkboxEnableLoopInternal";
            this.chkboxEnableLoopInternal.Size = new System.Drawing.Size(72, 16);
            this.chkboxEnableLoopInternal.TabIndex = 3;
            this.chkboxEnableLoopInternal.Text = "循环间隔";
            this.chkboxEnableLoopInternal.UseVisualStyleBackColor = true;
            this.chkboxEnableLoopInternal.CheckedChanged += new System.EventHandler(this.chkboxEnableCustomLoopInternal_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "秒";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelTimer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1034, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.ForeColor = System.Drawing.Color.Purple;
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabelUser.Text = "当前用户:[未登录]";
            // 
            // toolStripStatusLabelTimer
            // 
            this.toolStripStatusLabelTimer.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStripStatusLabelTimer.Name = "toolStripStatusLabelTimer";
            this.toolStripStatusLabelTimer.Size = new System.Drawing.Size(916, 17);
            this.toolStripStatusLabelTimer.Spring = true;
            this.toolStripStatusLabelTimer.Text = "当前时间：2016/5/15 11:16:28";
            this.toolStripStatusLabelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 662);
            this.Controls.Add(this.tabControlQueryInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "平安好医生助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoopInternal)).EndInit();
            this.tabControlQueryInfo.ResumeLayout(false);
            this.tabPageMonitor.ResumeLayout(false);
            this.panelFindProduct.ResumeLayout(false);
            this.panelFindProduct.PerformLayout();
            this.tabPageMyInfo.ResumeLayout(false);
            this.tabPageMyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.tabPageGoldInfo.ResumeLayout(false);
            this.tabPageGoldInfo.PerformLayout();
            this.tabPageInvite.ResumeLayout(false);
            this.tabPageLastBonus.ResumeLayout(false);
            this.tabPageLastBonus.PerformLayout();
            this.tabPageFriendRank.ResumeLayout(false);
            this.tabPageFriendRank.PerformLayout();
            this.tabPageGrabGold.ResumeLayout(false);
            this.tabPageGrabGold.PerformLayout();
            this.tabPageBonusRank.ResumeLayout(false);
            this.tabPageBonusRank.PerformLayout();
            this.tabPageOrderInfo.ResumeLayout(false);
            this.tabControlOrders.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPageRewardRecord.ResumeLayout(false);
            this.tabPageInOutRecord.ResumeLayout(false);
            this.tabPageAddress.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlSetting.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxQQ.ResumeLayout(false);
            this.groupBoxQQ.PerformLayout();
            this.tabPage17.ResumeLayout(false);
            this.tabPage17.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonMonitor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogin;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.TabControl tabControlQueryInfo;
        private System.Windows.Forms.TabPage tabPageMonitor;
        private System.Windows.Forms.TabPage tabPageLastBonus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPreMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIsPreDoubleMoney;
        private System.Windows.Forms.TextBox txtPreRewardID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnQueryPreRewardInfo;
        private System.Windows.Forms.Button btnFetchReward;
        private System.Windows.Forms.TextBox txtIsPreMoneyFetch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageMyInfo;
        private System.Windows.Forms.TextBox txtUserNick;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUserGender;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUserMobile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Button btnQueryUserInfo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPageGoldInfo;
        private System.Windows.Forms.TextBox txtStepReward;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtInvitationReward;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCumulativeReward;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBanlance;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnQueryGoldInfo;
        private System.Windows.Forms.TabPage tabPageFriendRank;
        private System.Windows.Forms.ListView lvFriendRanking;
        private System.Windows.Forms.Button btnQueryFriendRanking;
        private System.Windows.Forms.TextBox txtRankingDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabPageOrderInfo;
        private System.Windows.Forms.Button btnQueryOrders;
        private System.Windows.Forms.TabPage tabPageRewardRecord;
        private System.Windows.Forms.Button btnQueryRewardRecord;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.TabControl tabControlOrders;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.TabPage tabPageAddress;
        private System.Windows.Forms.Button btnQueryAddresses;
        private System.Windows.Forms.ListView lvAddresses;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemViewActivityRules;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ListView lvWaitingPayOrders;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ListView lvPaidOrders;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ListView lvFinishOrders;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPageInvite;
        private System.Windows.Forms.ListView lvInvitees;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.Button btnQueryInvitees;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.Button btnCreateInviteQRImage;
        private System.Windows.Forms.ColumnHeader columnHeader47;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private ListViewFz listViewProduct;
        private ListViewFz lvRewardRecord;
        private System.Windows.Forms.ToolStripButton toolStripButtonTest;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPageBonusRank;
        private System.Windows.Forms.TextBox txtBonusRankingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQueryBonusRankingList;
        private System.Windows.Forms.ColumnHeader columnHeader49;
        private System.Windows.Forms.ColumnHeader columnHeader50;
        private System.Windows.Forms.ColumnHeader columnHeader51;
        private System.Windows.Forms.ColumnHeader columnHeader52;
        private ListViewFz lvBonusRankingList;
        private System.Windows.Forms.TabControl tabControlSetting;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.GroupBox groupBoxAudio;
        private System.Windows.Forms.Button btnTestPlay;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbAudioList;
        private System.Windows.Forms.CheckBox chbEnableAudio;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxQQ;
        private System.Windows.Forms.Button btnGetQQHwnd;
        private System.Windows.Forms.Button btnTestQQSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoBtnCtrlEnter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoBtnEnter;
        private System.Windows.Forms.ComboBox cmboxQQWindow;
        private System.Windows.Forms.CheckBox chbEnableQQMsg;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.CheckBox chkboxEnableLoopInternal;
        private System.Windows.Forms.NumericUpDown numericUpDownLoopInternal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPageInOutRecord;
        private ListViewFz lvBatchOrderRecord;
        private System.Windows.Forms.ColumnHeader columnHeader53;
        private System.Windows.Forms.ColumnHeader columnHeader54;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        private System.Windows.Forms.ColumnHeader columnHeader56;
        private System.Windows.Forms.Button btnQueryBatchOrderRecord;
        private ListViewFz lvAllOrders;
        private System.Windows.Forms.CheckBox chkboxIsOnlyShowHealthGoldProduct;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.CheckBox chkboxEnableTimerStart;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ColumnHeader columnHeader57;
        private System.Windows.Forms.TabPage tabPageGrabGold;
        private System.Windows.Forms.TextBox txtGrabGoldRankingDate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnQueryGrabGold;
        private System.Windows.Forms.ListView lvGrabGoldRanking;
        private System.Windows.Forms.ColumnHeader columnHeader59;
        private System.Windows.Forms.ColumnHeader columnHeader60;
        private System.Windows.Forms.ColumnHeader columnHeader61;
        private System.Windows.Forms.ColumnHeader columnHeader62;
        private System.Windows.Forms.TextBox txtTotalGrabGold;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ColumnHeader columnHeader58;
        private System.Windows.Forms.TabPage tabPageGameCenter;
        private System.Windows.Forms.Button btnRecommandDate;
        private System.Windows.Forms.TextBox txtPreSteps;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnViewOrderInfoInWeb;
        private System.Windows.Forms.Panel panelFindProduct;
        private System.Windows.Forms.Button btnFindProduct;
        private System.Windows.Forms.TextBox txtFindProduct;
        private System.Windows.Forms.Button btnCloseFind;
        private System.Windows.Forms.CheckBox chkBoxOnlyInRecommandTime;
        private System.Windows.Forms.ComboBox cmbBoxGrabMode;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckedListBox chkboxlstSearchInterface;
        private System.Windows.Forms.ToolStripButton toolStripButtonStepManager;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnChangeCurrentAddress;
        private System.Windows.Forms.TextBox txtCurrentAddress;
        private System.Windows.Forms.TextBox txtRechargePhone;
        private System.Windows.Forms.Button btnChangeRechargePhone;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListBox listBoxMonitor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxCheckVerifyCodeByOrdering;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.CheckBox checkBoxAutoVerifyCode;
        private System.Windows.Forms.Button buttonDelayGoldExpiredTime;
    }
}

