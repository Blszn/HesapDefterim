using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using System.Linq;

namespace SmartAccount.UI.Views
{
    public partial class WorksView : UserControl
    {
        private WorkService _workService;
        private SmartAccountDbContext _context;

        public WorksView()
        {
            InitializeComponent();
            _context = new SmartAccountDbContext();
            _workService = new WorkService(_context);
        }

        private void WorksView_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0; // Tümü
            LoadWorks();
        }

        private void LoadWorks()
        {
            string? statusFilter = null;
            if (cmbStatusFilter.SelectedIndex == 1) statusFilter = "Planned";
            else if (cmbStatusFilter.SelectedIndex == 2) statusFilter = "InProgress";
            else if (cmbStatusFilter.SelectedIndex == 3) statusFilter = "Completed";

            var works = _workService.GetWorks(statusFilter);
            
            var displayList = works.Select(w => new {
                w.Id,
                Baslik = w.Description,
                Musteri = w.Customer?.FullName ?? "-",
                BaslamaTarihi = w.StartDate.ToShortDateString(),
                BitisTarihi = w.EndDate?.ToShortDateString() ?? "-",
                Durum = w.Status == "Completed" ? "" : (w.Status == "InProgress" ? "Devam Ediyor" : "")
            }).ToList();

            dgvWorks.DataSource = displayList;
            if (dgvWorks.Columns["Id"] != null) dgvWorks.Columns["Id"].Visible = false;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadWorks();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new WorkAddEditForm(null, _workService, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadWorks();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count > 0)
            {
                int id = (int)dgvWorks.SelectedRows[0].Cells["Id"].Value;
                var workToEdit = _context.Works.Find(id);
                
                if (workToEdit != null)
                {
                    using (var form = new WorkAddEditForm(workToEdit, _workService, _context))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadWorks();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count > 0)
            {
                int id = (int)dgvWorks.SelectedRows[0].Cells["Id"].Value;
                if (MessageBox.Show("", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var res = _workService.DeleteWork(id);
                    if (res.Success) LoadWorks();
                    else MessageBox.Show(res.Message);
                }
            }
            else
            {
                MessageBox.Show("");
            }
        }
    }
}

