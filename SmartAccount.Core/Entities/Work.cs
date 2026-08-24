using System;

namespace SmartAccount.Core.Entities
{
    public class Work : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Planned"; // Planned, InProgress, Completed
        public decimal? Amount { get; set; }
        public string? Notes { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
