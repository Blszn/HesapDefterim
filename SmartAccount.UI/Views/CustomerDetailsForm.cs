using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Core.Data;
using System.Linq;
using SmartAccount.Core.Entities;
using System.IO;
using SmartAccount.Business.Services;

namespace SmartAccount.UI.Views
{
    public partial class CustomerDetailsForm : Form
    {
        private int _customerId;
        private SmartAccountDbContext _context;

        public CustomerDetailsForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            _context = new SmartAccountDbContext();
        }

        private void CustomerDetailsForm_Load(object sender, EventArgs e)
        {
            var customer = _context.Customers.Find(_customerId);
            if (customer != null)
            {
                this.Text = "";
                lblCustomerName.Text = customer.FullName;
                LoadExtre();
                LoadAttachments();
            }
        }

        private void LoadExtre()
        {
            var transactions = _context.Transactions
                .Where(t => t.CustomerId == _customerId)
                .ToList();
                
            var debts = _context.Debts
                .Where(d => d.CustomerId == _customerId)
                .ToList();

            var extreItems = transactions.Select(t => new {
                Tarih = t.Date,
                IslemTuru = t.Type == "Income" ? "" : "",
                Tutar = t.Amount,
                Aciklama = t.Description
            }).Concat(debts.Select(d => new {
                Tarih = d.DueDate,
                IslemTuru = d.Type == "Receivable" ? "Alacak" : "",
                Tutar = d.Amount,
                Aciklama = d.Description
            })).OrderByDescending(x => x.Tarih).ToList();

            dgvExtre.DataSource = extreItems;
            
            decimal totalReceivables = debts.Where(d => d.Type == "Receivable").Sum(d => d.Amount);
            decimal totalPayables = debts.Where(d => d.Type == "Payable").Sum(d => d.Amount);
            decimal totalIncomes = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal totalExpenses = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);

            decimal bakiye = (totalReceivables + totalExpenses) - (totalPayables + totalIncomes);
                           
            if (bakiye > 0)
            {
                lblBakiye.Text = $"Alacak: {bakiye:C2}";
                lblBakiye.ForeColor = Color.Green;
            }
            else if (bakiye < 0)
            {
                lblBakiye.Text = $"Bor�: {Math.Abs(bakiye):C2}";
                lblBakiye.ForeColor = Color.Red;
            }
            else
            {
                lblBakiye.Text = $"Bakiye: 0,00 ₺";
                lblBakiye.ForeColor = Color.Black;
            }
        }
        
        private void btnAlacaklandir_Click(object sender, EventArgs e)
        {
            using (var form = new DebtAddEditForm("Receivable", _customerId, new FinanceService(_context), _context))
            {
                if (form.ShowDialog() == DialogResult.OK) LoadExtre();
            }
        }

        private void btnBorclandir_Click(object sender, EventArgs e)
        {
            using (var form = new DebtAddEditForm("Payable", _customerId, new FinanceService(_context), _context))
            {
                if (form.ShowDialog() == DialogResult.OK) LoadExtre();
            }
        }

        private void btnTahsilat_Click(object sender, EventArgs e)
        {
            using (var form = new TransactionAddEditForm("Income", new FinanceService(_context), _context, null, _customerId))
            {
                if (form.ShowDialog() == DialogResult.OK) LoadExtre();
            }
        }

        private void btnTediye_Click(object sender, EventArgs e)
        {
            using (var form = new TransactionAddEditForm("Expense", new FinanceService(_context), _context, null, _customerId))
            {
                if (form.ShowDialog() == DialogResult.OK) LoadExtre();
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvExtre.Rows.Count == 0)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "", FileName = "CariEkstre.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                            iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                            iTextSharp.text.pdf.BaseFont baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
                            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font textFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                            
                            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(lblCustomerName.Text + " Cari Ekstresi", titleFont);
                            title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                            pdfDoc.Add(title);
                            pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                            iTextSharp.text.pdf.PdfPTable pdfTable = new iTextSharp.text.pdf.PdfPTable(dgvExtre.Columns.Count);
                            pdfTable.WidthPercentage = 100;

                            foreach (DataGridViewColumn column in dgvExtre.Columns)
                            {
                                iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(column.HeaderText, textFont));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvExtre.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    string cellText = cell.Value != null ? cell.Value.ToString() : string.Empty;
                                    pdfTable.AddCell(new iTextSharp.text.Phrase(cellText, textFont));
                                }
                            }

                            pdfDoc.Add(pdfTable);
                            
                            iTextSharp.text.Paragraph bakiyeText = new iTextSharp.text.Paragraph("\n" + lblBakiye.Text, titleFont);
                            bakiyeText.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            pdfDoc.Add(bakiyeText);
                            
                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start("explorer.exe", sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadAttachments()
        {
            var attachments = _context.Attachments
                .Where(a => a.EntityName == "Customer" && a.EntityId == _customerId)
                .OrderByDescending(a => a.UploadDate)
                .ToList();
                
            dgvAttachments.DataSource = attachments;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string targetFolder = Path.Combine(Application.StartupPath, "Attachments", "Customers", _customerId.ToString());
                    Directory.CreateDirectory(targetFolder);
                    
                    string fileName = Path.GetFileName(ofd.FileName);
                    string destFile = Path.Combine(targetFolder, fileName);
                    
                    File.Copy(ofd.FileName, destFile, true);
                    
                    var attachment = new Attachment
                    {
                        EntityName = "Customer",
                        EntityId = _customerId,
                        FileName = fileName,
                        FilePath = destFile,
                        UploadDate = DateTime.Now
                    };
                    
                    _context.Attachments.Add(attachment);
                    _context.SaveChanges();
                    
                    LoadAttachments();
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvAttachments.SelectedRows.Count > 0)
            {
                var attachment = (Attachment)dgvAttachments.SelectedRows[0].DataBoundItem;
                if (File.Exists(attachment.FilePath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", attachment.FilePath);
                }
                else
                {
                    MessageBox.Show("", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            if (dgvAttachments.SelectedRows.Count > 0)
            {
                var attachment = (Attachment)dgvAttachments.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show("", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (File.Exists(attachment.FilePath))
                        {
                            File.Delete(attachment.FilePath);
                        }

                        _context.Attachments.Remove(attachment);
                        _context.SaveChanges();
                        LoadAttachments();
                        MessageBox.Show("", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}


