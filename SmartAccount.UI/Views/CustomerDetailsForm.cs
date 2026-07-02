using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Core.Data;
using System.Linq;
using SmartAccount.Core.Entities;
using System.IO;

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
                .OrderByDescending(t => t.Date)
                .Select(t => new {
                    t.Date,
                    t.Type,
                    t.Amount,
                    t.Description
                }).ToList();

            dgvExtre.DataSource = transactions;
            
            decimal bakiye = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount) 
                           - transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
                           
            lblBakiye.Text = $"Güncel Bakiye: {bakiye:C2}";
            lblBakiye.ForeColor = bakiye >= 0 ? Color.Green : Color.Red;
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
    }
}
