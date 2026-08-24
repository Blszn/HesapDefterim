using System;

namespace SmartAccount.Core.Entities
{
    public class Log : BaseEntity
    {
        public string Action { get; set; } = string.Empty;
        public string? Details { get; set; }
        public string? Username { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
