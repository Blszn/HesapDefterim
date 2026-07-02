using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace SmartAccount.Business.Services
{
    public class AccountService
    {
        private readonly SmartAccountDbContext _context;

        public AccountService()
        {
            _context = new SmartAccountDbContext();
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public Account? GetAccountById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public decimal CalculateAccountBalance(int accountId)
        {
            var account = _context.Accounts.Include(a => a.Transactions).FirstOrDefault(a => a.Id == accountId);
            if (account == null) return 0;
            
            decimal income = account.Transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal expense = account.Transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            
            return account.Balance + income - expense;
        }

        public (bool Success, string Message) AddAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return (true, "Hesap başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }

        public (bool Success, string Message) UpdateAccount(Account account)
        {
            try
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return (true, "Hesap güncellendi.");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }

        public (bool Success, string Message) DeleteAccount(int id)
        {
            try
            {
                var account = _context.Accounts.Find(id);
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                    _context.SaveChanges();
                    return (true, "Hesap silindi.");
                }
                return (false, "Hesap bulunamadı.");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }
    }
}
