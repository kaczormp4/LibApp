using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class CustomerRepository : InterfaceCustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType);
        }

        public Customer Get(int id) => _context.Customers.Find(id);

        public void Add(Customer item) => _context.Customers.Add(item);

        public void Remove(int id) => _context.Customers.Remove(Get(id));

        public void Update(Customer item) => _context.Customers.Update(item);
        public void Save() => _context.SaveChanges();
    }
}
