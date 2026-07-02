using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using System.Linq;
using ScottPlot;

namespace SmartAccount.UI.Views
{
    public partial class DashboardView : UserControl
    {
        private ReportService _reportService;
        private SmartAccountDbContext _context;

        public DashboardView()
        {
            InitializeComponent();
            _context = new SmartAccountDbContext();
            _reportService = new ReportService(_context);
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
            var summary = _reportService.GetDashboardSummary();

            lblTotalIncome.Text = summary.TotalIncome.ToString("C2");
            lblTotalExpense.Text = summary.TotalExpense.ToString("C2");
            lblNetBalance.Text = summary.NetBalance.ToString("C2");
            
            lblActiveCustomers.Text = summary.ActiveCustomersCount.ToString();
            lblPendingInvoicesCount.Text = summary.PendingInvoicesCount.ToString();
            lblPendingInvoicesAmount.Text = summary.PendingInvoicesAmount.ToString("C2");
            lblPendingWorks.Text = summary.PendingWorksCount.ToString();

            // Net bakiye rengi ayarlama
            lblNetBalance.ForeColor = summary.NetBalance >= 0 ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 57, 43);
            
            LoadChart();
        }

        private void LoadChart()
        {
            formsPlot1.Plot.Clear();
            var last30Days = DateTime.Now.AddDays(-30);
            
            var transactions = _context.Transactions
                .Where(t => t.Date >= last30Days)
                .GroupBy(t => new { t.Date.Date, t.Type })
                .Select(g => new { g.Key.Date, g.Key.Type, Total = g.Sum(x => x.Amount) })
                .ToList();

            var dates = Enumerable.Range(0, 31).Select(i => last30Days.AddDays(i).Date).ToList();
            
            double[] xs = dates.Select(d => d.ToOADate()).ToArray();
            double[] incomes = new double[31];
            double[] expenses = new double[31];

            for (int i = 0; i < 31; i++)
            {
                var date = dates[i];
                incomes[i] = (double)(transactions.FirstOrDefault(t => t.Date == date && t.Type == "Income")?.Total ?? 0);
                expenses[i] = (double)(transactions.FirstOrDefault(t => t.Date == date && t.Type == "Expense")?.Total ?? 0);
            }

            var incomeScatter = formsPlot1.Plot.Add.Scatter(xs, incomes);
            incomeScatter.Label = "Gelir";
            incomeScatter.Color = Colors.Green;
            
            var expenseScatter = formsPlot1.Plot.Add.Scatter(xs, expenses);
            expenseScatter.Label = "Gider";
            expenseScatter.Color = Colors.Red;

            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            formsPlot1.Plot.Title("Son 30 Günlük Gelir/Gider Akışı");
            formsPlot1.Plot.ShowLegend();
            formsPlot1.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}
