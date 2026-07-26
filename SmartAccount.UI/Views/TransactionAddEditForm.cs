using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Entities;
using SmartAccount.Core.Data;

namespace SmartAccount.UI.Views
{
    public partial class TransactionAddEditForm : Form
    {
        private string _type;
        private FinanceService _financeService;
        private SmartAccountDbContext _context;

        private int? _transactionId;
        private int? _defaultCustomerId;

        public TransactionAddEditForm(string type, FinanceService financeService, SmartAccountDbContext context, int? transactionId = null, int? defaultCustomerId = null)
        {
            InitializeComponent();
            _type = type;
            _financeService = financeService;
            _context = context;
            _transactionId = transactionId;
            _defaultCustomerId = defaultCustomerId;

            if (_type == "Income")
            {
                lblTitle.Text = "Yeni Gelir Ekle";
                panelTop.BackColor = Color.FromArgb(39, 174, 96);
            }
            else
            {
                lblTitle.Text = "Yeni Gider Ekle";
                panelTop.BackColor = Color.FromArgb(231, 76, 60);
            }

            LoadCategories();
            LoadCustomers();
            cmbPaymentMethod.SelectedIndex = 0; // Varsayılan: Nakit
            
            if (_defaultCustomerId.HasValue)
            {
                cmbCustomer.SelectedValue = _defaultCustomerId.Value;
            }

            if (_transactionId.HasValue)
            {
                lblTitle.Text = _type == "Income" ? "Gelir Güncelle" : "Gider Güncelle";
                LoadTransactionData();
            }

            txtAmount.KeyPress += Decimal_KeyPress;
        }

        private void LoadTransactionData()
        {
            var transaction = _financeService.GetTransactionById(_transactionId.Value);
            if (transaction != null)
            {
                txtAmount.Text = transaction.Amount.ToString("0.##");
                dtpDate.Value = transaction.Date;
                txtDescription.Text = transaction.Description;
                cmbCategory.SelectedValue = transaction.CategoryId;
                if (transaction.CustomerId.HasValue)
                {
                    cmbCustomer.SelectedValue = transaction.CustomerId.Value;
                }
                
                if (!string.IsNullOrEmpty(transaction.PaymentMethod))
                {
                    cmbPaymentMethod.SelectedItem = transaction.PaymentMethod;
                }
            }
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

        private void LoadCategories()
        {
            var categories = _financeService.GetCategories(_type);
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void LoadCustomers()
        {
            var customers = _context.Customers.OrderBy(c => c.FullName).ToList();
            customers.Insert(0, new Customer { Id = 0, FullName = "Seçiniz (Opsiyonel)" });
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Lütfen geçerli bir tutar girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_transactionId.HasValue)
            {
                var transaction = _financeService.GetTransactionById(_transactionId.Value);
                if (transaction != null)
                {
                    transaction.Amount = amount;
                    transaction.Date = dtpDate.Value;
                    transaction.Description = txtDescription.Text;
                    transaction.PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Nakit";
                    transaction.CategoryId = (int)cmbCategory.SelectedValue;
                    
                    if ((int)cmbCustomer.SelectedValue > 0)
                        transaction.CustomerId = (int)cmbCustomer.SelectedValue;
                    else
                        transaction.CustomerId = null;

                    var result = _financeService.UpdateTransaction(transaction);
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
            }
            else
            {
                var transaction = new Transaction
                {
                    Type = _type,
                    Amount = amount,
                    Date = dtpDate.Value,
                    Description = txtDescription.Text,
                    PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Nakit",
                    CategoryId = (int)cmbCategory.SelectedValue
                };

                if ((int)cmbCustomer.SelectedValue > 0)
                {
                    transaction.CustomerId = (int)cmbCustomer.SelectedValue;
                }

                var result = _financeService.AddTransaction(transaction);
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
