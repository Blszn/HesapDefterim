using System;
using System.Linq;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;

namespace SmartAccount.UI.Views
{
    public partial class PersonnelListForm : Form
    {
        private EmployeeService _employeeService;

        public PersonnelListForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService(new SmartAccountDbContext());
        }

        private void PersonnelListForm_Load(object sender, EventArgs e)
        {
            LoadPersonnel();
        }

        private void LoadPersonnel()
        {
            var employees = _employeeService.GetEmployees();
            
            var displayList = employees.Select(emp => new
            {
                emp.Id,
                AdSoyad = emp.FullName,
                TCNo = emp.TcNo,
                Telefon = emp.Phone,
                Pozisyon = emp.Position,
                Maaş = emp.Salary.ToString("C2"),
                İşeBaşlama = emp.StartDate.ToShortDateString(),
                Durum = emp.IsActive ? "Aktif" : "Pasif"
            }).ToList();

            dgvPersonnel.DataSource = displayList;
            
            if (dgvPersonnel.Columns["Id"] != null)
                dgvPersonnel.Columns["Id"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new PersonnelEditForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadPersonnel();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count == 0)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvPersonnel.SelectedRows[0].Cells["Id"].Value;
            var frm = new PersonnelEditForm(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadPersonnel();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count == 0)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvPersonnel.SelectedRows[0].Cells["Id"].Value;
            var empName = dgvPersonnel.SelectedRows[0].Cells["AdSoyad"].Value.ToString();

            if (MessageBox.Show("", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = _employeeService.DeleteEmployee(id);
                if (result.Success)
                {
                    LoadPersonnel();
                }
                else
                {
                    MessageBox.Show(result.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

