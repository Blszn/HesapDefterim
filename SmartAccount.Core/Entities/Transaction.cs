using System;

namespace SmartAccount.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string Type { get; set; } = "Income"; // Income or Expense
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string PaymentMethod { get; set; } = "Nakit";

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public int? AccountId { get; set; }
        public Account? Account { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
