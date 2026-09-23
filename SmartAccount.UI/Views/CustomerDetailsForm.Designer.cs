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
            this.panelExtreTop = new System.Windows.Forms.Panel();
            this.btnAlacaklandir = new System.Windows.Forms.Button();
            this.btnBorclandir = new System.Windows.Forms.Button();
            this.btnTahsilat = new System.Windows.Forms.Button();
            this.btnTediye = new System.Windows.Forms.Button();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.lblBakiye = new System.Windows.Forms.Label();

            this.tabBelgeler = new System.Windows.Forms.TabPage();
            this.dgvAttachments = new System.Windows.Forms.DataGridView();
            this.panelBelgelerTop = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDeleteAttachment = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();

            this.tabControl1.SuspendLayout();
            this.tabExtre.SuspendLayout();
            this.panelExtreTop.SuspendLayout();
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
            this.tabExtre.Controls.Add(this.panelExtreTop);
            this.tabExtre.Name = "tabExtre";
            this.tabExtre.Text = "";
            this.tabExtre.UseVisualStyleBackColor = true;

            // dgvExtre
            this.dgvExtre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExtre.Location = new System.Drawing.Point(0, 40);
            this.dgvExtre.Name = "dgvExtre";
            this.dgvExtre.Size = new System.Drawing.Size(752, 334);

            // panelExtreTop
            this.panelExtreTop.Controls.Add(this.btnAlacaklandir);
            this.panelExtreTop.Controls.Add(this.btnBorclandir);
            this.panelExtreTop.Controls.Add(this.btnTahsilat);
            this.panelExtreTop.Controls.Add(this.btnTediye);
            this.panelExtreTop.Controls.Add(this.btnExportPdf);
            this.panelExtreTop.Controls.Add(this.lblBakiye);
            this.panelExtreTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExtreTop.Location = new System.Drawing.Point(0, 0);
            this.panelExtreTop.Name = "panelExtreTop";
            this.panelExtreTop.Size = new System.Drawing.Size(752, 40);

            // btnAlacaklandir
            this.btnAlacaklandir.Location = new System.Drawing.Point(10, 8);
            this.btnAlacaklandir.Name = "btnAlacaklandir";
            this.btnAlacaklandir.Size = new System.Drawing.Size(90, 25);
            this.btnAlacaklandir.Text = "Alacak Ekle";
            this.btnAlacaklandir.Click += new System.EventHandler(this.btnAlacaklandir_Click);

            // btnBorclandir
            this.btnBorclandir.Location = new System.Drawing.Point(110, 8);
            this.btnBorclandir.Name = "btnBorclandir";
            this.btnBorclandir.Size = new System.Drawing.Size(90, 25);
            this.btnBorclandir.Text = "";
            this.btnBorclandir.Click += new System.EventHandler(this.btnBorclandir_Click);

            // btnTahsilat
            this.btnTahsilat.Location = new System.Drawing.Point(210, 8);
            this.btnTahsilat.Name = "btnTahsilat";
            this.btnTahsilat.Size = new System.Drawing.Size(90, 25);
            this.btnTahsilat.Text = "Tahsilat Al";
            this.btnTahsilat.Click += new System.EventHandler(this.btnTahsilat_Click);

            // btnTediye
            this.btnTediye.Location = new System.Drawing.Point(310, 8);
            this.btnTediye.Name = "btnTediye";
            this.btnTediye.Size = new System.Drawing.Size(90, 25);
            this.btnTediye.Text = "";
            this.btnTediye.Click += new System.EventHandler(this.btnTediye_Click);

            // lblBakiye
            this.lblBakiye.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBakiye.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBakiye.Location = new System.Drawing.Point(452, 0);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(300, 40);
            this.lblBakiye.Text = "";
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

            // btnExportPdf
            this.btnExportPdf.Location = new System.Drawing.Point(410, 8);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(100, 25);
            this.btnExportPdf.Text = "PDF'e Aktar";
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // panelBelgelerTop
            this.panelBelgelerTop.Controls.Add(this.btnUpload);
            this.panelBelgelerTop.Controls.Add(this.btnDownload);
            this.panelBelgelerTop.Controls.Add(this.btnDeleteAttachment);
            this.panelBelgelerTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBelgelerTop.Location = new System.Drawing.Point(0, 0);
            this.panelBelgelerTop.Name = "panelBelgelerTop";
            this.panelBelgelerTop.Size = new System.Drawing.Size(752, 40);

            // btnUpload
            this.btnUpload.Location = new System.Drawing.Point(10, 8);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 25);
            this.btnUpload.Text = "";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // btnDownload
            this.btnDownload.Location = new System.Drawing.Point(120, 8);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(100, 25);
            this.btnDownload.Text = "";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);

            // btnDeleteAttachment
            this.btnDeleteAttachment.Location = new System.Drawing.Point(230, 8);
            this.btnDeleteAttachment.Name = "btnDeleteAttachment";
            this.btnDeleteAttachment.Size = new System.Drawing.Size(100, 25);
            this.btnDeleteAttachment.Text = "Belgeyi Sil";
            this.btnDeleteAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);

            // CustomerDetailsForm
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblCustomerName);
            this.Name = "CustomerDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.Load += new System.EventHandler(this.CustomerDetailsForm_Load);

            this.tabControl1.ResumeLayout(false);
            this.tabExtre.ResumeLayout(false);
            this.panelExtreTop.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelExtreTop;
        private System.Windows.Forms.Button btnAlacaklandir;
        private System.Windows.Forms.Button btnBorclandir;
        private System.Windows.Forms.Button btnTahsilat;
        private System.Windows.Forms.Button btnTediye;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.DataGridView dgvAttachments;
        private System.Windows.Forms.Panel panelBelgelerTop;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDeleteAttachment;
        private System.Windows.Forms.Label lblCustomerName;
    }
}


