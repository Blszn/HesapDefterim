using System;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;

namespace SmartAccount.UI.Views
{
    public partial class PersonnelEditForm : Form
    {
        private EmployeeService _employeeService;
        private int? _employeeId;

        public PersonnelEditForm(int? employeeId = null)
        {
            InitializeComponent();
            _employeeService = new EmployeeService(new SmartAccountDbContext());
            _employeeId = employeeId;
        }

        private void PersonnelEditForm_Load(object sender, EventArgs e)
        {
            if (_employeeId.HasValue)
            {
                this.Text = "";
                LoadEmployeeData(_employeeId.Value);
            }
            else
            {
                this.Text = "Yeni Personel Ekle";
            }
        }

        private void LoadEmployeeData(int id)
        {
            var emp = _employeeService.GetEmployeeById(id);
            if (emp != null)
            {
                txtName.Text = emp.Name;
                txtSurname.Text = emp.Surname;
                txtTcNo.Text = emp.TcNo;
                txtPhone.Text = emp.Phone;
                txtPosition.Text = emp.Position;
                numSalary.Value = emp.Salary;
                dtpStartDate.Value = emp.StartDate;
                chkIsActive.Checked = emp.IsActive;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Employee emp;
            if (_employeeId.HasValue)
            {
                emp = _employeeService.GetEmployeeById(_employeeId.Value) ?? new Employee();
            }
            else
            {
                emp = new Employee();
            }

            emp.Name = txtName.Text.Trim();
            emp.Surname = txtSurname.Text.Trim();
            emp.TcNo = txtTcNo.Text.Trim();
            emp.Phone = txtPhone.Text.Trim();
            emp.Position = txtPosition.Text.Trim();
            emp.Salary = numSalary.Value;
            emp.StartDate = dtpStartDate.Value.Date;
            emp.IsActive = chkIsActive.Checked;

            (bool Success, string Message) result;

            if (_employeeId.HasValue)
            {
                result = _employeeService.UpdateEmployee(emp);
            }
            else
            {
                result = _employeeService.AddEmployee(emp);
            }

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

