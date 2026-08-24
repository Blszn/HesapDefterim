using System;
using System.Collections.Generic;

namespace SmartAccount.Core.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "Cash"; // Cash or Bank
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "TRY";
        
        // For Bank
        public string? BankName { get; set; }
        public string? IBAN { get; set; }
        
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
