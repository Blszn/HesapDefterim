using Microsoft.EntityFrameworkCore;
using SmartAccount.Core.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartAccount.Core.Data
{
    public class SmartAccountDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<OfferItem> OfferItems { get; set; } = null!;
        public DbSet<Work> Works { get; set; } = null!;
        public DbSet<Debt> Debts { get; set; } = null!;
        public DbSet<Reminder> Reminders { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Attachment> Attachments { get; set; } = null!;
        public DbSet<Setting> Settings { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlite("Data Source=SmartAccount.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global Query Filter for Soft Delete
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Customer>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Transaction>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Invoice>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<InvoiceItem>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Offer>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<OfferItem>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Work>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Debt>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Reminder>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Log>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Account>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Attachment>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Setting>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDeleted);
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
        }
    }
}
