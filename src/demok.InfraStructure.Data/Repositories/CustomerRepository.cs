using demok.Domain.Entities;
using demok.Domain.Repositories;
using demok.InfraStructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demok.InfraStructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Customer customer)
        {
            _dataContext.Customer.Add(customer);
            _dataContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _dataContext.Entry(customer).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _dataContext.Customer.Remove(customer);
            _dataContext.SaveChanges();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _dataContext.Customer.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dataContext.Customer.AsNoTracking().OrderBy(x => x.Name);
        }
    }
}
