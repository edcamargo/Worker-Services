using Microsoft.Extensions.DependencyInjection;

namespace demok.InfraStructure.Ioc
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionServices(ref IServiceCollection services)
        {
            // services.AddTransient<ICustomerService, CustomerService>();
        }

        public static void DependencyInjectionRepository(ref IServiceCollection services)
        {
            // services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
