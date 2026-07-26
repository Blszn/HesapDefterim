using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;

namespace SmartAccount.UI.Views
{
    public partial class DailyReportForm : Form
    {
        private ReportService _reportService;

        public DailyReportForm()
        {
            InitializeComponent();
            _reportService = new ReportService(new SmartAccountDbContext());
        }

        private void DailyReportForm_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
            LoadReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            var date = dtpDate.Value;
            var summary = _reportService.GetDailyReport(date);

            lblTotalIncome.Text = summary.TotalIncome.ToString("C2");
            lblTotalExpense.Text = summary.TotalExpense.ToString("C2");
            lblNetBalance.Text = summary.NetBalance.ToString("C2");

            if (summary.NetBalance >= 0)
            {
                lblNetBalance.ForeColor = Color.FromArgb(39, 174, 96);
            }
            else
            {
                lblNetBalance.ForeColor = Color.FromArgb(192, 57, 43);
            }

            var displayList = summary.Transactions.Select(t => new
            {
                Tip = t.Type == "Income" ? "Gelir" : "Gider",
                OdemeYontemi = t.PaymentMethod,
                Tutar = t.Amount.ToString("C2"),
                Açıklama = t.Description,
                KayıtZamanı = t.CreatedAt.ToShortTimeString()
            }).ToList();

            dgvTransactions.DataSource = displayList;
        }
    }
}
