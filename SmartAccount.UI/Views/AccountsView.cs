using System;
using System.Windows.Forms;
using System.Linq;
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
            var accounts = _accountService.GetAllAccounts();
            dgvAccounts.DataSource = accounts.Select(a => new {
                ID = a.Id,
                HesapAdı = a.Name,
                Tür = a.Type == "Cash" ? "Kasa" : "Banka",
                Bakiye = a.Balance,
                ParaBirimi = a.Currency,
                BankaAdı = a.BankName,
                IBAN = a.IBAN
            }).ToList();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
