using System.Collections.Generic;

namespace SmartAccount.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "Income"; // Income or Expense

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
