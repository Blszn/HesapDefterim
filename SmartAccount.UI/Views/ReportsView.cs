using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SmartAccount.UI.Views
{
    public partial class ReportsView : UserControl
    {
        private ExportService _exportService;
        private DocumentService _documentService;
        private SmartAccountDbContext _context;

        public ReportsView()
        {
            InitializeComponent();
            _exportService = new ExportService();
            _context = new SmartAccountDbContext();
            _documentService = new DocumentService(_context);
        }

        private void ReportsView_Load(object sender, EventArgs e)
        {
        }

        private void btnExportInvoicesPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF Documents|*.pdf", FileName = "Faturalar.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var invoices = _documentService.GetInvoices();
                        _exportService.ExportInvoicesToPdf(invoices, sfd.FileName);
                        MessageBox.Show("PDF başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportInvoicesExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Faturalar.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var invoices = _documentService.GetInvoices();
                        _exportService.ExportInvoicesToExcel(invoices, sfd.FileName);
                        MessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
