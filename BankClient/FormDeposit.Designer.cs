namespace BankClient
{
    partial class FormDeposit
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxAccountId = new System.Windows.Forms.TextBox();
            this.tbxBankName = new System.Windows.Forms.TextBox();
            this.tbxStartDate = new System.Windows.Forms.TextBox();
            this.tbxEndDate = new System.Windows.Forms.TextBox();
            this.tbxDeadline = new System.Windows.Forms.TextBox();
            this.tbxInterestRate = new System.Windows.Forms.TextBox();
            this.cmbxCurrencyType = new System.Windows.Forms.ComboBox();
            this.cmbxAccountCode = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bank name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "End date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Deadline:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Interest rate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Currency type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Account code:";
            // 
            // tbxAccountId
            // 
            this.tbxAccountId.Location = new System.Drawing.Point(107, 12);
            this.tbxAccountId.MaxLength = 13;
            this.tbxAccountId.Name = "tbxAccountId";
            this.tbxAccountId.Size = new System.Drawing.Size(100, 23);
            this.tbxAccountId.TabIndex = 8;
            // 
            // tbxBankName
            // 
            this.tbxBankName.Location = new System.Drawing.Point(107, 41);
            this.tbxBankName.Name = "tbxBankName";
            this.tbxBankName.Size = new System.Drawing.Size(100, 23);
            this.tbxBankName.TabIndex = 9;
            // 
            // tbxStartDate
            // 
            this.tbxStartDate.Location = new System.Drawing.Point(107, 70);
            this.tbxStartDate.Name = "tbxStartDate";
            this.tbxStartDate.PlaceholderText = "01/01/2001";
            this.tbxStartDate.Size = new System.Drawing.Size(100, 23);
            this.tbxStartDate.TabIndex = 10;
            // 
            // tbxEndDate
            // 
            this.tbxEndDate.Location = new System.Drawing.Point(107, 99);
            this.tbxEndDate.Name = "tbxEndDate";
            this.tbxEndDate.PlaceholderText = "01/01/2001";
            this.tbxEndDate.Size = new System.Drawing.Size(100, 23);
            this.tbxEndDate.TabIndex = 11;
            // 
            // tbxDeadline
            // 
            this.tbxDeadline.Location = new System.Drawing.Point(107, 128);
            this.tbxDeadline.Name = "tbxDeadline";
            this.tbxDeadline.PlaceholderText = "01/01/2001";
            this.tbxDeadline.Size = new System.Drawing.Size(100, 23);
            this.tbxDeadline.TabIndex = 12;
            // 
            // tbxInterestRate
            // 
            this.tbxInterestRate.Location = new System.Drawing.Point(107, 157);
            this.tbxInterestRate.Name = "tbxInterestRate";
            this.tbxInterestRate.PlaceholderText = "0,05";
            this.tbxInterestRate.Size = new System.Drawing.Size(100, 23);
            this.tbxInterestRate.TabIndex = 13;
            // 
            // cmbxCurrencyType
            // 
            this.cmbxCurrencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxCurrencyType.FormattingEnabled = true;
            this.cmbxCurrencyType.Location = new System.Drawing.Point(107, 186);
            this.cmbxCurrencyType.Name = "cmbxCurrencyType";
            this.cmbxCurrencyType.Size = new System.Drawing.Size(100, 23);
            this.cmbxCurrencyType.TabIndex = 14;
            // 
            // cmbxAccountCode
            // 
            this.cmbxAccountCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAccountCode.DropDownWidth = 600;
            this.cmbxAccountCode.FormattingEnabled = true;
            this.cmbxAccountCode.Location = new System.Drawing.Point(107, 215);
            this.cmbxAccountCode.Name = "cmbxAccountCode";
            this.cmbxAccountCode.Size = new System.Drawing.Size(100, 23);
            this.cmbxAccountCode.TabIndex = 15;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 272);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(32, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(50, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Amount:";
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(107, 244);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(100, 23);
            this.tbxAmount.TabIndex = 19;
            // 
            // FormDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 299);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbxAccountCode);
            this.Controls.Add(this.cmbxCurrencyType);
            this.Controls.Add(this.tbxInterestRate);
            this.Controls.Add(this.tbxDeadline);
            this.Controls.Add(this.tbxEndDate);
            this.Controls.Add(this.tbxStartDate);
            this.Controls.Add(this.tbxBankName);
            this.Controls.Add(this.tbxAccountId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDeposit";
            this.Text = "Deposit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxAccountId;
        private System.Windows.Forms.TextBox tbxBankName;
        private System.Windows.Forms.TextBox tbxStartDate;
        private System.Windows.Forms.TextBox tbxEndDate;
        private System.Windows.Forms.TextBox tbxDeadline;
        private System.Windows.Forms.TextBox tbxInterestRate;
        private System.Windows.Forms.ComboBox cmbxCurrencyType;
        private System.Windows.Forms.ComboBox cmbxAccountCode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxAmount;
    }
}