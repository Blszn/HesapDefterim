using System;
using System.Collections.Generic;

namespace SmartAccount.Core.Entities
{
    public class Offer : BaseEntity
    {
        public string OfferNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Draft"; // Draft, Sent, Accepted, Rejected
        public decimal TotalAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<OfferItem> Items { get; set; } = new List<OfferItem>();
    }

    public class OfferItem : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TotalPrice { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; } = null!;
    }
}
