namespace SmartAccount.UI.Views
{
    partial class DashboardView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            
            this.pnlIncome = new System.Windows.Forms.Panel();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            
            this.pnlExpense = new System.Windows.Forms.Panel();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.lblTotalExpense = new System.Windows.Forms.Label();
            
            this.pnlBalance = new System.Windows.Forms.Panel();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.lblNetBalance = new System.Windows.Forms.Label();

            this.pnlCustomers = new System.Windows.Forms.Panel();
            this.lblCustomersTitle = new System.Windows.Forms.Label();
            this.lblActiveCustomers = new System.Windows.Forms.Label();

            this.pnlPendingInvoices = new System.Windows.Forms.Panel();
            this.lblPendingInvoicesTitle = new System.Windows.Forms.Label();
            this.lblPendingInvoicesCount = new System.Windows.Forms.Label();
            this.lblPendingInvoicesAmount = new System.Windows.Forms.Label();

            this.pnlPendingWorks = new System.Windows.Forms.Panel();
            this.lblPendingWorksTitle = new System.Windows.Forms.Label();
            this.lblPendingWorks = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            this.pnlIncome.SuspendLayout();
            this.pnlExpense.SuspendLayout();
            this.pnlBalance.SuspendLayout();
            this.pnlCustomers.SuspendLayout();
            this.pnlPendingInvoices.SuspendLayout();
            this.pnlPendingWorks.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1060, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(940, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlIncome (Row 1)
            // 
            this.pnlIncome.BackColor = System.Drawing.Color.White;
            this.pnlIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIncome.Controls.Add(this.lblTotalIncome);
            this.pnlIncome.Controls.Add(this.lblIncomeTitle);
            this.pnlIncome.Location = new System.Drawing.Point(30, 100);
            this.pnlIncome.Name = "pnlIncome";
            this.pnlIncome.Size = new System.Drawing.Size(300, 150);
            this.pnlIncome.TabIndex = 1;
            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.AutoSize = true;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblIncomeTitle.Location = new System.Drawing.Point(20, 20);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Text = "Toplam Gelir";
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalIncome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotalIncome.Location = new System.Drawing.Point(20, 60);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Text = "0,00 ₺";
            // 
            // pnlExpense (Row 1)
            // 
            this.pnlExpense.BackColor = System.Drawing.Color.White;
            this.pnlExpense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpense.Controls.Add(this.lblTotalExpense);
            this.pnlExpense.Controls.Add(this.lblExpenseTitle);
            this.pnlExpense.Location = new System.Drawing.Point(350, 100);
            this.pnlExpense.Name = "pnlExpense";
            this.pnlExpense.Size = new System.Drawing.Size(300, 150);
            this.pnlExpense.TabIndex = 2;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.AutoSize = true;
            this.lblExpenseTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblExpenseTitle.Location = new System.Drawing.Point(20, 20);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Text = "Toplam Gider";
            // 
            // lblTotalExpense
            // 
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalExpense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotalExpense.Location = new System.Drawing.Point(20, 60);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Text = "0,00 ₺";
            // 
            // pnlBalance (Row 1)
            // 
            this.pnlBalance.BackColor = System.Drawing.Color.White;
            this.pnlBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBalance.Controls.Add(this.lblNetBalance);
            this.pnlBalance.Controls.Add(this.lblBalanceTitle);
            this.pnlBalance.Location = new System.Drawing.Point(670, 100);
            this.pnlBalance.Name = "pnlBalance";
            this.pnlBalance.Size = new System.Drawing.Size(300, 150);
            this.pnlBalance.TabIndex = 3;
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.AutoSize = true;
            this.lblBalanceTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBalanceTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblBalanceTitle.Location = new System.Drawing.Point(20, 20);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Text = "Net Bakiye";
            // 
            // lblNetBalance
            // 
            this.lblNetBalance.AutoSize = true;
            this.lblNetBalance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNetBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNetBalance.Location = new System.Drawing.Point(20, 60);
            this.lblNetBalance.Name = "lblNetBalance";
            this.lblNetBalance.Text = "0,00 ₺";
            // 
            // pnlCustomers (Row 2)
            // 
            this.pnlCustomers.BackColor = System.Drawing.Color.White;
            this.pnlCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomers.Controls.Add(this.lblActiveCustomers);
            this.pnlCustomers.Controls.Add(this.lblCustomersTitle);
            this.pnlCustomers.Location = new System.Drawing.Point(30, 270);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Size = new System.Drawing.Size(300, 150);
            this.pnlCustomers.TabIndex = 4;
            // 
            // lblCustomersTitle
            // 
            this.lblCustomersTitle.AutoSize = true;
            this.lblCustomersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomersTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblCustomersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCustomersTitle.Name = "lblCustomersTitle";
            this.lblCustomersTitle.Text = "";
            // 
            // lblActiveCustomers
            // 
            this.lblActiveCustomers.AutoSize = true;
            this.lblActiveCustomers.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblActiveCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblActiveCustomers.Location = new System.Drawing.Point(20, 60);
            this.lblActiveCustomers.Name = "lblActiveCustomers";
            this.lblActiveCustomers.Text = "0";
            // 
            // pnlPendingInvoices (Row 2)
            // 
            this.pnlPendingInvoices.BackColor = System.Drawing.Color.White;
            this.pnlPendingInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendingInvoices.Controls.Add(this.lblPendingInvoicesAmount);
            this.pnlPendingInvoices.Controls.Add(this.lblPendingInvoicesCount);
            this.pnlPendingInvoices.Controls.Add(this.lblPendingInvoicesTitle);
            this.pnlPendingInvoices.Location = new System.Drawing.Point(350, 270);
            this.pnlPendingInvoices.Name = "pnlPendingInvoices";
            this.pnlPendingInvoices.Size = new System.Drawing.Size(300, 150);
            this.pnlPendingInvoices.TabIndex = 5;
            // 
            // lblPendingInvoicesTitle
            // 
            this.lblPendingInvoicesTitle.AutoSize = true;
            this.lblPendingInvoicesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPendingInvoicesTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblPendingInvoicesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPendingInvoicesTitle.Name = "lblPendingInvoicesTitle";
            this.lblPendingInvoicesTitle.Text = "Bekleyen Faturalar";
            // 
            // lblPendingInvoicesCount
            // 
            this.lblPendingInvoicesCount.AutoSize = true;
            this.lblPendingInvoicesCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPendingInvoicesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.lblPendingInvoicesCount.Location = new System.Drawing.Point(20, 50);
            this.lblPendingInvoicesCount.Name = "lblPendingInvoicesCount";
            this.lblPendingInvoicesCount.Text = "0 Adet";
            // 
            // lblPendingInvoicesAmount
            // 
            this.lblPendingInvoicesAmount.AutoSize = true;
            this.lblPendingInvoicesAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPendingInvoicesAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblPendingInvoicesAmount.Location = new System.Drawing.Point(20, 100);
            this.lblPendingInvoicesAmount.Name = "lblPendingInvoicesAmount";
            this.lblPendingInvoicesAmount.Text = "(0,00 ₺)";
            // 
            // pnlPendingWorks (Row 2)
            // 
            this.pnlPendingWorks.BackColor = System.Drawing.Color.White;
            this.pnlPendingWorks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendingWorks.Controls.Add(this.lblPendingWorks);
            this.pnlPendingWorks.Controls.Add(this.lblPendingWorksTitle);
            this.pnlPendingWorks.Location = new System.Drawing.Point(670, 270);
            this.pnlPendingWorks.Name = "pnlPendingWorks";
            this.pnlPendingWorks.Size = new System.Drawing.Size(300, 150);
            this.pnlPendingWorks.TabIndex = 6;
            // 
            // lblPendingWorksTitle
            // 
            this.lblPendingWorksTitle.AutoSize = true;
            this.lblPendingWorksTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPendingWorksTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblPendingWorksTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPendingWorksTitle.Name = "lblPendingWorksTitle";
            this.lblPendingWorksTitle.Text = "";
            // 
            // lblPendingWorks
            // 
            this.lblPendingWorks.AutoSize = true;
            this.lblPendingWorks.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPendingWorks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblPendingWorks.Location = new System.Drawing.Point(20, 60);
            this.lblPendingWorks.Name = "lblPendingWorks";
            this.lblPendingWorks.Text = "0";
            //
            // formsPlot1
            //
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Location = new System.Drawing.Point(30, 440);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(940, 250);
            this.formsPlot1.TabIndex = 7;
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.pnlPendingWorks);
            this.Controls.Add(this.pnlPendingInvoices);
            this.Controls.Add(this.pnlCustomers);
            this.Controls.Add(this.pnlBalance);
            this.Controls.Add(this.pnlExpense);
            this.Controls.Add(this.pnlIncome);
            this.Controls.Add(this.panelTop);
            this.Name = "DashboardView";
            this.Size = new System.Drawing.Size(1060, 640);
            this.Load += new System.EventHandler(this.DashboardView_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.pnlIncome.ResumeLayout(false);
            this.pnlIncome.PerformLayout();
            this.pnlExpense.ResumeLayout(false);
            this.pnlExpense.PerformLayout();
            this.pnlBalance.ResumeLayout(false);
            this.pnlBalance.PerformLayout();
            this.pnlCustomers.ResumeLayout(false);
            this.pnlCustomers.PerformLayout();
            this.pnlPendingInvoices.ResumeLayout(false);
            this.pnlPendingInvoices.PerformLayout();
            this.pnlPendingWorks.ResumeLayout(false);
            this.pnlPendingWorks.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Panel pnlIncome;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblTotalIncome;

        private System.Windows.Forms.Panel pnlExpense;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Label lblTotalExpense;

        private System.Windows.Forms.Panel pnlBalance;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblNetBalance;

        private System.Windows.Forms.Panel pnlCustomers;
        private System.Windows.Forms.Label lblCustomersTitle;
        private System.Windows.Forms.Label lblActiveCustomers;

        private System.Windows.Forms.Panel pnlPendingInvoices;
        private System.Windows.Forms.Label lblPendingInvoicesTitle;
        private System.Windows.Forms.Label lblPendingInvoicesCount;
        private System.Windows.Forms.Label lblPendingInvoicesAmount;

        private System.Windows.Forms.Panel pnlPendingWorks;
        private System.Windows.Forms.Label lblPendingWorksTitle;
        private System.Windows.Forms.Label lblPendingWorks;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}

