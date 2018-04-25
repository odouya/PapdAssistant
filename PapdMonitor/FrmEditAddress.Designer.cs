namespace PapdMonitor
{
    partial class FrmEditAddress
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecipientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecipientPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHouseNum = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.chbIsDefault = new System.Windows.Forms.CheckBox();
            this.btnSelectCity = new System.Windows.Forms.Button();
            this.btnSelectStreet = new System.Windows.Forms.Button();
            this.btnSelectProvince = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "收货人：";
            // 
            // txtRecipientName
            // 
            this.txtRecipientName.Location = new System.Drawing.Point(120, 17);
            this.txtRecipientName.Name = "txtRecipientName";
            this.txtRecipientName.Size = new System.Drawing.Size(171, 21);
            this.txtRecipientName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "手机号：";
            // 
            // txtRecipientPhone
            // 
            this.txtRecipientPhone.Location = new System.Drawing.Point(120, 47);
            this.txtRecipientPhone.Name = "txtRecipientPhone";
            this.txtRecipientPhone.Size = new System.Drawing.Size(171, 21);
            this.txtRecipientPhone.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "所在城市：";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(120, 107);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(171, 21);
            this.txtCity.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "收货地址：";
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.Location = new System.Drawing.Point(120, 137);
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.ReadOnly = true;
            this.txtStreetAddress.Size = new System.Drawing.Size(171, 21);
            this.txtStreetAddress.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "门牌号：";
            // 
            // txtHouseNum
            // 
            this.txtHouseNum.Location = new System.Drawing.Point(120, 167);
            this.txtHouseNum.Name = "txtHouseNum";
            this.txtHouseNum.Size = new System.Drawing.Size(171, 21);
            this.txtHouseNum.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(110, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 38);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "所在省：";
            // 
            // txtProvince
            // 
            this.txtProvince.Location = new System.Drawing.Point(120, 77);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.ReadOnly = true;
            this.txtProvince.Size = new System.Drawing.Size(171, 21);
            this.txtProvince.TabIndex = 2;
            // 
            // chbIsDefault
            // 
            this.chbIsDefault.AutoSize = true;
            this.chbIsDefault.Location = new System.Drawing.Point(120, 205);
            this.chbIsDefault.Name = "chbIsDefault";
            this.chbIsDefault.Size = new System.Drawing.Size(108, 16);
            this.chbIsDefault.TabIndex = 9;
            this.chbIsDefault.Text = "是否为默认地址";
            this.chbIsDefault.UseVisualStyleBackColor = true;
            // 
            // btnSelectCity
            // 
            this.btnSelectCity.Location = new System.Drawing.Point(297, 108);
            this.btnSelectCity.Name = "btnSelectCity";
            this.btnSelectCity.Size = new System.Drawing.Size(31, 23);
            this.btnSelectCity.TabIndex = 5;
            this.btnSelectCity.Text = "选";
            this.btnSelectCity.UseVisualStyleBackColor = true;
            this.btnSelectCity.Click += new System.EventHandler(this.btnSelectCity_Click);
            // 
            // btnSelectStreet
            // 
            this.btnSelectStreet.Location = new System.Drawing.Point(297, 137);
            this.btnSelectStreet.Name = "btnSelectStreet";
            this.btnSelectStreet.Size = new System.Drawing.Size(31, 23);
            this.btnSelectStreet.TabIndex = 7;
            this.btnSelectStreet.Text = "选";
            this.btnSelectStreet.UseVisualStyleBackColor = true;
            this.btnSelectStreet.Click += new System.EventHandler(this.btnSelectStreet_Click);
            // 
            // btnSelectProvince
            // 
            this.btnSelectProvince.Location = new System.Drawing.Point(297, 77);
            this.btnSelectProvince.Name = "btnSelectProvince";
            this.btnSelectProvince.Size = new System.Drawing.Size(31, 23);
            this.btnSelectProvince.TabIndex = 3;
            this.btnSelectProvince.Text = "选";
            this.btnSelectProvince.UseVisualStyleBackColor = true;
            this.btnSelectProvince.Click += new System.EventHandler(this.btnSelectProvince_Click);
            // 
            // FrmEditAddress
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 281);
            this.Controls.Add(this.btnSelectStreet);
            this.Controls.Add(this.btnSelectProvince);
            this.Controls.Add(this.btnSelectCity);
            this.Controls.Add(this.chbIsDefault);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHouseNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStreetAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProvince);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRecipientPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRecipientName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditAddress";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建地址";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecipientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecipientPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHouseNum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.CheckBox chbIsDefault;
        private System.Windows.Forms.Button btnSelectCity;
        private System.Windows.Forms.Button btnSelectStreet;
        private System.Windows.Forms.Button btnSelectProvince;
    }
}