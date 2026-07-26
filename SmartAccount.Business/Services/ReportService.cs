using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartAccount.Business.Services
{
    public class ReportService
    {
        private readonly SmartAccountDbContext _context;

        public ReportService(SmartAccountDbContext context)
        {
            _context = context;
        }

        public DashboardSummary GetDashboardSummary()
        {
            var summary = new DashboardSummary();

            // Total Income (Transactions)
            summary.TotalIncome = _context.Transactions
                .Where(t => t.Type == "Income")
                .Sum(t => (decimal?)t.Amount) ?? 0;

            // Total Expense (Transactions)
            summary.TotalExpense = _context.Transactions
                .Where(t => t.Type == "Expense")
                .Sum(t => (decimal?)t.Amount) ?? 0;

            // Net Balance
            summary.NetBalance = summary.TotalIncome - summary.TotalExpense;

            // Active Customers
            summary.ActiveCustomersCount = _context.Customers.Count();

            // Pending Invoices Amount & Count
            var pendingInvoices = _context.Invoices.Where(i => i.Status == "Draft" || i.Status == "Sent");
            summary.PendingInvoicesCount = pendingInvoices.Count();
            summary.PendingInvoicesAmount = pendingInvoices.Sum(i => (decimal?)i.GrandTotal) ?? 0;

            // Pending Works Count
            summary.PendingWorksCount = _context.Works.Where(w => w.Status == "Planned" || w.Status == "InProgress").Count();

            return summary;
        }

        public DailyReportSummary GetDailyReport(DateTime date)
        {
            var summary = new DailyReportSummary();
            var targetDate = date.Date;
            
            var dailyTransactions = _context.Transactions
                .Where(t => t.Date.Date == targetDate)
                .ToList();

            summary.Transactions = dailyTransactions;
            summary.TotalIncome = dailyTransactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            summary.TotalExpense = dailyTransactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            summary.NetBalance = summary.TotalIncome - summary.TotalExpense;

            return summary;
        }
    }

    public class DashboardSummary
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetBalance { get; set; }
        public int ActiveCustomersCount { get; set; }
        public int PendingInvoicesCount { get; set; }
        public decimal PendingInvoicesAmount { get; set; }
        public int PendingWorksCount { get; set; }
    }

    public class DailyReportSummary
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetBalance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
