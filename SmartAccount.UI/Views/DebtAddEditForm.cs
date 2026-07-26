using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Entities;
using SmartAccount.Core.Data;

namespace SmartAccount.UI.Views
{
    public partial class DebtAddEditForm : Form
    {
        private string _type;
        private int _customerId;
        private FinanceService _financeService;
        private SmartAccountDbContext _context;

        public DebtAddEditForm(string type, int customerId, FinanceService financeService, SmartAccountDbContext context)
        {
            InitializeComponent();
            _type = type;
            _customerId = customerId;
            _financeService = financeService;
            _context = context;

            if (_type == "Receivable")
            {
                lblTitle.Text = "Bize Borçlandır (Alacak Ekle)";
                panelTop.BackColor = Color.FromArgb(39, 174, 96);
            }
            else
            {
                lblTitle.Text = "Biz Borçluyuz (Borç Ekle)";
                panelTop.BackColor = Color.FromArgb(231, 76, 60);
            }

            txtAmount.KeyPress += Decimal_KeyPress;
            dtpDueDate.Value = DateTime.Today;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir tutar girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var debt = new Debt
            {
                Type = _type,
                Amount = amount,
                DueDate = dtpDueDate.Value,
                Description = txtDescription.Text,
                Status = "Pending",
                CustomerId = _customerId
            };

            var result = _financeService.AddDebt(debt);
            if (result.Success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}