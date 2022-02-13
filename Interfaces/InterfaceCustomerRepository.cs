using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface InterfaceCustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer Get(int id);
        void Add(Customer item);
        void Remove(int id);
        void Update(Customer item);
        void Save();

    }
}
