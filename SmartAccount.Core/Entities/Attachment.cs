using System;

namespace SmartAccount.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public string EntityName { get; set; } = string.Empty; // e.g. Customer, Invoice
        public int EntityId { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
