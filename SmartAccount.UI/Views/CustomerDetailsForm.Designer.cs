namespace SmartAccount.UI.Views
{
    partial class CustomerDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            if (_context != null) _context.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExtre = new System.Windows.Forms.TabPage();
            this.dgvExtre = new System.Windows.Forms.DataGridView();
            this.lblBakiye = new System.Windows.Forms.Label();
            this.tabBelgeler = new System.Windows.Forms.TabPage();
            this.dgvAttachments = new System.Windows.Forms.DataGridView();
            this.panelBelgelerTop = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();

            this.tabControl1.SuspendLayout();
            this.tabExtre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtre)).BeginInit();
            this.tabBelgeler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).BeginInit();
            this.panelBelgelerTop.SuspendLayout();
            this.SuspendLayout();

            // lblCustomerName
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.Location = new System.Drawing.Point(12, 9);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(169, 30);
            this.lblCustomerName.Text = "Customer Name";

            // tabControl1
            this.tabControl1.Controls.Add(this.tabExtre);
            this.tabControl1.Controls.Add(this.tabBelgeler);
            this.tabControl1.Location = new System.Drawing.Point(12, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 400);

            // tabExtre
            this.tabExtre.Controls.Add(this.dgvExtre);
            this.tabExtre.Controls.Add(this.lblBakiye);
            this.tabExtre.Name = "tabExtre";
            this.tabExtre.Text = "Cari Ekstre (İşlem Geçmişi)";
            this.tabExtre.UseVisualStyleBackColor = true;

            // dgvExtre
            this.dgvExtre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExtre.Location = new System.Drawing.Point(0, 30);
            this.dgvExtre.Name = "dgvExtre";
            this.dgvExtre.Size = new System.Drawing.Size(752, 344);

            // lblBakiye
            this.lblBakiye.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBakiye.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBakiye.Location = new System.Drawing.Point(0, 0);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(752, 30);
            this.lblBakiye.Text = "Güncel Bakiye: 0,00 ₺";
            this.lblBakiye.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // tabBelgeler
            this.tabBelgeler.Controls.Add(this.dgvAttachments);
            this.tabBelgeler.Controls.Add(this.panelBelgelerTop);
            this.tabBelgeler.Name = "tabBelgeler";
            this.tabBelgeler.Text = "Dosya Ekleri";
            this.tabBelgeler.UseVisualStyleBackColor = true;

            // dgvAttachments
            this.dgvAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachments.Location = new System.Drawing.Point(0, 40);
            this.dgvAttachments.Name = "dgvAttachments";
            this.dgvAttachments.Size = new System.Drawing.Size(752, 334);

            // panelBelgelerTop
            this.panelBelgelerTop.Controls.Add(this.btnUpload);
            this.panelBelgelerTop.Controls.Add(this.btnDownload);
            this.panelBelgelerTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBelgelerTop.Location = new System.Drawing.Point(0, 0);
            this.panelBelgelerTop.Name = "panelBelgelerTop";
            this.panelBelgelerTop.Size = new System.Drawing.Size(752, 40);

            // btnUpload
            this.btnUpload.Location = new System.Drawing.Point(10, 8);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 25);
            this.btnUpload.Text = "Yeni Belge Yükle";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // btnDownload
            this.btnDownload.Location = new System.Drawing.Point(120, 8);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(100, 25);
            this.btnDownload.Text = "Belgeyi Aç";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);

            // CustomerDetailsForm
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblCustomerName);
            this.Name = "CustomerDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cari Detayları";
            this.Load += new System.EventHandler(this.CustomerDetailsForm_Load);

            this.tabControl1.ResumeLayout(false);
            this.tabExtre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtre)).EndInit();
            this.tabBelgeler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).EndInit();
            this.panelBelgelerTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExtre;
        private System.Windows.Forms.TabPage tabBelgeler;
        private System.Windows.Forms.DataGridView dgvExtre;
        private System.Windows.Forms.Label lblBakiye;
        private System.Windows.Forms.DataGridView dgvAttachments;
        private System.Windows.Forms.Panel panelBelgelerTop;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblCustomerName;
    }
}
