using System;

namespace SmartAccount.Core.Entities
{
    public class Debt : BaseEntity
    {
        public string Type { get; set; } = "Receivable"; // Receivable (Alacak) or Payable (Verecek)
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Paid, Overdue

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
