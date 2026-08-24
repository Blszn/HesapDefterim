using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace SmartAccount.Business.Services
{
    public class FinanceService
    {
        private readonly SmartAccountDbContext _context;

        public FinanceService(SmartAccountDbContext context)
        {
            _context = context;
        }

        #region Categories
        public List<Category> GetCategories(string? type = null)
        {
            var query = _context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(c => c.Type == type);
            }
            return query.OrderBy(c => c.Name).ToList();
        }

        public (bool Success, string Message) AddCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                return (false, "Kategori adı boş olamaz.");

            _context.Categories.Add(category);
            _context.SaveChanges();
            return (true, "Kategori başarıyla eklendi.");
        }
        
        public void EnsureDefaultCategoriesExist()
        {
            if (!_context.Categories.Any())
            {
                var defaults = new List<Category>
                {
                    new Category { Name = "Ürün Satışı", Type = "Income" },
                    new Category { Name = "Hizmet Geliri", Type = "Income" },
                    new Category { Name = "Kira Geliri", Type = "Income" },
                    new Category { Name = "Personel Maaşları", Type = "Expense" },
                    new Category { Name = "Kira", Type = "Expense" },
                    new Category { Name = "Fatura (Elektrik-Su-İnternet)", Type = "Expense" },
                    new Category { Name = "Malzeme Alımı", Type = "Expense" },
                    new Category { Name = "Vergiler", Type = "Expense" }
                };
                _context.Categories.AddRange(defaults);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Transactions (Gelir/Gider)
        public List<Transaction> GetTransactions(DateTime? startDate = null, DateTime? endDate = null, string? type = null)
        {
            var query = _context.Transactions
                .Include(t => t.Category)
                .Include(t => t.Customer)
                .AsQueryable();

            if (startDate.HasValue)
                query = query.Where(t => t.Date.Date >= startDate.Value.Date);
            
            if (endDate.HasValue)
                query = query.Where(t => t.Date.Date <= endDate.Value.Date);

            if (!string.IsNullOrEmpty(type))
                query = query.Where(t => t.Type == type);

            return query.OrderByDescending(t => t.Date).ToList();
        }

        public (bool Success, string Message) AddTransaction(Transaction transaction)
        {
            if (transaction.Amount <= 0)
                return (false, "Tutar 0'dan büyük olmalıdır.");
            
            if (transaction.CategoryId == null || transaction.CategoryId == 0)
                return (false, "Lütfen bir kategori seçiniz.");

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return (true, "İşlem başarıyla eklendi.");
        }

        public Transaction GetTransactionById(int id)
        {
            return _context.Transactions.FirstOrDefault(t => t.Id == id);
        }

        public (bool Success, string Message) UpdateTransaction(Transaction transaction)
        {
            if (transaction.Amount <= 0)
                return (false, "Tutar 0'dan büyük olmalıdır.");
            
            if (transaction.CategoryId == null || transaction.CategoryId == 0)
                return (false, "Lütfen bir kategori seçiniz.");

            _context.Transactions.Update(transaction);
            _context.SaveChanges();
            return (true, "İşlem başarıyla güncellendi.");
        }

        public (bool Success, string Message) DeleteTransaction(int id)
        {
            var tx = _context.Transactions.FirstOrDefault(t => t.Id == id);
            if (tx == null) return (false, "İşlem bulunamadı.");

            _context.Transactions.Remove(tx);
            _context.SaveChanges();
            return (true, "İşlem başarıyla silindi.");
        }
        #endregion

        #region Debts (Alacak/Verecek)
        public List<Debt> GetDebts(string? type = null, string? status = null)
        {
            var query = _context.Debts.Include(d => d.Customer).AsQueryable();

            if (!string.IsNullOrEmpty(type))
                query = query.Where(d => d.Type == type);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(d => d.Status == status);

            return query.OrderBy(d => d.DueDate).ToList();
        }

        public (bool Success, string Message) AddDebt(Debt debt)
        {
            if (debt.Amount <= 0)
                return (false, "Tutar 0'dan büyük olmalıdır.");

            _context.Debts.Add(debt);
            _context.SaveChanges();
            return (true, "Kayıt başarıyla eklendi.");
        }
        
        public (bool Success, string Message) MarkDebtAsPaid(int id)
        {
            var debt = _context.Debts.FirstOrDefault(d => d.Id == id);
            if (debt == null) return (false, "Kayıt bulunamadı.");

            debt.Status = "Paid";
            _context.SaveChanges();
            return (true, "Ödendi olarak işaretlendi.");
        }
        #endregion
    }
}

