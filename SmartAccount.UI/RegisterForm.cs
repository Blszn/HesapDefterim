using System;
using System.Drawing;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;

namespace SmartAccount.UI
{
    public partial class RegisterForm : Form
    {
        private UserService _userService;
        private SmartAccountDbContext _context;

        public RegisterForm()
        {
            InitializeComponent();
            _context = new SmartAccountDbContext();
            _userService = new UserService(_context);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Kullanıcı adı ve şifre boş olamaz!";
                lblError.Visible = true;
                return;
            }

            var result = _userService.Register(username, password);
            if (result.Success)
            {
                MessageBox.Show("Kayıt başarılı! Şimdi giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
