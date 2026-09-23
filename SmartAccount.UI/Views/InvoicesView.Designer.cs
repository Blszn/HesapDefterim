namespace SmartAccount.UI.Views
{
    partial class InvoicesView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnDownloadEInvoice = new System.Windows.Forms.Button();
            this.tabOffers = new System.Windows.Forms.TabPage();
            this.dgvOffers = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteOffer = new System.Windows.Forms.Button();
            this.btnAddOffer = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabOffers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInvoices);
            this.tabControl.Controls.Add(this.tabOffers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1060, 640);
            this.tabControl.TabIndex = 0;
            // 
            // tabInvoices
            // 
            this.tabInvoices.Controls.Add(this.dgvInvoices);
            this.tabInvoices.Controls.Add(this.panel1);
            this.tabInvoices.Location = new System.Drawing.Point(4, 29);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.tabInvoices.Size = new System.Drawing.Size(1052, 607);
            this.tabInvoices.TabIndex = 0;
            this.tabInvoices.Text = "Faturalar";
            this.tabInvoices.UseVisualStyleBackColor = true;
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInvoices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoices.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoices.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoices.EnableHeadersVisualStyles = false;
            this.dgvInvoices.Location = new System.Drawing.Point(3, 73);
            this.dgvInvoices.MultiSelect = false;
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.RowTemplate.Height = 45;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(1046, 531);
            this.dgvInvoices.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnDownloadEInvoice);
            this.panel1.Controls.Add(this.btnDeleteInvoice);
            this.panel1.Controls.Add(this.btnAddInvoice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 70);
            this.panel1.TabIndex = 0;
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteInvoice.FlatAppearance.BorderSize = 0;
            this.btnDeleteInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteInvoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteInvoice.ForeColor = System.Drawing.Color.White;
            this.btnDeleteInvoice.Location = new System.Drawing.Point(936, 17);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteInvoice.TabIndex = 9;
            this.btnDeleteInvoice.Text = "Sil";
            this.btnDeleteInvoice.UseVisualStyleBackColor = false;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddInvoice.FlatAppearance.BorderSize = 0;
            this.btnAddInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInvoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddInvoice.ForeColor = System.Drawing.Color.White;
            this.btnAddInvoice.Location = new System.Drawing.Point(796, 17);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(120, 35);
            this.btnAddInvoice.TabIndex = 8;
            this.btnAddInvoice.Text = "Yeni Fatura";
            this.btnAddInvoice.UseVisualStyleBackColor = false;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // btnDownloadEInvoice
            // 
            this.btnDownloadEInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadEInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnDownloadEInvoice.FlatAppearance.BorderSize = 0;
            this.btnDownloadEInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadEInvoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDownloadEInvoice.ForeColor = System.Drawing.Color.White;
            this.btnDownloadEInvoice.Location = new System.Drawing.Point(620, 17);
            this.btnDownloadEInvoice.Name = "btnDownloadEInvoice";
            this.btnDownloadEInvoice.Size = new System.Drawing.Size(150, 35);
            this.btnDownloadEInvoice.TabIndex = 8;
            this.btnDownloadEInvoice.Text = "";
            this.btnDownloadEInvoice.UseVisualStyleBackColor = false;
            this.btnDownloadEInvoice.Click += new System.EventHandler(this.btnDownloadEInvoice_Click);
            // 
            // tabOffers
            // 
            this.tabOffers.Controls.Add(this.dgvOffers);
            this.tabOffers.Controls.Add(this.panel2);
            this.tabOffers.Location = new System.Drawing.Point(4, 29);
            this.tabOffers.Name = "tabOffers";
            this.tabOffers.Padding = new System.Windows.Forms.Padding(3);
            this.tabOffers.Size = new System.Drawing.Size(1052, 607);
            this.tabOffers.TabIndex = 1;
            this.tabOffers.Text = "Teklifler";
            this.tabOffers.UseVisualStyleBackColor = true;
            // 
            // dgvOffers
            // 
            this.dgvOffers.AllowUserToAddRows = false;
            this.dgvOffers.AllowUserToDeleteRows = false;
            this.dgvOffers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOffers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOffers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvOffers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOffers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOffers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOffers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOffers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOffers.EnableHeadersVisualStyles = false;
            this.dgvOffers.Location = new System.Drawing.Point(3, 73);
            this.dgvOffers.MultiSelect = false;
            this.dgvOffers.Name = "dgvOffers";
            this.dgvOffers.ReadOnly = true;
            this.dgvOffers.RowHeadersVisible = false;
            this.dgvOffers.RowTemplate.Height = 45;
            this.dgvOffers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOffers.Size = new System.Drawing.Size(1046, 531);
            this.dgvOffers.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnDeleteOffer);
            this.panel2.Controls.Add(this.btnAddOffer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1046, 70);
            this.panel2.TabIndex = 1;
            // 
            // btnDeleteOffer
            // 
            this.btnDeleteOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteOffer.FlatAppearance.BorderSize = 0;
            this.btnDeleteOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOffer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteOffer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOffer.Location = new System.Drawing.Point(936, 17);
            this.btnDeleteOffer.Name = "btnDeleteOffer";
            this.btnDeleteOffer.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteOffer.TabIndex = 9;
            this.btnDeleteOffer.Text = "Sil";
            this.btnDeleteOffer.UseVisualStyleBackColor = false;
            this.btnDeleteOffer.Click += new System.EventHandler(this.btnDeleteOffer_Click);
            // 
            // btnAddOffer
            // 
            this.btnAddOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnAddOffer.FlatAppearance.BorderSize = 0;
            this.btnAddOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOffer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddOffer.ForeColor = System.Drawing.Color.White;
            this.btnAddOffer.Location = new System.Drawing.Point(796, 17);
            this.btnAddOffer.Name = "btnAddOffer";
            this.btnAddOffer.Size = new System.Drawing.Size(120, 35);
            this.btnAddOffer.TabIndex = 8;
            this.btnAddOffer.Text = "Yeni Teklif";
            this.btnAddOffer.UseVisualStyleBackColor = false;
            this.btnAddOffer.Click += new System.EventHandler(this.btnAddOffer_Click);
            // 
            // InvoicesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "InvoicesView";
            this.Size = new System.Drawing.Size(1060, 640);
            this.Load += new System.EventHandler(this.InvoicesView_Load);
            this.tabControl.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabOffers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInvoices;
        private System.Windows.Forms.TabPage tabOffers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnDownloadEInvoice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeleteOffer;
        private System.Windows.Forms.Button btnAddOffer;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.DataGridView dgvOffers;
    }
}

