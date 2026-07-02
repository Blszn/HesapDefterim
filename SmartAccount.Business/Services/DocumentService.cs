using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace SmartAccount.Business.Services
{
    public class DocumentService
    {
        private readonly SmartAccountDbContext _context;

        public DocumentService(SmartAccountDbContext context)
        {
            _context = context;
        }

        #region Invoices
        public List<Invoice> GetInvoices(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Invoices.Include(i => i.Customer).AsQueryable();

            if (startDate.HasValue)
                query = query.Where(i => i.Date.Date >= startDate.Value.Date);
            
            if (endDate.HasValue)
                query = query.Where(i => i.Date.Date <= endDate.Value.Date);

            return query.OrderByDescending(i => i.Date).ToList();
        }

        public (bool Success, string Message) AddInvoice(Invoice invoice)
        {
            if (string.IsNullOrWhiteSpace(invoice.InvoiceNumber))
                return (false, "Fatura numarası boş olamaz.");
                
            if (invoice.TotalAmount <= 0)
                return (false, "Tutar 0'dan büyük olmalıdır.");

            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return (true, "Fatura başarıyla eklendi.");
        }

        public (bool Success, string Message) UpdateInvoiceStatus(int id, string status)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return (false, "Fatura bulunamadı.");

            invoice.Status = status;
            _context.SaveChanges();
            return (true, "Fatura durumu güncellendi.");
        }
        
        public (bool Success, string Message) DeleteInvoice(int id)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return (false, "Fatura bulunamadı.");

            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
            return (true, "Fatura başarıyla silindi.");
        }
        #endregion

        #region Offers
        public List<Offer> GetOffers(DateTime? startDate = null, DateTime? endDate = null, string? status = null)
        {
            var query = _context.Offers.Include(o => o.Customer).AsQueryable();

            if (startDate.HasValue)
                query = query.Where(o => o.Date.Date >= startDate.Value.Date);
            
            if (endDate.HasValue)
                query = query.Where(o => o.Date.Date <= endDate.Value.Date);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(o => o.Status == status);

            return query.OrderByDescending(o => o.Date).ToList();
        }

        public (bool Success, string Message) AddOffer(Offer offer)
        {
            if (offer.TotalAmount <= 0)
                return (false, "Tutar 0'dan büyük olmalıdır.");

            _context.Offers.Add(offer);
            _context.SaveChanges();
            return (true, "Teklif başarıyla eklendi.");
        }

        public (bool Success, string Message) UpdateOfferStatus(int id, string status)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.Id == id);
            if (offer == null) return (false, "Teklif bulunamadı.");

            offer.Status = status;
            _context.SaveChanges();
            return (true, "Teklif durumu güncellendi.");
        }

        public (bool Success, string Message) DeleteOffer(int id)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.Id == id);
            if (offer == null) return (false, "Teklif bulunamadı.");

            _context.Offers.Remove(offer);
            _context.SaveChanges();
            return (true, "Teklif başarıyla silindi.");
        }
        #endregion
    }
}
