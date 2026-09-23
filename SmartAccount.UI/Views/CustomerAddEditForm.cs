using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Entities;

namespace SmartAccount.UI.Views
{
    public partial class CustomerAddEditForm : Form
    {
        private Customer? _customer;
        private CustomerService _customerService;
        private bool _isEditMode;

        public CustomerAddEditForm(Customer? customer, CustomerService customerService)
        {
            InitializeComponent();
            _customer = customer;
            _customerService = customerService;
            _isEditMode = _customer != null;

            if (_isEditMode)
            {
                lblTitle.Text = "";
                LoadCustomerData();
            }
            else
            {
                lblTitle.Text = "";
            }

            txtMobilePhone.KeyPress += Numeric_KeyPress;
            txtLandlinePhone.KeyPress += Numeric_KeyPress;
            txtTaxNumber.KeyPress += Numeric_KeyPress;
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control characters, space, dash, and plus sign
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ' ') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void LoadCustomerData()
        {
            if (_customer == null) return;
            
            txtFullName.Text = _customer.FullName;
            txtMobilePhone.Text = _customer.MobilePhone;
            txtLandlinePhone.Text = _customer.LandlinePhone;
            txtEmail.Text = _customer.Email;
            txtTaxOffice.Text = _customer.TaxOffice;
            txtTaxNumber.Text = _customer.TaxNumber;
            txtAddress.Text = _customer.Address;
            txtNotes.Text = _customer.Notes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isEditMode && _customer != null)
            {
                _customer.FullName = txtFullName.Text;
                _customer.MobilePhone = txtMobilePhone.Text;
                _customer.LandlinePhone = txtLandlinePhone.Text;
                _customer.Email = txtEmail.Text;
                _customer.TaxOffice = txtTaxOffice.Text;
                _customer.TaxNumber = txtTaxNumber.Text;
                _customer.Address = txtAddress.Text;
                _customer.Notes = txtNotes.Text;

                var result = _customerService.UpdateCustomer(_customer);
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
            else
            {
                var newCustomer = new Customer
                {
                    FullName = txtFullName.Text,
                    MobilePhone = txtMobilePhone.Text,
                    LandlinePhone = txtLandlinePhone.Text,
                    Email = txtEmail.Text,
                    TaxOffice = txtTaxOffice.Text,
                    TaxNumber = txtTaxNumber.Text,
                    Address = txtAddress.Text,
                    Notes = txtNotes.Text
                };

                var result = _customerService.AddCustomer(newCustomer);
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

