using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SmartAccount.Business.Services
{
    public class EmployeeService
    {
        private readonly SmartAccountDbContext _context;

        public EmployeeService(SmartAccountDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployees(bool onlyActive = false)
        {
            var query = _context.Employees.AsQueryable();
            if (onlyActive)
            {
                query = query.Where(e => e.IsActive);
            }
            return query.OrderBy(e => e.Name).ToList();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public (bool Success, string Message) AddEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name) || string.IsNullOrWhiteSpace(employee.Surname))
                return (false, "");

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return (true, "");
        }

        public (bool Success, string Message) UpdateEmployee(Employee employee)
        {
            var existing = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing == null)
                return (false, "");

            existing.Name = employee.Name;
            existing.Surname = employee.Surname;
            existing.TcNo = employee.TcNo;
            existing.Phone = employee.Phone;
            existing.Position = employee.Position;
            existing.Salary = employee.Salary;
            existing.StartDate = employee.StartDate;
            existing.IsActive = employee.IsActive;

            _context.SaveChanges();
            return (true, "");
        }

        public (bool Success, string Message) DeleteEmployee(int id)
        {
            var existing = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return (false, "");

            _context.Employees.Remove(existing);
            _context.SaveChanges();
            return (true, "");
        }
    }
}

