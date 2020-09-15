using demok.Domain.Repositories;
using demok.InfraStructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace demok.InfraStructure.Ioc
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionRepository(ref IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
