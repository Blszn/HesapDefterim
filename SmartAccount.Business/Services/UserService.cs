using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using SmartAccount.Business.Helpers;
using System.Linq;
using System;

namespace SmartAccount.Business.Services
{
    public class UserService
    {
        private readonly SmartAccountDbContext _context;

        public UserService(SmartAccountDbContext context)
        {
            _context = context;
        }

        public void EnsureAdminExists()
        {
            if (!_context.Users.Any())
            {
                string salt = SecurityHelper.GenerateSalt();
                string hash = SecurityHelper.HashPassword("admin123", salt);

                var adminUser = new User
                {
                    Username = "admin",
                    PasswordHash = hash,
                    Salt = salt,
                    Role = "Admin",
                    SecurityQuestion = "En sevdiğiniz renk?",
                    SecurityAnswerHash = SecurityHelper.HashPassword("mavi", salt)
                };

                _context.Users.Add(adminUser);
                _context.SaveChanges();
            }
        }

        public (bool Success, string Message, User? User) Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return (false, "Kullanıcı adı veya şifre hatalı.", null);
            }

            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
            {
                return (false, $"Hesabınız kilitli. Lütfen {user.LockoutEnd.Value:HH:mm:ss} sonrasında tekrar deneyin.", null);
            }

            bool isValid = SecurityHelper.VerifyPassword(password, user.PasswordHash, user.Salt);

            if (isValid)
            {
                user.FailedLoginAttempts = 0;
                user.LockoutEnd = null;
                _context.SaveChanges();
                return (true, "Giriş başarılı.", user);
            }
            else
            {
                user.FailedLoginAttempts++;
                if (user.FailedLoginAttempts >= 3)
                {
                    user.LockoutEnd = DateTime.Now.AddMinutes(5); // 5 dakika bloklama
                    _context.SaveChanges();
                    return (false, "Çok fazla hatalı deneme! Hesabınız 5 dakika kilitlendi.", null);
                }
                _context.SaveChanges();
                return (false, "Kullanıcı adı veya şifre hatalı.", null);
            }
        }
    }
}
