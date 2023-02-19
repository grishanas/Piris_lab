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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.lboxClients = new System.Windows.Forms.ListBox();
            this.mstrClients = new System.Windows.Forms.MenuStrip();
            this.tsmiRefreshClients = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageCities = new System.Windows.Forms.TabPage();
            this.lboxCities = new System.Windows.Forms.ListBox();
            this.mstrCities = new System.Windows.Forms.MenuStrip();
            this.tsmiRefreshCities = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageFamilyStatuses = new System.Windows.Forms.TabPage();
            this.lboxFamilyStatuses = new System.Windows.Forms.ListBox();
            this.mstrFamilyStatuses = new System.Windows.Forms.MenuStrip();
            this.tsmiRefreshFamilyStatuses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteFamilyStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFamilyStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditFamilyStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageCitizenships = new System.Windows.Forms.TabPage();
            this.lboxCitizenships = new System.Windows.Forms.ListBox();
            this.mstrCitizenships = new System.Windows.Forms.MenuStrip();
            this.tsmiRefreshCitizenships = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCitizenship = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddCitizenship = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditCitizenship = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageDisabilities = new System.Windows.Forms.TabPage();
            this.lboxDisabilities = new System.Windows.Forms.ListBox();
            this.mstrDisabilities = new System.Windows.Forms.MenuStrip();
            this.tsmiRefreshDisabilities = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteDisability = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddDisability = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditDisability = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageAccounts = new System.Windows.Forms.TabPage();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.mstrAccounts = new System.Windows.Forms.MenuStrip();
            this.tsmiRefreshAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.btnCloseDay = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            this.mstrClients.SuspendLayout();
            this.tabPageCities.SuspendLayout();
            this.mstrCities.SuspendLayout();
            this.tabPageFamilyStatuses.SuspendLayout();
            this.mstrFamilyStatuses.SuspendLayout();
            this.tabPageCitizenships.SuspendLayout();
            this.mstrCitizenships.SuspendLayout();
            this.tabPageDisabilities.SuspendLayout();
            this.mstrDisabilities.SuspendLayout();
            this.tabPageAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.mstrAccounts.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageClients);
            this.tabControlMain.Controls.Add(this.tabPageCities);
            this.tabControlMain.Controls.Add(this.tabPageFamilyStatuses);
            this.tabControlMain.Controls.Add(this.tabPageCitizenships);
            this.tabControlMain.Controls.Add(this.tabPageDisabilities);
            this.tabControlMain.Controls.Add(this.tabPageAccounts);
            this.tabControlMain.Controls.Add(this.tabPageAdmin);
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
            this.tsmiRefreshClients,
            this.tsmiDeleteClient,
            this.tsmiAddClient,
            this.tsmiEditClient});
            this.mstrClients.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mstrClients.Location = new System.Drawing.Point(3, 3);
            this.mstrClients.Name = "mstrClients";
            this.mstrClients.Size = new System.Drawing.Size(786, 23);
            this.mstrClients.TabIndex = 0;
            // 
            // tsmiRefreshClients
            // 
            this.tsmiRefreshClients.Name = "tsmiRefreshClients";
            this.tsmiRefreshClients.Size = new System.Drawing.Size(58, 19);
            this.tsmiRefreshClients.Text = "Refresh";
            this.tsmiRefreshClients.Click += new System.EventHandler(this.tsmiRefreshClients_Click);
            // 
            // tsmiDeleteClient
            // 
            this.tsmiDeleteClient.Name = "tsmiDeleteClient";
            this.tsmiDeleteClient.Size = new System.Drawing.Size(52, 19);
            this.tsmiDeleteClient.Text = "Delete";
            this.tsmiDeleteClient.Click += new System.EventHandler(this.tsmiDeleteClient_Click);
            // 
            // tsmiAddClient
            // 
            this.tsmiAddClient.Name = "tsmiAddClient";
            this.tsmiAddClient.Size = new System.Drawing.Size(41, 19);
            this.tsmiAddClient.Text = "Add";
            this.tsmiAddClient.Click += new System.EventHandler(this.tsmiAddClient_Click);
            // 
            // tsmiEditClient
            // 
            this.tsmiEditClient.Name = "tsmiEditClient";
            this.tsmiEditClient.Size = new System.Drawing.Size(39, 19);
            this.tsmiEditClient.Text = "Edit";
            this.tsmiEditClient.Click += new System.EventHandler(this.tsmiEditClient_Click);
            // 
            // tabPageCities
            // 
            this.tabPageCities.Controls.Add(this.lboxCities);
            this.tabPageCities.Controls.Add(this.mstrCities);
            this.tabPageCities.Location = new System.Drawing.Point(4, 24);
            this.tabPageCities.Name = "tabPageCities";
            this.tabPageCities.Size = new System.Drawing.Size(792, 422);
            this.tabPageCities.TabIndex = 1;
            this.tabPageCities.Text = "Cities";
            this.tabPageCities.UseVisualStyleBackColor = true;
            // 
            // lboxCities
            // 
            this.lboxCities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxCities.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lboxCities.FormattingEnabled = true;
            this.lboxCities.HorizontalScrollbar = true;
            this.lboxCities.ItemHeight = 30;
            this.lboxCities.Location = new System.Drawing.Point(0, 23);
            this.lboxCities.Name = "lboxCities";
            this.lboxCities.Size = new System.Drawing.Size(792, 399);
            this.lboxCities.TabIndex = 1;
            // 
            // mstrCities
            // 
            this.mstrCities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshCities,
            this.tsmiDeleteCity,
            this.tsmiAddCity,
            this.tsmiEditCity});
            this.mstrCities.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mstrCities.Location = new System.Drawing.Point(0, 0);
            this.mstrCities.Name = "mstrCities";
            this.mstrCities.Size = new System.Drawing.Size(792, 23);
            this.mstrCities.TabIndex = 0;
            // 
            // tsmiRefreshCities
            // 
            this.tsmiRefreshCities.Name = "tsmiRefreshCities";
            this.tsmiRefreshCities.Size = new System.Drawing.Size(58, 19);
            this.tsmiRefreshCities.Text = "Refresh";
            this.tsmiRefreshCities.Click += new System.EventHandler(this.tsmiRefreshCities_Click);
            // 
            // tsmiDeleteCity
            // 
            this.tsmiDeleteCity.Name = "tsmiDeleteCity";
            this.tsmiDeleteCity.Size = new System.Drawing.Size(52, 19);
            this.tsmiDeleteCity.Text = "Delete";
            this.tsmiDeleteCity.Click += new System.EventHandler(this.tsmiDeleteCity_Click);
            // 
            // tsmiAddCity
            // 
            this.tsmiAddCity.Name = "tsmiAddCity";
            this.tsmiAddCity.Size = new System.Drawing.Size(41, 19);
            this.tsmiAddCity.Text = "Add";
            this.tsmiAddCity.Click += new System.EventHandler(this.tsmiAddCity_Click);
            // 
            // tsmiEditCity
            // 
            this.tsmiEditCity.Name = "tsmiEditCity";
            this.tsmiEditCity.Size = new System.Drawing.Size(39, 19);
            this.tsmiEditCity.Text = "Edit";
            this.tsmiEditCity.Click += new System.EventHandler(this.tsmiEditCity_Click);
            // 
            // tabPageFamilyStatuses
            // 
            this.tabPageFamilyStatuses.Controls.Add(this.lboxFamilyStatuses);
            this.tabPageFamilyStatuses.Controls.Add(this.mstrFamilyStatuses);
            this.tabPageFamilyStatuses.Location = new System.Drawing.Point(4, 24);
            this.tabPageFamilyStatuses.Name = "tabPageFamilyStatuses";
            this.tabPageFamilyStatuses.Size = new System.Drawing.Size(792, 422);
            this.tabPageFamilyStatuses.TabIndex = 2;
            this.tabPageFamilyStatuses.Text = "Family statuses";
            this.tabPageFamilyStatuses.UseVisualStyleBackColor = true;
            // 
            // lboxFamilyStatuses
            // 
            this.lboxFamilyStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxFamilyStatuses.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lboxFamilyStatuses.FormattingEnabled = true;
            this.lboxFamilyStatuses.HorizontalScrollbar = true;
            this.lboxFamilyStatuses.ItemHeight = 30;
            this.lboxFamilyStatuses.Location = new System.Drawing.Point(0, 23);
            this.lboxFamilyStatuses.Name = "lboxFamilyStatuses";
            this.lboxFamilyStatuses.Size = new System.Drawing.Size(792, 399);
            this.lboxFamilyStatuses.TabIndex = 1;
            // 
            // mstrFamilyStatuses
            // 
            this.mstrFamilyStatuses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshFamilyStatuses,
            this.tsmiDeleteFamilyStatus,
            this.tsmiAddFamilyStatus,
            this.tsmiEditFamilyStatus});
            this.mstrFamilyStatuses.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mstrFamilyStatuses.Location = new System.Drawing.Point(0, 0);
            this.mstrFamilyStatuses.Name = "mstrFamilyStatuses";
            this.mstrFamilyStatuses.Size = new System.Drawing.Size(792, 23);
            this.mstrFamilyStatuses.TabIndex = 0;
            // 
            // tsmiRefreshFamilyStatuses
            // 
            this.tsmiRefreshFamilyStatuses.Name = "tsmiRefreshFamilyStatuses";
            this.tsmiRefreshFamilyStatuses.Size = new System.Drawing.Size(58, 19);
            this.tsmiRefreshFamilyStatuses.Text = "Refresh";
            this.tsmiRefreshFamilyStatuses.Click += new System.EventHandler(this.tsmiRefreshFamilyStatuses_Click);
            // 
            // tsmiDeleteFamilyStatus
            // 
            this.tsmiDeleteFamilyStatus.Name = "tsmiDeleteFamilyStatus";
            this.tsmiDeleteFamilyStatus.Size = new System.Drawing.Size(52, 19);
            this.tsmiDeleteFamilyStatus.Text = "Delete";
            this.tsmiDeleteFamilyStatus.Click += new System.EventHandler(this.tsmiDeleteFamilyStatus_Click);
            // 
            // tsmiAddFamilyStatus
            // 
            this.tsmiAddFamilyStatus.Name = "tsmiAddFamilyStatus";
            this.tsmiAddFamilyStatus.Size = new System.Drawing.Size(41, 19);
            this.tsmiAddFamilyStatus.Text = "Add";
            this.tsmiAddFamilyStatus.Click += new System.EventHandler(this.tsmiAddFamilyStatus_Click);
            // 
            // tsmiEditFamilyStatus
            // 
            this.tsmiEditFamilyStatus.Name = "tsmiEditFamilyStatus";
            this.tsmiEditFamilyStatus.Size = new System.Drawing.Size(39, 19);
            this.tsmiEditFamilyStatus.Text = "Edit";
            this.tsmiEditFamilyStatus.Click += new System.EventHandler(this.tsmiEditFamilyStatus_Click);
            // 
            // tabPageCitizenships
            // 
            this.tabPageCitizenships.Controls.Add(this.lboxCitizenships);
            this.tabPageCitizenships.Controls.Add(this.mstrCitizenships);
            this.tabPageCitizenships.Location = new System.Drawing.Point(4, 24);
            this.tabPageCitizenships.Name = "tabPageCitizenships";
            this.tabPageCitizenships.Size = new System.Drawing.Size(792, 422);
            this.tabPageCitizenships.TabIndex = 3;
            this.tabPageCitizenships.Text = "Citizenships";
            this.tabPageCitizenships.UseVisualStyleBackColor = true;
            // 
            // lboxCitizenships
            // 
            this.lboxCitizenships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxCitizenships.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lboxCitizenships.FormattingEnabled = true;
            this.lboxCitizenships.HorizontalScrollbar = true;
            this.lboxCitizenships.ItemHeight = 30;
            this.lboxCitizenships.Location = new System.Drawing.Point(0, 23);
            this.lboxCitizenships.Name = "lboxCitizenships";
            this.lboxCitizenships.Size = new System.Drawing.Size(792, 399);
            this.lboxCitizenships.TabIndex = 1;
            // 
            // mstrCitizenships
            // 
            this.mstrCitizenships.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshCitizenships,
            this.tsmiDeleteCitizenship,
            this.tsmiAddCitizenship,
            this.tsmiEditCitizenship});
            this.mstrCitizenships.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mstrCitizenships.Location = new System.Drawing.Point(0, 0);
            this.mstrCitizenships.Name = "mstrCitizenships";
            this.mstrCitizenships.Size = new System.Drawing.Size(792, 23);
            this.mstrCitizenships.TabIndex = 0;
            // 
            // tsmiRefreshCitizenships
            // 
            this.tsmiRefreshCitizenships.Name = "tsmiRefreshCitizenships";
            this.tsmiRefreshCitizenships.Size = new System.Drawing.Size(58, 19);
            this.tsmiRefreshCitizenships.Text = "Refresh";
            this.tsmiRefreshCitizenships.Click += new System.EventHandler(this.tsmiRefreshCitizenships_Click);
            // 
            // tsmiDeleteCitizenship
            // 
            this.tsmiDeleteCitizenship.Name = "tsmiDeleteCitizenship";
            this.tsmiDeleteCitizenship.Size = new System.Drawing.Size(52, 19);
            this.tsmiDeleteCitizenship.Text = "Delete";
            this.tsmiDeleteCitizenship.Click += new System.EventHandler(this.tsmiDeleteCitizenship_Click);
            // 
            // tsmiAddCitizenship
            // 
            this.tsmiAddCitizenship.Name = "tsmiAddCitizenship";
            this.tsmiAddCitizenship.Size = new System.Drawing.Size(41, 19);
            this.tsmiAddCitizenship.Text = "Add";
            this.tsmiAddCitizenship.Click += new System.EventHandler(this.tsmiAddCitizenship_Click);
            // 
            // tsmiEditCitizenship
            // 
            this.tsmiEditCitizenship.Name = "tsmiEditCitizenship";
            this.tsmiEditCitizenship.Size = new System.Drawing.Size(39, 19);
            this.tsmiEditCitizenship.Text = "Edit";
            this.tsmiEditCitizenship.Click += new System.EventHandler(this.tsmiEditCitizenship_Click);
            // 
            // tabPageDisabilities
            // 
            this.tabPageDisabilities.Controls.Add(this.lboxDisabilities);
            this.tabPageDisabilities.Controls.Add(this.mstrDisabilities);
            this.tabPageDisabilities.Location = new System.Drawing.Point(4, 24);
            this.tabPageDisabilities.Name = "tabPageDisabilities";
            this.tabPageDisabilities.Size = new System.Drawing.Size(792, 422);
            this.tabPageDisabilities.TabIndex = 4;
            this.tabPageDisabilities.Text = "Disabilities";
            this.tabPageDisabilities.UseVisualStyleBackColor = true;
            // 
            // lboxDisabilities
            // 
            this.lboxDisabilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxDisabilities.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lboxDisabilities.FormattingEnabled = true;
            this.lboxDisabilities.HorizontalScrollbar = true;
            this.lboxDisabilities.ItemHeight = 30;
            this.lboxDisabilities.Location = new System.Drawing.Point(0, 23);
            this.lboxDisabilities.Name = "lboxDisabilities";
            this.lboxDisabilities.Size = new System.Drawing.Size(792, 399);
            this.lboxDisabilities.TabIndex = 1;
            // 
            // mstrDisabilities
            // 
            this.mstrDisabilities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshDisabilities,
            this.tsmiDeleteDisability,
            this.tsmiAddDisability,
            this.tsmiEditDisability});
            this.mstrDisabilities.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mstrDisabilities.Location = new System.Drawing.Point(0, 0);
            this.mstrDisabilities.Name = "mstrDisabilities";
            this.mstrDisabilities.Size = new System.Drawing.Size(792, 23);
            this.mstrDisabilities.TabIndex = 0;
            // 
            // tsmiRefreshDisabilities
            // 
            this.tsmiRefreshDisabilities.Name = "tsmiRefreshDisabilities";
            this.tsmiRefreshDisabilities.Size = new System.Drawing.Size(58, 19);
            this.tsmiRefreshDisabilities.Text = "Refresh";
            this.tsmiRefreshDisabilities.Click += new System.EventHandler(this.tsmiRefreshDisabilities_Click);
            // 
            // tsmiDeleteDisability
            // 
            this.tsmiDeleteDisability.Name = "tsmiDeleteDisability";
            this.tsmiDeleteDisability.Size = new System.Drawing.Size(52, 19);
            this.tsmiDeleteDisability.Text = "Delete";
            this.tsmiDeleteDisability.Click += new System.EventHandler(this.tsmiDeleteDisability_Click);
            // 
            // tsmiAddDisability
            // 
            this.tsmiAddDisability.Name = "tsmiAddDisability";
            this.tsmiAddDisability.Size = new System.Drawing.Size(41, 19);
            this.tsmiAddDisability.Text = "Add";
            this.tsmiAddDisability.Click += new System.EventHandler(this.tsmiAddDisability_Click);
            // 
            // tsmiEditDisability
            // 
            this.tsmiEditDisability.Name = "tsmiEditDisability";
            this.tsmiEditDisability.Size = new System.Drawing.Size(39, 19);
            this.tsmiEditDisability.Text = "Edit";
            this.tsmiEditDisability.Click += new System.EventHandler(this.tsmiEditDisability_Click);
            // 
            // tabPageAccounts
            // 
            this.tabPageAccounts.Controls.Add(this.dgvAccounts);
            this.tabPageAccounts.Controls.Add(this.mstrAccounts);
            this.tabPageAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccounts.Name = "tabPageAccounts";
            this.tabPageAccounts.Size = new System.Drawing.Size(792, 422);
            this.tabPageAccounts.TabIndex = 6;
            this.tabPageAccounts.Text = "Accounts";
            this.tabPageAccounts.UseVisualStyleBackColor = true;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AllowUserToResizeRows = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.Location = new System.Drawing.Point(0, 24);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAccounts.RowTemplate.Height = 25;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(792, 398);
            this.dgvAccounts.TabIndex = 1;
            // 
            // mstrAccounts
            // 
            this.mstrAccounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshAccounts});
            this.mstrAccounts.Location = new System.Drawing.Point(0, 0);
            this.mstrAccounts.Name = "mstrAccounts";
            this.mstrAccounts.Size = new System.Drawing.Size(792, 24);
            this.mstrAccounts.TabIndex = 0;
            // 
            // tsmiRefreshAccounts
            // 
            this.tsmiRefreshAccounts.Name = "tsmiRefreshAccounts";
            this.tsmiRefreshAccounts.Size = new System.Drawing.Size(58, 20);
            this.tsmiRefreshAccounts.Text = "Refresh";
            this.tsmiRefreshAccounts.Click += new System.EventHandler(this.tsmiRefreshAccounts_Click);
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.Controls.Add(this.btnCloseDay);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Size = new System.Drawing.Size(792, 422);
            this.tabPageAdmin.TabIndex = 5;
            this.tabPageAdmin.Text = "Admin";
            this.tabPageAdmin.UseVisualStyleBackColor = true;
            // 
            // btnCloseDay
            // 
            this.btnCloseDay.Location = new System.Drawing.Point(8, 14);
            this.btnCloseDay.Name = "btnCloseDay";
            this.btnCloseDay.Size = new System.Drawing.Size(75, 23);
            this.btnCloseDay.TabIndex = 0;
            this.btnCloseDay.Text = "Close day";
            this.btnCloseDay.UseVisualStyleBackColor = true;
            this.btnCloseDay.Click += new System.EventHandler(this.btnCloseDay_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlMain);
            this.MainMenuStrip = this.mstrCities;
            this.Name = "FormMain";
            this.Text = "Bank client";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageClients.ResumeLayout(false);
            this.tabPageClients.PerformLayout();
            this.mstrClients.ResumeLayout(false);
            this.mstrClients.PerformLayout();
            this.tabPageCities.ResumeLayout(false);
            this.tabPageCities.PerformLayout();
            this.mstrCities.ResumeLayout(false);
            this.mstrCities.PerformLayout();
            this.tabPageFamilyStatuses.ResumeLayout(false);
            this.tabPageFamilyStatuses.PerformLayout();
            this.mstrFamilyStatuses.ResumeLayout(false);
            this.mstrFamilyStatuses.PerformLayout();
            this.tabPageCitizenships.ResumeLayout(false);
            this.tabPageCitizenships.PerformLayout();
            this.mstrCitizenships.ResumeLayout(false);
            this.mstrCitizenships.PerformLayout();
            this.tabPageDisabilities.ResumeLayout(false);
            this.tabPageDisabilities.PerformLayout();
            this.mstrDisabilities.ResumeLayout(false);
            this.mstrDisabilities.PerformLayout();
            this.tabPageAccounts.ResumeLayout(false);
            this.tabPageAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.mstrAccounts.ResumeLayout(false);
            this.mstrAccounts.PerformLayout();
            this.tabPageAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.MenuStrip mstrClients;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshClients;
        private System.Windows.Forms.ListBox lboxClients;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteClient;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddClient;
        private System.Windows.Forms.TabPage tabPageCities;
        private System.Windows.Forms.TabPage tabPageFamilyStatuses;
        private System.Windows.Forms.TabPage tabPageCitizenships;
        private System.Windows.Forms.TabPage tabPageDisabilities;
        private System.Windows.Forms.MenuStrip mstrCities;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshCities;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCity;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCity;
        private System.Windows.Forms.ListBox lboxCities;
        private System.Windows.Forms.MenuStrip mstrFamilyStatuses;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshFamilyStatuses;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteFamilyStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFamilyStatus;
        private System.Windows.Forms.MenuStrip mstrCitizenships;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshCitizenships;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCitizenship;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCitizenship;
        private System.Windows.Forms.MenuStrip mstrDisabilities;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshDisabilities;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteDisability;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddDisability;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditCity;
        private System.Windows.Forms.ListBox lboxFamilyStatuses;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditFamilyStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditClient;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditCitizenship;
        private System.Windows.Forms.ListBox lboxCitizenships;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditDisability;
        private System.Windows.Forms.ListBox lboxDisabilities;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private System.Windows.Forms.Button btnCloseDay;
        private System.Windows.Forms.TabPage tabPageAccounts;
        private System.Windows.Forms.MenuStrip mstrAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshAccounts;
        private System.Windows.Forms.DataGridView dgvAccounts;
    }
}