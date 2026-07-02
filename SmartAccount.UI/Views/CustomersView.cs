using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;

namespace SmartAccount.UI.Views
{
    public partial class CustomersView : UserControl
    {
        private CustomerService _customerService;
        private SmartAccountDbContext _context;

        public CustomersView()
        {
            InitializeComponent();
            _context = new SmartAccountDbContext();
            _customerService = new CustomerService(_context);
        }

        private void CustomersView_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers(string keyword = "")
        {
            var customers = _customerService.SearchCustomers(keyword);
            dgvCustomers.DataSource = customers;
            
            // Format DataGridView
            if (dgvCustomers.Columns["Id"] != null) dgvCustomers.Columns["Id"].Visible = false;
            if (dgvCustomers.Columns["CreatedAt"] != null) dgvCustomers.Columns["CreatedAt"].Visible = false;
            if (dgvCustomers.Columns["UpdatedAt"] != null) dgvCustomers.Columns["UpdatedAt"].Visible = false;
            if (dgvCustomers.Columns["IsDeleted"] != null) dgvCustomers.Columns["IsDeleted"].Visible = false;

            if (dgvCustomers.Columns["FullName"] != null) dgvCustomers.Columns["FullName"].HeaderText = "Ad Soyad";
            if (dgvCustomers.Columns["MobilePhone"] != null) dgvCustomers.Columns["MobilePhone"].HeaderText = "Cep Telefonu";
            if (dgvCustomers.Columns["TaxNumber"] != null) dgvCustomers.Columns["TaxNumber"].HeaderText = "Vergi No";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new CustomerAddEditForm(null, _customerService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers(txtSearch.Text);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var customer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                using (var form = new CustomerAddEditForm(customer, _customerService))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadCustomers(txtSearch.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var customer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"{customer.FullName} adlı müşteriyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    var response = _customerService.DeleteCustomer(customer.Id);
                    if (response.Success)
                    {
                        MessageBox.Show(response.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers(txtSearch.Text);
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var customer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                using (var form = new CustomerDetailsForm(customer.Id))
                {
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Lütfen detaylarını görmek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadCustomers(txtSearch.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public void PerformSearch(string keyword)
        {
            txtSearch.Text = keyword;
            LoadCustomers(keyword);
        }
    }
}
