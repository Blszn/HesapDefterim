using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using System.Linq;

namespace SmartAccount.UI.Views
{
    public partial class InvoicesView : UserControl
    {
        private DocumentService _documentService;
        private EInvoiceService _eInvoiceService;
        private SmartAccountDbContext _context;

        public InvoicesView()
        {
            InitializeComponent();
            _context = new SmartAccountDbContext();
            _documentService = new DocumentService(_context);
            _eInvoiceService = new EInvoiceService();
        }

        private void InvoicesView_Load(object sender, EventArgs e)
        {
            LoadInvoices();
            LoadOffers();
        }

        #region Invoices
        private void LoadInvoices()
        {
            var invoices = _documentService.GetInvoices();
            var displayList = invoices.Select(i => new {
                i.Id,
                FaturaNo = i.InvoiceNumber,
                Tarih = i.Date.ToShortDateString(),
                Musteri = i.Customer?.FullName ?? "-",
                Tutar = i.TotalAmount.ToString("C2"),
                Vergi = i.TotalTaxAmount.ToString("C2"),
                GenelToplam = i.GrandTotal.ToString("C2"),
                Durum = i.Status == "Paid" ? "Ödendi" : (i.Status == "Sent" ? "Gönderildi" : "Taslak")
            }).ToList();

            dgvInvoices.DataSource = displayList;
            if (dgvInvoices.Columns["Id"] != null) dgvInvoices.Columns["Id"].Visible = false;
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            using (var form = new InvoiceAddEditForm(_documentService, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadInvoices();
                }
            }
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count > 0)
            {
                int id = (int)dgvInvoices.SelectedRows[0].Cells["Id"].Value;
                if (MessageBox.Show("Faturayı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var res = _documentService.DeleteInvoice(id);
                    if (res.Success) LoadInvoices();
                    else MessageBox.Show(res.Message);
                }
            }
        }

        private void btnDownloadEInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count > 0)
            {
                int id = (int)dgvInvoices.SelectedRows[0].Cells["Id"].Value;
                var invoice = _context.Invoices.Find(id);
                if (invoice != null)
                {
                    // E-Fatura için müşteri bilgisi gerekir
                    _context.Entry(invoice).Reference(i => i.Customer).Load();
                    
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "XML Documents|*.xml", FileName = invoice.InvoiceNumber + "_UBL.xml" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                _eInvoiceService.GenerateUblXml(invoice, sfd.FileName);
                                MessageBox.Show("E-Fatura XML dosyası başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen dışa aktarılacak faturayı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Offers
        private void LoadOffers()
        {
            var offers = _documentService.GetOffers();
            var displayList = offers.Select(o => new {
                o.Id,
                TeklifNo = o.OfferNumber,
                Tarih = o.Date.ToShortDateString(),
                Musteri = o.Customer?.FullName ?? "-",
                Tutar = o.TotalAmount.ToString("C2"),
                Durum = o.Status == "Accepted" ? "Kabul Edildi" : (o.Status == "Rejected" ? "Reddedildi" : (o.Status == "Sent" ? "Gönderildi" : "Taslak"))
            }).ToList();

            dgvOffers.DataSource = displayList;
            if (dgvOffers.Columns["Id"] != null) dgvOffers.Columns["Id"].Visible = false;
        }

        private void btnAddOffer_Click(object sender, EventArgs e)
        {
            using (var form = new OfferAddEditForm(_documentService, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOffers();
                }
            }
        }

        private void btnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (dgvOffers.SelectedRows.Count > 0)
            {
                int id = (int)dgvOffers.SelectedRows[0].Cells["Id"].Value;
                if (MessageBox.Show("Teklifi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var res = _documentService.DeleteOffer(id);
                    if (res.Success) LoadOffers();
                    else MessageBox.Show(res.Message);
                }
            }
        }
        #endregion
    }
}
