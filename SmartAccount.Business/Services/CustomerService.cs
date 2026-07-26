using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace SmartAccount.Business.Services
{
    public class CustomerService
    {
        private readonly SmartAccountDbContext _context;

        public CustomerService(SmartAccountDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = _context.Customers
                .Include(c => c.Transactions)
                .Include(c => c.Debts)
                .OrderBy(c => c.FullName)
                .ToList();

            foreach (var c in customers)
            {
                CalculateBalance(c);
            }
            return customers;
        }

        public Customer? GetCustomerById(int id)
        {
            var customer = _context.Customers
                .Include(c => c.Transactions)
                .Include(c => c.Debts)
                .FirstOrDefault(c => c.Id == id);
                
            if (customer != null) CalculateBalance(customer);
            return customer;
        }
        
        private void CalculateBalance(Customer c)
        {
            decimal totalReceivables = c.Debts.Where(d => d.Type == "Receivable").Sum(d => d.Amount);
            decimal totalPayables = c.Debts.Where(d => d.Type == "Payable").Sum(d => d.Amount);
            
            decimal totalIncomes = c.Transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal totalExpenses = c.Transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);

            // Bakiye = (Alacaklar + Yapılan Ödemeler/Giderler) - (Borçlar + Alınan Ödemeler/Gelirler)
            c.Balance = (totalReceivables + totalExpenses) - (totalPayables + totalIncomes);
        }

        public (bool Success, string Message) AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                return (false, "Müşteri adı boş olamaz.");
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return (true, "Müşteri başarıyla eklendi.");
        }

        public (bool Success, string Message) UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer == null)
            {
                return (false, "Müşteri bulunamadı.");
            }

            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                return (false, "Müşteri adı boş olamaz.");
            }

            existingCustomer.FullName = customer.FullName;
            existingCustomer.MobilePhone = customer.MobilePhone;
            existingCustomer.LandlinePhone = customer.LandlinePhone;
            existingCustomer.Address = customer.Address;
            existingCustomer.TaxOffice = customer.TaxOffice;
            existingCustomer.TaxNumber = customer.TaxNumber;
            existingCustomer.Email = customer.Email;
            existingCustomer.Notes = customer.Notes;

            _context.SaveChanges();
            return (true, "Müşteri başarıyla güncellendi.");
        }

        public (bool Success, string Message) DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return (false, "Müşteri bulunamadı.");
            }

            _context.Customers.Remove(customer); // Entity Framework will handle soft delete via DbContext configuration
            _context.SaveChanges();
            return (true, "Müşteri başarıyla silindi.");
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllCustomers();
            }

            keyword = keyword.ToLower();
            var customers = _context.Customers
                .Include(c => c.Transactions)
                .Include(c => c.Debts)
                .Where(c => c.FullName.ToLower().Contains(keyword) || 
                            (c.MobilePhone != null && c.MobilePhone.Contains(keyword)) ||
                            (c.TaxNumber != null && c.TaxNumber.Contains(keyword)))
                .OrderBy(c => c.FullName)
                .ToList();
                
            foreach (var c in customers)
            {
                CalculateBalance(c);
            }
            return customers;
        }
    }
}
