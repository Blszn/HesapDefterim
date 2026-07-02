using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Customers.OrderBy(c => c.FullName).ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
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
            return _context.Customers
                .Where(c => c.FullName.ToLower().Contains(keyword) || 
                            (c.MobilePhone != null && c.MobilePhone.Contains(keyword)) ||
                            (c.TaxNumber != null && c.TaxNumber.Contains(keyword)))
                .OrderBy(c => c.FullName)
                .ToList();
        }
    }
}
