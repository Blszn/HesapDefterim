using System;

namespace SmartAccount.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
