using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmartAccount.UI.Views
{
    partial class DailyReportForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblTotalIncomeTitle = new System.Windows.Forms.Label();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpenseTitle = new System.Windows.Forms.Label();
            this.lblTotalExpense = new System.Windows.Forms.Label();
            this.lblNetBalanceTitle = new System.Windows.Forms.Label();
            this.lblNetBalance = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnLoad);
            this.panelTop.Controls.Add(this.dtpDate);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 30);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(380, 19);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 6;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(600, 15);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Getir";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panelSummary
            // 
            this.panelSummary.Controls.Add(this.lblNetBalance);
            this.panelSummary.Controls.Add(this.lblNetBalanceTitle);
            this.panelSummary.Controls.Add(this.lblTotalExpense);
            this.panelSummary.Controls.Add(this.lblTotalExpenseTitle);
            this.panelSummary.Controls.Add(this.lblTotalIncome);
            this.panelSummary.Controls.Add(this.lblTotalIncomeTitle);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(0, 60);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(800, 80);
            this.panelSummary.TabIndex = 1;
            // 
            // lblTotalIncomeTitle
            // 
            this.lblTotalIncomeTitle.AutoSize = true;
            this.lblTotalIncomeTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalIncomeTitle.Location = new System.Drawing.Point(50, 15);
            this.lblTotalIncomeTitle.Name = "lblTotalIncomeTitle";
            this.lblTotalIncomeTitle.Size = new System.Drawing.Size(96, 21);
            this.lblTotalIncomeTitle.TabIndex = 0;
            this.lblTotalIncomeTitle.Text = "Toplam Gelir";
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalIncome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotalIncome.Location = new System.Drawing.Point(50, 45);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(65, 25);
            this.lblTotalIncome.TabIndex = 1;
            this.lblTotalIncome.Text = "₺0.00";
            // 
            // lblTotalExpenseTitle
            // 
            this.lblTotalExpenseTitle.AutoSize = true;
            this.lblTotalExpenseTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalExpenseTitle.Location = new System.Drawing.Point(250, 15);
            this.lblTotalExpenseTitle.Name = "lblTotalExpenseTitle";
            this.lblTotalExpenseTitle.Size = new System.Drawing.Size(100, 21);
            this.lblTotalExpenseTitle.TabIndex = 2;
            this.lblTotalExpenseTitle.Text = "Toplam Gider";
            // 
            // lblTotalExpense
            // 
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalExpense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotalExpense.Location = new System.Drawing.Point(250, 45);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Size = new System.Drawing.Size(65, 25);
            this.lblTotalExpense.TabIndex = 3;
            this.lblTotalExpense.Text = "₺0.00";
            // 
            // lblNetBalanceTitle
            // 
            this.lblNetBalanceTitle.AutoSize = true;
            this.lblNetBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNetBalanceTitle.Location = new System.Drawing.Point(450, 15);
            this.lblNetBalanceTitle.Name = "lblNetBalanceTitle";
            this.lblNetBalanceTitle.Size = new System.Drawing.Size(84, 21);
            this.lblNetBalanceTitle.TabIndex = 4;
            this.lblNetBalanceTitle.Text = "Net Bakiye";
            // 
            // lblNetBalance
            // 
            this.lblNetBalance.AutoSize = true;
            this.lblNetBalance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNetBalance.Location = new System.Drawing.Point(450, 40);
            this.lblNetBalance.Name = "lblNetBalance";
            this.lblNetBalance.Size = new System.Drawing.Size(71, 30);
            this.lblNetBalance.TabIndex = 5;
            this.lblNetBalance.Text = "₺0.00";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Location = new System.Drawing.Point(0, 140);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(800, 310);
            this.dgvTransactions.TabIndex = 2;
            // 
            // DailyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelTop);
            this.Name = "DailyReportForm";
            this.Text = "";
            this.Load += new System.EventHandler(this.DailyReportForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotalIncomeTitle;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpenseTitle;
        private System.Windows.Forms.Label lblTotalExpense;
        private System.Windows.Forms.Label lblNetBalanceTitle;
        private System.Windows.Forms.Label lblNetBalance;
        private System.Windows.Forms.DataGridView dgvTransactions;
    }
}

