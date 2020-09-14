using demok.Domain.Entities;
using demok.Domain.Repositories;
using demok.InfraStructure.Data.Context;

namespace demok.InfraStructure.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        { }
    }
}
