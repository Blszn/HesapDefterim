using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Core.Entities;

namespace SmartAccount.UI
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblUserInfo.Text = "";
            
            try
            {
                pictureBoxLogo.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Assets", "logo.png"));
            }
            catch { }
            
            // Wire up buttons
            btnDashboard.Click += BtnDashboard_Click;
            btnCustomers.Click += BtnCustomers_Click;
            btnTransactions.Click += BtnTransactions_Click;
            btnInvoices.Click += BtnInvoices_Click;
            btnWorks.Click += BtnWorks_Click;
            btnReports.Click += BtnReports_Click;
            btnProducts.Click += BtnProducts_Click;
            btnAccounts.Click += BtnAccounts_Click;
            btnSettings.Click += BtnSettings_Click;

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            // Load dashboard by default
            BtnDashboard_Click(this, EventArgs.Empty);
        }

        private void BtnDashboard_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "Ana Panel (Dashboard)";
            pnlContent.Controls.Clear();
            var dashboardView = new Views.DashboardView();
            dashboardView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dashboardView);
        }

        private void BtnReports_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "Raporlar";
            pnlContent.Controls.Clear();
            var reportsView = new Views.ReportsView();
            reportsView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(reportsView);
        }

        private void BtnProducts_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "";
            pnlContent.Controls.Clear();
            var view = new Views.ProductsView();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
        }

        private void BtnAccounts_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "Kasa ve Banka";
            pnlContent.Controls.Clear();
            var view = new Views.AccountsView();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
        }

        private void BtnSettings_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "Ayarlar";
            pnlContent.Controls.Clear();
            var view = new Views.SettingsView();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
        }

        private void BtnWorks_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "";
            pnlContent.Controls.Clear();
            var worksView = new Views.WorksView();
            worksView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(worksView);
        }

        private void BtnInvoices_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "Faturalar ve Teklifler";
            pnlContent.Controls.Clear();
            var invoicesView = new Views.InvoicesView();
            invoicesView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(invoicesView);
        }

        private void BtnTransactions_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "Gelir / Gider";
            pnlContent.Controls.Clear();
            var transactionsView = new Views.TransactionsView();
            transactionsView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(transactionsView);
        }

        private void BtnCustomers_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "";
            pnlContent.Controls.Clear();
            var customersView = new Views.CustomersView();
            customersView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(customersView);
        }

        private void btnPersonnel_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "";
            pnlContent.Controls.Clear();
            var form = new Views.PersonnelListForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
        }

        private void btnDailyReport_Click(object? sender, EventArgs e)
        {
            lblPageTitle.Text = "";
            pnlContent.Controls.Clear();
            var form = new Views.DailyReportForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGlobalSearch_Click(object sender, EventArgs e)
        {
            PerformGlobalSearch(txtGlobalSearch.Text);
        }

        private void txtGlobalSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformGlobalSearch(txtGlobalSearch.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void PerformGlobalSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return;

            lblPageTitle.Text = "";
            pnlContent.Controls.Clear();
            var customersView = new Views.CustomersView();
            customersView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(customersView);
            customersView.PerformSearch(keyword);
        }
    }
}

