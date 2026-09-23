namespace SmartAccount.UI.Views
{
    partial class SettingsView
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            this.dgvSettings = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            
            // dgvSettings
            this.dgvSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSettings.Location = new System.Drawing.Point(0, 50);
            this.dgvSettings.Name = "dgvSettings";
            this.dgvSettings.Size = new System.Drawing.Size(800, 400);
            this.dgvSettings.TabIndex = 0;
            
            // panelTop
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 50);
            this.panelTop.TabIndex = 1;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "";
            
            // btnRefresh
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(700, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // SettingsView
            this.Controls.Add(this.dgvSettings);
            this.Controls.Add(this.panelTop);
            this.Name = "SettingsView";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.SettingsView_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.DataGridView dgvSettings;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
    }
}

