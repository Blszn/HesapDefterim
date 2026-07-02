using System;
using System.Collections.Generic;

namespace SmartAccount.Core.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Type { get; set; } = "Sales"; // Sales, Purchase
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Draft"; // Draft, Sent, Paid, Cancelled
        public decimal TotalAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }

    public class InvoiceItem : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TotalPrice { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
        
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
