using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Entities;
using SmartAccount.Core.Data;

namespace SmartAccount.UI.Views
{
    public partial class WorkAddEditForm : Form
    {
        private WorkService _workService;
        private SmartAccountDbContext _context;
        private Work? _work;
        private bool _isEditMode;

        public WorkAddEditForm(Work? work, WorkService workService, SmartAccountDbContext context)
        {
            InitializeComponent();
            _work = work;
            _workService = workService;
            _context = context;
            _isEditMode = _work != null;

            LoadCustomers();

            if (_isEditMode)
            {
                lblTitle.Text = "";
                btnSave.Text = "";
                LoadWorkData();
            }
            else
            {
                lblTitle.Text = "";
                cmbStatus.SelectedIndex = 0; // Bekliyor
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

        private void LoadWorkData()
        {
            if (_work == null) return;
            txtTitle.Text = _work.Description; // Main title uses Description in DB
            txtDescription.Text = _work.Notes;
            dtpStartDate.Value = _work.StartDate;
            if (_work.EndDate.HasValue) dtpEndDate.Value = _work.EndDate.Value;
            
            if (_work.Status == "Planned") cmbStatus.SelectedIndex = 0;
            else if (_work.Status == "InProgress") cmbStatus.SelectedIndex = 1;
            else if (_work.Status == "Completed") cmbStatus.SelectedIndex = 2;

            if (_work.CustomerId > 0)
                cmbCustomer.SelectedValue = _work.CustomerId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                txtTitle.Text = " ";
            }

            if (_isEditMode && _work != null)
            {
                _work.Description = txtTitle.Text;
                _work.Notes = txtDescription.Text;
                _work.StartDate = dtpStartDate.Value;
                _work.EndDate = dtpEndDate.Value;
                
                if (cmbStatus.SelectedIndex == 0) _work.Status = "Planned";
                else if (cmbStatus.SelectedIndex == 1) _work.Status = "InProgress";
                else if (cmbStatus.SelectedIndex == 2) _work.Status = "Completed";

                if ((int)cmbCustomer.SelectedValue > 0)
                    _work.CustomerId = (int)cmbCustomer.SelectedValue;
                else
                    _work.CustomerId = 0;

                var res = _workService.UpdateWork(_work);
                if (res.Success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show(res.Message);
            }
            else
            {
                var work = new Work
                {
                    Description = txtTitle.Text,
                    Notes = txtDescription.Text,
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value
                };

                if (cmbStatus.SelectedIndex == 0) work.Status = "Planned";
                else if (cmbStatus.SelectedIndex == 1) work.Status = "InProgress";
                else if (cmbStatus.SelectedIndex == 2) work.Status = "Completed";

                if ((int)cmbCustomer.SelectedValue > 0)
                    work.CustomerId = (int)cmbCustomer.SelectedValue;

                var res = _workService.AddWork(work);
                if (res.Success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show(res.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

