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
                work.Description = " ";

            _context.Works.Add(work);
            _context.SaveChanges();
            return (true, "");
        }

        public (bool Success, string Message) UpdateWork(Work work)
        {
            if (string.IsNullOrWhiteSpace(work.Description))
                work.Description = " ";

            var existing = _context.Works.FirstOrDefault(w => w.Id == work.Id);
            if (existing == null) return (false, "");

            existing.Description = work.Description;
            existing.Notes = work.Notes;
            existing.Status = work.Status;
            existing.StartDate = work.StartDate;
            existing.EndDate = work.EndDate;
            existing.CustomerId = work.CustomerId;

            _context.SaveChanges();
            return (true, "");
        }
        
        public (bool Success, string Message) DeleteWork(int id)
        {
            var work = _context.Works.FirstOrDefault(w => w.Id == id);
            if (work == null) return (false, "");

            _context.Works.Remove(work);
            _context.SaveChanges();
            return (true, "");
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
                return (false, "");

            _context.Reminders.Add(reminder);
            _context.SaveChanges();
            return (true, "");
        }

        public (bool Success, string Message) MarkReminderAsRead(int id)
        {
            var rem = _context.Reminders.FirstOrDefault(r => r.Id == id);
            if (rem == null) return (false, "");

            rem.IsCompleted = true;
            _context.SaveChanges();
            return (true, "");
        }
        #endregion
    }
}

