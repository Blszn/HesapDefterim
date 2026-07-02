using System;

namespace SmartAccount.Core.Entities
{
    public class Reminder : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = "Debt"; // Debt, Work, General
        public bool IsCompleted { get; set; } = false;
    }
}
