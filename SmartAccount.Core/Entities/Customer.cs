using System.Collections.Generic;

namespace SmartAccount.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string? MobilePhone { get; set; }
        public string? LandlinePhone { get; set; }
        public string? Address { get; set; }
        public string? TaxOffice { get; set; }
        public string? TaxNumber { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
        public ICollection<Work> Works { get; set; } = new List<Work>();
        public ICollection<Debt> Debts { get; set; } = new List<Debt>();
    }
}
