using demok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace demok.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Customer GetCustomerById(Guid id);
        IEnumerable<Customer> GetCustomers();
    }
}
