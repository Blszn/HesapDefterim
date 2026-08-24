using System;

namespace SmartAccount.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string TcNo { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; } = true;
        
        public string FullName => $"{Name} {Surname}";
    }
}
