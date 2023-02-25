namespace BankClient
{
    partial class FormATM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormATM));
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.tabPageCard = new System.Windows.Forms.TabPage();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tboxCardDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxCardNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPagePin = new System.Windows.Forms.TabPage();
            this.btnTakeCard = new System.Windows.Forms.Button();
            this.btnEnterPin = new System.Windows.Forms.Button();
            this.tboxPin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.btnTakeCardMain = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnCheckAccountStatus = new System.Windows.Forms.Button();
            this.tabPageCheck = new System.Windows.Forms.TabPage();
            this.lblCheck = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageAmount = new System.Windows.Forms.TabPage();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.btnCashOut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageWithdrawn = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.tabCtrlMain.SuspendLayout();
            this.tabPageCard.SuspendLayout();
            this.tabPagePin.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageCheck.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageAmount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.tabPageWithdrawn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.tabPageCard);
            this.tabCtrlMain.Controls.Add(this.tabPagePin);
            this.tabCtrlMain.Controls.Add(this.tabPageMain);
            this.tabCtrlMain.Controls.Add(this.tabPageCheck);
            this.tabCtrlMain.Controls.Add(this.tabPageAmount);
            this.tabCtrlMain.Controls.Add(this.tabPageWithdrawn);
            this.tabCtrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlMain.Location = new System.Drawing.Point(220, 60);
            this.tabCtrlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabCtrlMain.Multiline = true;
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(427, 399);
            this.tabCtrlMain.TabIndex = 0;
            // 
            // tabPageCard
            // 
            this.tabPageCard.Controls.Add(this.btnInsert);
            this.tabPageCard.Controls.Add(this.tboxCardDate);
            this.tabPageCard.Controls.Add(this.label3);
            this.tabPageCard.Controls.Add(this.label2);
            this.tabPageCard.Controls.Add(this.tboxCardNumber);
            this.tabPageCard.Controls.Add(this.label1);
            this.tabPageCard.Location = new System.Drawing.Point(4, 24);
            this.tabPageCard.Name = "tabPageCard";
            this.tabPageCard.Size = new System.Drawing.Size(419, 371);
            this.tabPageCard.TabIndex = 0;
            this.tabPageCard.Text = "Card";
            this.tabPageCard.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.AutoSize = true;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInsert.Location = new System.Drawing.Point(12, 125);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(77, 40);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tboxCardDate
            // 
            this.tboxCardDate.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tboxCardDate.Location = new System.Drawing.Point(180, 89);
            this.tboxCardDate.MaxLength = 7;
            this.tboxCardDate.Name = "tboxCardDate";
            this.tboxCardDate.PlaceholderText = "01/2001";
            this.tboxCardDate.Size = new System.Drawing.Size(85, 36);
            this.tboxCardDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Expiration date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Card number:";
            // 
            // tboxCardNumber
            // 
            this.tboxCardNumber.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tboxCardNumber.Location = new System.Drawing.Point(180, 45);
            this.tboxCardNumber.MaxLength = 16;
            this.tboxCardNumber.Name = "tboxCardNumber";
            this.tboxCardNumber.PlaceholderText = "1111111111111111";
            this.tboxCardNumber.Size = new System.Drawing.Size(200, 36);
            this.tboxCardNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please insert the card";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPagePin
            // 
            this.tabPagePin.Controls.Add(this.btnTakeCard);
            this.tabPagePin.Controls.Add(this.btnEnterPin);
            this.tabPagePin.Controls.Add(this.tboxPin);
            this.tabPagePin.Controls.Add(this.label4);
            this.tabPagePin.Location = new System.Drawing.Point(4, 24);
            this.tabPagePin.Name = "tabPagePin";
            this.tabPagePin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePin.Size = new System.Drawing.Size(419, 371);
            this.tabPagePin.TabIndex = 1;
            this.tabPagePin.Text = "PIN";
            this.tabPagePin.UseVisualStyleBackColor = true;
            // 
            // btnTakeCard
            // 
            this.btnTakeCard.AutoSize = true;
            this.btnTakeCard.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTakeCard.Location = new System.Drawing.Point(6, 124);
            this.btnTakeCard.Name = "btnTakeCard";
            this.btnTakeCard.Size = new System.Drawing.Size(153, 40);
            this.btnTakeCard.TabIndex = 3;
            this.btnTakeCard.Text = "Take out card";
            this.btnTakeCard.UseVisualStyleBackColor = true;
            this.btnTakeCard.Click += new System.EventHandler(this.btnTakeCard_Click);
            // 
            // btnEnterPin
            // 
            this.btnEnterPin.AutoSize = true;
            this.btnEnterPin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEnterPin.Location = new System.Drawing.Point(6, 78);
            this.btnEnterPin.Name = "btnEnterPin";
            this.btnEnterPin.Size = new System.Drawing.Size(73, 40);
            this.btnEnterPin.TabIndex = 2;
            this.btnEnterPin.Text = "Enter";
            this.btnEnterPin.UseVisualStyleBackColor = true;
            this.btnEnterPin.Click += new System.EventHandler(this.btnEnterPin_Click);
            // 
            // tboxPin
            // 
            this.tboxPin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tboxPin.Location = new System.Drawing.Point(6, 36);
            this.tboxPin.MaxLength = 4;
            this.tboxPin.Name = "tboxPin";
            this.tboxPin.PlaceholderText = "1111";
            this.tboxPin.Size = new System.Drawing.Size(63, 36);
            this.tboxPin.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Please enter the PIN";
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.btnTakeCardMain);
            this.tabPageMain.Controls.Add(this.btnWithdraw);
            this.tabPageMain.Controls.Add(this.btnCheckAccountStatus);
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Size = new System.Drawing.Size(419, 371);
            this.tabPageMain.TabIndex = 2;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // btnTakeCardMain
            // 
            this.btnTakeCardMain.AutoSize = true;
            this.btnTakeCardMain.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTakeCardMain.Location = new System.Drawing.Point(3, 95);
            this.btnTakeCardMain.Name = "btnTakeCardMain";
            this.btnTakeCardMain.Size = new System.Drawing.Size(153, 40);
            this.btnTakeCardMain.TabIndex = 2;
            this.btnTakeCardMain.Text = "Take card out";
            this.btnTakeCardMain.UseVisualStyleBackColor = true;
            this.btnTakeCardMain.Click += new System.EventHandler(this.btnTakeCard_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.AutoSize = true;
            this.btnWithdraw.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWithdraw.Location = new System.Drawing.Point(3, 49);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(189, 40);
            this.btnWithdraw.TabIndex = 1;
            this.btnWithdraw.Text = "Withdraw money";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnCheckAccountStatus
            // 
            this.btnCheckAccountStatus.AutoSize = true;
            this.btnCheckAccountStatus.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCheckAccountStatus.Location = new System.Drawing.Point(3, 3);
            this.btnCheckAccountStatus.Name = "btnCheckAccountStatus";
            this.btnCheckAccountStatus.Size = new System.Drawing.Size(224, 40);
            this.btnCheckAccountStatus.TabIndex = 0;
            this.btnCheckAccountStatus.Text = "Check account status";
            this.btnCheckAccountStatus.UseVisualStyleBackColor = true;
            this.btnCheckAccountStatus.Click += new System.EventHandler(this.btnCheckAccountStatus_Click);
            // 
            // tabPageCheck
            // 
            this.tabPageCheck.Controls.Add(this.lblCheck);
            this.tabPageCheck.Controls.Add(this.panel1);
            this.tabPageCheck.Location = new System.Drawing.Point(4, 24);
            this.tabPageCheck.Name = "tabPageCheck";
            this.tabPageCheck.Size = new System.Drawing.Size(419, 371);
            this.tabPageCheck.TabIndex = 3;
            this.tabPageCheck.Text = "Check";
            this.tabPageCheck.UseVisualStyleBackColor = true;
            // 
            // lblCheck
            // 
            this.lblCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheck.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCheck.Location = new System.Drawing.Point(0, 46);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(419, 325);
            this.lblCheck.TabIndex = 1;
            this.lblCheck.Text = "label7bbbbbbbbbbbbbbbb";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 46);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabPageAmount
            // 
            this.tabPageAmount.Controls.Add(this.button2);
            this.tabPageAmount.Controls.Add(this.nudAmount);
            this.tabPageAmount.Controls.Add(this.btnCashOut);
            this.tabPageAmount.Controls.Add(this.label6);
            this.tabPageAmount.Location = new System.Drawing.Point(4, 24);
            this.tabPageAmount.Name = "tabPageAmount";
            this.tabPageAmount.Size = new System.Drawing.Size(419, 371);
            this.tabPageAmount.TabIndex = 4;
            this.tabPageAmount.Text = "Amount";
            this.tabPageAmount.UseVisualStyleBackColor = true;
            // 
            // nudAmount
            // 
            this.nudAmount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudAmount.Location = new System.Drawing.Point(213, 3);
            this.nudAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(79, 36);
            this.nudAmount.TabIndex = 2;
            this.nudAmount.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // btnCashOut
            // 
            this.btnCashOut.AutoSize = true;
            this.btnCashOut.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCashOut.Location = new System.Drawing.Point(3, 38);
            this.btnCashOut.Name = "btnCashOut";
            this.btnCashOut.Size = new System.Drawing.Size(116, 40);
            this.btnCashOut.TabIndex = 1;
            this.btnCashOut.Text = "Withdraw";
            this.btnCashOut.UseVisualStyleBackColor = true;
            this.btnCashOut.Click += new System.EventHandler(this.btnCashOut_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(2, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Withdrawal amount:";
            // 
            // tabPageWithdrawn
            // 
            this.tabPageWithdrawn.Controls.Add(this.btnBack);
            this.tabPageWithdrawn.Controls.Add(this.label5);
            this.tabPageWithdrawn.Location = new System.Drawing.Point(4, 24);
            this.tabPageWithdrawn.Name = "tabPageWithdrawn";
            this.tabPageWithdrawn.Size = new System.Drawing.Size(419, 371);
            this.tabPageWithdrawn.TabIndex = 5;
            this.tabPageWithdrawn.Text = "Withdrawn";
            this.tabPageWithdrawn.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(3, 33);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 40);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "Withdrawal successful";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DarkGray;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(867, 60);
            this.panelTop.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.DarkGray;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 459);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(867, 60);
            this.panelBottom.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DarkGray;
            this.panelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeft.BackgroundImage")));
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 60);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(220, 399);
            this.panelLeft.TabIndex = 2;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.DarkGray;
            this.panelRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelRight.BackgroundImage")));
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(647, 60);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(220, 399);
            this.panelRight.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(3, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 519);
            this.Controls.Add(this.tabCtrlMain);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "FormATM";
            this.Text = "ATM";
            this.tabCtrlMain.ResumeLayout(false);
            this.tabPageCard.ResumeLayout(false);
            this.tabPageCard.PerformLayout();
            this.tabPagePin.ResumeLayout(false);
            this.tabPagePin.PerformLayout();
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageCheck.ResumeLayout(false);
            this.tabPageCheck.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageAmount.ResumeLayout(false);
            this.tabPageAmount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.tabPageWithdrawn.ResumeLayout(false);
            this.tabPageWithdrawn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage tabPageCard;
        private System.Windows.Forms.TabPage tabPagePin;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageCheck;
        private System.Windows.Forms.TabPage tabPageAmount;
        private System.Windows.Forms.TabPage tabPageWithdrawn;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxCardNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxCardDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnEnterPin;
        private System.Windows.Forms.TextBox tboxPin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTakeCard;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnCheckAccountStatus;
        private System.Windows.Forms.Button btnTakeCardMain;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCashOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Button button2;
    }
}