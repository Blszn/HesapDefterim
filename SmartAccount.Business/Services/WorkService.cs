using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace SmartAccount.Business.Services
{
    public class WorkService
    {
        private readonly SmartAccountDbContext _context;

        public WorkService(SmartAccountDbContext context)
        {
            _context = context;
        }

        #region Works
        public List<Work> GetWorks(string? status = null, int? customerId = null)
        {
            var query = _context.Works.Include(w => w.Customer).AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(w => w.Status == status);

            if (customerId.HasValue && customerId.Value > 0)
                query = query.Where(w => w.CustomerId == customerId.Value);

            return query.OrderByDescending(w => w.StartDate).ToList();
        }

        public (bool Success, string Message) AddWork(Work work)
        {
            if (string.IsNullOrWhiteSpace(work.Description))
                return (false, "İş açıklaması/başlığı boş olamaz.");

            _context.Works.Add(work);
            _context.SaveChanges();
            return (true, "İş/Görev başarıyla eklendi.");
        }

        public (bool Success, string Message) UpdateWork(Work work)
        {
            if (string.IsNullOrWhiteSpace(work.Description))
                return (false, "İş açıklaması/başlığı boş olamaz.");

            var existing = _context.Works.FirstOrDefault(w => w.Id == work.Id);
            if (existing == null) return (false, "Kayıt bulunamadı.");

            existing.Description = work.Description;
            existing.Notes = work.Notes;
            existing.Status = work.Status;
            existing.StartDate = work.StartDate;
            existing.EndDate = work.EndDate;
            existing.CustomerId = work.CustomerId;

            _context.SaveChanges();
            return (true, "İş/Görev başarıyla güncellendi.");
        }
        
        public (bool Success, string Message) DeleteWork(int id)
        {
            var work = _context.Works.FirstOrDefault(w => w.Id == id);
            if (work == null) return (false, "İş bulunamadı.");

            _context.Works.Remove(work);
            _context.SaveChanges();
            return (true, "İş başarıyla silindi.");
        }
        #endregion

        #region Reminders
        public List<Reminder> GetActiveReminders()
        {
            // Yaklaşan ve tamamlanmamış hatırlatıcıları getirir (örn. önümüzdeki 7 gün)
            var today = DateTime.Now.Date;
            var nextWeek = today.AddDays(7);

            return _context.Reminders
                .Where(r => !r.IsCompleted && r.Date >= today && r.Date <= nextWeek)
                .OrderBy(r => r.Date)
                .ToList();
        }

        public (bool Success, string Message) AddReminder(Reminder reminder)
        {
            if (string.IsNullOrWhiteSpace(reminder.Description))
                return (false, "Hatırlatıcı açıklaması boş olamaz.");

            _context.Reminders.Add(reminder);
            _context.SaveChanges();
            return (true, "Hatırlatıcı başarıyla eklendi.");
        }

        public (bool Success, string Message) MarkReminderAsRead(int id)
        {
            var rem = _context.Reminders.FirstOrDefault(r => r.Id == id);
            if (rem == null) return (false, "Hatırlatıcı bulunamadı.");

            rem.IsCompleted = true;
            _context.SaveChanges();
            return (true, "Tamamlandı olarak işaretlendi.");
        }
        #endregion
    }
}
