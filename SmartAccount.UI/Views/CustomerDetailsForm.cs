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
                this.Text = $"Cari Detayları - {customer.FullName}";
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
                IslemTuru = t.Type == "Income" ? "Tahsilat Alındı" : "Ödeme Yapıldı",
                Tutar = t.Amount,
                Aciklama = t.Description
            }).Concat(debts.Select(d => new {
                Tarih = d.DueDate,
                IslemTuru = d.Type == "Receivable" ? "Bize Borçlandırıldı" : "Biz Borçlandık",
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
                lblBakiye.Text = $"Bize Borcu Var: {bakiye:C2}";
                lblBakiye.ForeColor = Color.Green;
            }
            else if (bakiye < 0)
            {
                lblBakiye.Text = $"Bizim Borcumuz: {Math.Abs(bakiye):C2}";
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
                    MessageBox.Show("Dosya bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            if (dgvAttachments.SelectedRows.Count > 0)
            {
                var attachment = (Attachment)dgvAttachments.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"'{attachment.FileName}' dosyasını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                        MessageBox.Show("Belge başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Belge silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir belge seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
