using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Entities;
using SmartAccount.Core.Data;

namespace SmartAccount.UI.Views
{
    public partial class OfferAddEditForm : Form
    {
        private DocumentService _documentService;
        private SmartAccountDbContext _context;

        public OfferAddEditForm(DocumentService documentService, SmartAccountDbContext context)
        {
            InitializeComponent();
            _documentService = documentService;
            _context = context;
            LoadCustomers();
            cmbStatus.SelectedIndex = 0; // Bekliyor

            txtTotalAmount.KeyPress += Decimal_KeyPress;
        }

        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void LoadCustomers()
        {
            var customers = _context.Customers.OrderBy(c => c.FullName).ToList();
            customers.Insert(0, new Customer { Id = 0, FullName = "" });
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((int)cmbCustomer.SelectedValue == 0)
            {
                MessageBox.Show("");
                return;
            }

            if (!decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount))
            {
                MessageBox.Show("");
                return;
            }
            
            var offer = new Offer
            {
                OfferNumber = "TEK-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Status = cmbStatus.SelectedIndex == 0 ? "Draft" : (cmbStatus.SelectedIndex == 1 ? "Accepted" : "Rejected"),
                Date = dtpOfferDate.Value,
                TotalAmount = totalAmount,
                GrandTotal = totalAmount,
                CustomerId = (int)cmbCustomer.SelectedValue
            };

            var result = _documentService.AddOffer(offer);
            if (result.Success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

