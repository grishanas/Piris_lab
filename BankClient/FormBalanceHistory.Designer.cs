namespace BankClient
{
    partial class FormBalanceHistory
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
            this.formsPlotMain = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // formsPlotMain
            // 
            this.formsPlotMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlotMain.Location = new System.Drawing.Point(0, 0);
            this.formsPlotMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlotMain.Name = "formsPlotMain";
            this.formsPlotMain.Size = new System.Drawing.Size(800, 450);
            this.formsPlotMain.TabIndex = 0;
            // 
            // FormBalanceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.formsPlotMain);
            this.Name = "FormBalanceHistory";
            this.Text = "Balance history";
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot formsPlotMain;
    }
}