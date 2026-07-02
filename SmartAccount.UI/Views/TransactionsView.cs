using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;

namespace SmartAccount.UI.Views
{
    public partial class TransactionsView : UserControl
    {
        private FinanceService _financeService;
        private SmartAccountDbContext _context;

        public TransactionsView()
        {
            InitializeComponent();
            _context = new SmartAccountDbContext();
            _financeService = new FinanceService(_context);
            
            cmbType.SelectedIndex = 0; // Tümü
            
            // Türkçe Çeviri
            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex >= 0)
            {
                var columnName = dgvTransactions.Columns[e.ColumnIndex].Name;
                if (columnName == "Tur")
                {
                    string val = e.Value.ToString() ?? "";
                    if (val == "Income") e.Value = "Gelir";
                    else if (val == "Expense") e.Value = "Gider";
                    e.FormattingApplied = true;
                }
            }
        }

        private void TransactionsView_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddMonths(-1);
            dtpEnd.Value = DateTime.Now;
            cmbType.SelectedIndex = 0; // Tümü
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            string? typeFilter = null;
            if (cmbType.SelectedIndex == 1) typeFilter = "Income";
            else if (cmbType.SelectedIndex == 2) typeFilter = "Expense";

            var transactions = _financeService.GetTransactions(dtpStart.Value, dtpEnd.Value, typeFilter);
            
            // Generate anonymous type for DataGridView to format nicely
            var displayList = transactions.Select(t => new {
                t.Id,
                Tarih = t.Date.ToShortDateString(),
                Tur = t.Type == "Income" ? "Gelir" : "Gider",
                Kategori = t.Category?.Name ?? "",
                Tutar = t.Amount.ToString("C2"),
                Aciklama = t.Description,
                Musteri = t.Customer?.FullName ?? "-"
            }).ToList();

            dgvTransactions.DataSource = displayList;
            if (dgvTransactions.Columns["Id"] != null) dgvTransactions.Columns["Id"].Visible = false;

            CalculateTotals(transactions);
        }

        private void CalculateTotals(System.Collections.Generic.List<Transaction> transactions)
        {
            decimal totalIncome = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal totalExpense = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            decimal net = totalIncome - totalExpense;

            lblIncome.Text = $"Toplam Gelir: {totalIncome:C2}";
            lblExpense.Text = $"Toplam Gider: {totalExpense:C2}";
            lblNet.Text = $"Net Durum: {net:C2}";
            lblNet.ForeColor = net >= 0 ? Color.Green : Color.Red;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            using (var form = new TransactionAddEditForm("Income", _financeService, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            using (var form = new TransactionAddEditForm("Expense", _financeService, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                int id = (int)dgvTransactions.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçili işlemi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    var res = _financeService.DeleteTransaction(id);
                    if (res.Success) LoadTransactions();
                    else MessageBox.Show(res.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
