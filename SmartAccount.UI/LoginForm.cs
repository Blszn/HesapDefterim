using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;

namespace SmartAccount.UI
{
    public partial class LoginForm : Form
    {
        private UserService _userService;
        private SmartAccountDbContext _context;

        public LoginForm()
        {
            InitializeComponent();
            _context = new SmartAccountDbContext();
            _userService = new UserService(_context);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Lütfen kullanıcı adı ve şifre giriniz.";
                lblError.Visible = true;
                return;
            }

            var result = _userService.Login(username, password);
            if (result.Success)
            {
                MainForm mainForm = new MainForm(result.User!);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = result.Message;
                lblError.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
