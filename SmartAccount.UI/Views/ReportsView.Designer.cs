namespace SmartAccount.UI.Views
{
    partial class ReportsView
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnExportInvoicesPdf = new System.Windows.Forms.Button();
            this.btnExportInvoicesExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Raporlar";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblMessage.Location = new System.Drawing.Point(20, 80);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(360, 21);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "";
            // 
            // btnExportInvoicesPdf
            // 
            this.btnExportInvoicesPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExportInvoicesPdf.FlatAppearance.BorderSize = 0;
            this.btnExportInvoicesPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportInvoicesPdf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportInvoicesPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportInvoicesPdf.Location = new System.Drawing.Point(20, 120);
            this.btnExportInvoicesPdf.Name = "btnExportInvoicesPdf";
            this.btnExportInvoicesPdf.Size = new System.Drawing.Size(200, 40);
            this.btnExportInvoicesPdf.TabIndex = 2;
            this.btnExportInvoicesPdf.Text = "";
            this.btnExportInvoicesPdf.UseVisualStyleBackColor = false;
            this.btnExportInvoicesPdf.Click += new System.EventHandler(this.btnExportInvoicesPdf_Click);
            // 
            // btnExportInvoicesExcel
            // 
            this.btnExportInvoicesExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportInvoicesExcel.FlatAppearance.BorderSize = 0;
            this.btnExportInvoicesExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportInvoicesExcel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportInvoicesExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportInvoicesExcel.Location = new System.Drawing.Point(240, 120);
            this.btnExportInvoicesExcel.Name = "btnExportInvoicesExcel";
            this.btnExportInvoicesExcel.Size = new System.Drawing.Size(200, 40);
            this.btnExportInvoicesExcel.TabIndex = 3;
            this.btnExportInvoicesExcel.Text = "";
            this.btnExportInvoicesExcel.UseVisualStyleBackColor = false;
            this.btnExportInvoicesExcel.Click += new System.EventHandler(this.btnExportInvoicesExcel_Click);
            // 
            // ReportsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.btnExportInvoicesExcel);
            this.Controls.Add(this.btnExportInvoicesPdf);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReportsView";
            this.Size = new System.Drawing.Size(1060, 640);
            this.Load += new System.EventHandler(this.ReportsView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnExportInvoicesPdf;
        private System.Windows.Forms.Button btnExportInvoicesExcel;
    }
}

