using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SmartAccount.Business.Services
{
    public class ProductService
    {
        private readonly SmartAccountDbContext _context;

        public ProductService()
        {
            _context = new SmartAccountDbContext();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public (bool Success, string Message) AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }

        public (bool Success, string Message) UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }

        public (bool Success, string Message) DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return (true, "");
                }
                return (false, "");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }
    }
}

