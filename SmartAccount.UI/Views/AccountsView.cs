using System;
using System.Windows.Forms;
using SmartAccount.Business.Services;

namespace SmartAccount.UI.Views
{
    public partial class AccountsView : UserControl
    {
        private AccountService _accountService;
        
        public AccountsView()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }
        
        private void AccountsView_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            dgvAccounts.DataSource = _accountService.GetAllAccounts();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
