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
                    SecurityQuestion = "",
                    SecurityAnswerHash = SecurityHelper.HashPassword("", salt)
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
                return (false, "", null);
            }

            bool isValid = SecurityHelper.VerifyPassword(password, user.PasswordHash, user.Salt);

            if (isValid)
            {
                user.FailedLoginAttempts = 0;
                user.LockoutEnd = null;
                _context.SaveChanges();
                return (true, "", user);
            }
            else
            {
                return (false, "", null);
            }
        }
    }
}

