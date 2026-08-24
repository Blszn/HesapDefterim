namespace SmartAccount.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnWorks = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnPersonnel = new System.Windows.Forms.Button();
            this.btnDailyReport = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.txtGlobalSearch = new System.Windows.Forms.TextBox();
            this.btnGlobalSearch = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlSidebar.Controls.Add(this.btnExit);
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnAccounts);
            this.pnlSidebar.Controls.Add(this.btnProducts);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnInvoices);
            this.pnlSidebar.Controls.Add(this.btnWorks);
            this.pnlSidebar.Controls.Add(this.btnTransactions);
            this.pnlSidebar.Controls.Add(this.btnCustomers);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.btnPersonnel);
            this.pnlSidebar.Controls.Add(this.btnDailyReport);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 720);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExit.Location = new System.Drawing.Point(0, 670);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(220, 50);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 430);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(220, 50);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "Ayarlar";
            this.btnSettings.UseVisualStyleBackColor = true;
            
            // 
            // btnAccounts
            // 
            this.btnAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccounts.FlatAppearance.BorderSize = 0;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccounts.ForeColor = System.Drawing.Color.White;
            this.btnAccounts.Location = new System.Drawing.Point(0, 380);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(220, 50);
            this.btnAccounts.TabIndex = 9;
            this.btnAccounts.Text = "Kasa ve Banka";
            this.btnAccounts.UseVisualStyleBackColor = true;

            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(0, 330);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(220, 50);
            this.btnProducts.TabIndex = 8;
            this.btnProducts.Text = "Stok / Ürünler";
            this.btnProducts.UseVisualStyleBackColor = true;

            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(0, 280);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 50);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Raporlar";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnPersonnel
            // 
            this.btnPersonnel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPersonnel.FlatAppearance.BorderSize = 0;
            this.btnPersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonnel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPersonnel.ForeColor = System.Drawing.Color.White;
            this.btnPersonnel.Location = new System.Drawing.Point(0, 230);
            this.btnPersonnel.Name = "btnPersonnel";
            this.btnPersonnel.Size = new System.Drawing.Size(220, 50);
            this.btnPersonnel.TabIndex = 6;
            this.btnPersonnel.Text = "Personel Yönetimi";
            this.btnPersonnel.UseVisualStyleBackColor = true;
            this.btnPersonnel.Click += new System.EventHandler(this.btnPersonnel_Click);
            // 
            // btnDailyReport
            // 
            this.btnDailyReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDailyReport.FlatAppearance.BorderSize = 0;
            this.btnDailyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDailyReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDailyReport.ForeColor = System.Drawing.Color.White;
            this.btnDailyReport.Location = new System.Drawing.Point(0, 180);
            this.btnDailyReport.Name = "btnDailyReport";
            this.btnDailyReport.Size = new System.Drawing.Size(220, 50);
            this.btnDailyReport.TabIndex = 7;
            this.btnDailyReport.Text = "Gün Sonu Raporu";
            this.btnDailyReport.UseVisualStyleBackColor = true;
            this.btnDailyReport.Click += new System.EventHandler(this.btnDailyReport_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInvoices.FlatAppearance.BorderSize = 0;
            this.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoices.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInvoices.ForeColor = System.Drawing.Color.White;
            this.btnInvoices.Location = new System.Drawing.Point(0, 230);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(220, 50);
            this.btnInvoices.TabIndex = 4;
            this.btnInvoices.Text = "Faturalar";
            this.btnInvoices.UseVisualStyleBackColor = true;
            // 
            // btnWorks
            // 
            this.btnWorks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWorks.FlatAppearance.BorderSize = 0;
            this.btnWorks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorks.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWorks.ForeColor = System.Drawing.Color.White;
            this.btnWorks.Location = new System.Drawing.Point(0, 180);
            this.btnWorks.Name = "btnWorks";
            this.btnWorks.Size = new System.Drawing.Size(220, 50);
            this.btnWorks.TabIndex = 7;
            this.btnWorks.Text = "İş Takibi";
            this.btnWorks.UseVisualStyleBackColor = true;
            // 
            // btnTransactions
            // 
            this.btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTransactions.ForeColor = System.Drawing.Color.White;
            this.btnTransactions.Location = new System.Drawing.Point(0, 180);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(220, 50);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "Gelir / Gider";
            this.btnTransactions.UseVisualStyleBackColor = true;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Location = new System.Drawing.Point(0, 130);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(220, 50);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Müşteriler";
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(220, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Ana Panel (Dashboard)";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.pnlLogo.Controls.Add(this.pictureBoxLogo);
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(220, 80);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(60, 25);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(155, 30);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "HesapDefterim";
            //
            // pictureBoxLogo
            //
            this.pictureBoxLogo.Location = new System.Drawing.Point(10, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.txtGlobalSearch);
            this.pnlHeader.Controls.Add(this.btnGlobalSearch);
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1060, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // txtGlobalSearch
            // 
            this.txtGlobalSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGlobalSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGlobalSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGlobalSearch.Location = new System.Drawing.Point(400, 26);
            this.txtGlobalSearch.Name = "txtGlobalSearch";
            this.txtGlobalSearch.PlaceholderText = " Sistem genelinde ara...";
            this.txtGlobalSearch.Size = new System.Drawing.Size(300, 27);
            this.txtGlobalSearch.TabIndex = 2;
            this.txtGlobalSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGlobalSearch_KeyDown);
            // 
            // btnGlobalSearch
            // 
            this.btnGlobalSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGlobalSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnGlobalSearch.FlatAppearance.BorderSize = 0;
            this.btnGlobalSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlobalSearch.ForeColor = System.Drawing.Color.White;
            this.btnGlobalSearch.Location = new System.Drawing.Point(705, 26);
            this.btnGlobalSearch.Name = "btnGlobalSearch";
            this.btnGlobalSearch.Size = new System.Drawing.Size(60, 27);
            this.btnGlobalSearch.TabIndex = 3;
            this.btnGlobalSearch.Text = "Bul";
            this.btnGlobalSearch.UseVisualStyleBackColor = false;
            this.btnGlobalSearch.Click += new System.EventHandler(this.btnGlobalSearch_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblUserInfo.Location = new System.Drawing.Point(850, 30);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(176, 20);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Hoşgeldin, admin (Admin)";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblPageTitle.Location = new System.Drawing.Point(20, 23);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(135, 32);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Ana Panel";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1060, 640);
            this.pnlContent.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HesapDefterim - İşletme Yönetim Sistemi (ERP)";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnPersonnel;
        private System.Windows.Forms.Button btnDailyReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnWorks;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.TextBox txtGlobalSearch;
        private System.Windows.Forms.Button btnGlobalSearch;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}
