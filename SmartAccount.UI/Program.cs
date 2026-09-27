using System;
using System.Windows.Forms;
using SmartAccount.Business.Services;
using SmartAccount.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartAccount.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            
            // Seed VeritabanÄ± ve Admin
            using (var context = new SmartAccountDbContext())
            {
                context.Database.Migrate(); // Migration varsa uygula
                var userService = new UserService(context);
                userService.EnsureAdminExists(); // Ä°lk kullanÄ±cÄ± yoksa admin ekle
                
                var financeService = new FinanceService(context);
                financeService.EnsureDefaultCategoriesExist(); // Temel kategorileri ekle
            }

            Application.Run(new LoginForm());
        }
    }
}
