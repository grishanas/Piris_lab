namespace BankClient
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.lboxClients = new System.Windows.Forms.ListBox();
            this.mstrClients = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageCities = new System.Windows.Forms.TabPage();
            this.tabPageFamilyStatuses = new System.Windows.Forms.TabPage();
            this.tabPageCitizenships = new System.Windows.Forms.TabPage();
            this.tabPageDisabilities = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            this.mstrClients.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageClients);
            this.tabControlMain.Controls.Add(this.tabPageCities);
            this.tabControlMain.Controls.Add(this.tabPageFamilyStatuses);
            this.tabControlMain.Controls.Add(this.tabPageCitizenships);
            this.tabControlMain.Controls.Add(this.tabPageDisabilities);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 450);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.lboxClients);
            this.tabPageClients.Controls.Add(this.mstrClients);
            this.tabPageClients.Location = new System.Drawing.Point(4, 24);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(792, 422);
            this.tabPageClients.TabIndex = 0;
            this.tabPageClients.Text = "Clients";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // lboxClients
            // 
            this.lboxClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxClients.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lboxClients.FormattingEnabled = true;
            this.lboxClients.HorizontalScrollbar = true;
            this.lboxClients.ItemHeight = 30;
            this.lboxClients.Location = new System.Drawing.Point(3, 26);
            this.lboxClients.Name = "lboxClients";
            this.lboxClients.Size = new System.Drawing.Size(786, 393);
            this.lboxClients.TabIndex = 1;
            // 
            // mstrClients
            // 
            this.mstrClients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.addToolStripMenuItem});
            this.mstrClients.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mstrClients.Location = new System.Drawing.Point(3, 3);
            this.mstrClients.Name = "mstrClients";
            this.mstrClients.Size = new System.Drawing.Size(786, 23);
            this.mstrClients.TabIndex = 0;
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 19);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 19);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // tabPageCities
            // 
            this.tabPageCities.Location = new System.Drawing.Point(4, 24);
            this.tabPageCities.Name = "tabPageCities";
            this.tabPageCities.Size = new System.Drawing.Size(792, 422);
            this.tabPageCities.TabIndex = 1;
            this.tabPageCities.Text = "Cities";
            this.tabPageCities.UseVisualStyleBackColor = true;
            // 
            // tabPageFamilyStatuses
            // 
            this.tabPageFamilyStatuses.Location = new System.Drawing.Point(4, 24);
            this.tabPageFamilyStatuses.Name = "tabPageFamilyStatuses";
            this.tabPageFamilyStatuses.Size = new System.Drawing.Size(792, 422);
            this.tabPageFamilyStatuses.TabIndex = 2;
            this.tabPageFamilyStatuses.Text = "Family statuses";
            this.tabPageFamilyStatuses.UseVisualStyleBackColor = true;
            // 
            // tabPageCitizenships
            // 
            this.tabPageCitizenships.Location = new System.Drawing.Point(4, 24);
            this.tabPageCitizenships.Name = "tabPageCitizenships";
            this.tabPageCitizenships.Size = new System.Drawing.Size(792, 422);
            this.tabPageCitizenships.TabIndex = 3;
            this.tabPageCitizenships.Text = "Citizenships";
            this.tabPageCitizenships.UseVisualStyleBackColor = true;
            // 
            // tabPageDisabilities
            // 
            this.tabPageDisabilities.Location = new System.Drawing.Point(4, 24);
            this.tabPageDisabilities.Name = "tabPageDisabilities";
            this.tabPageDisabilities.Size = new System.Drawing.Size(792, 422);
            this.tabPageDisabilities.TabIndex = 4;
            this.tabPageDisabilities.Text = "Disabilities";
            this.tabPageDisabilities.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlMain);
            this.Name = "FormMain";
            this.Text = "Bank client";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageClients.ResumeLayout(false);
            this.tabPageClients.PerformLayout();
            this.mstrClients.ResumeLayout(false);
            this.mstrClients.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.MenuStrip mstrClients;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ListBox lboxClients;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageCities;
        private System.Windows.Forms.TabPage tabPageFamilyStatuses;
        private System.Windows.Forms.TabPage tabPageCitizenships;
        private System.Windows.Forms.TabPage tabPageDisabilities;
    }
}