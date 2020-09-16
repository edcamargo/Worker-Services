using demok.InfraStructure.Data.Context;
using demok.InfraStructure.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace demok.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var connection = hostContext.Configuration.GetConnectionString("DefaultConnection");
                    var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                    //optionsBuilder.UseSqlServer(connection);

                    optionsBuilder.UseInMemoryDatabase(connection);
                    services.AddTransient<DataContext>(s => new DataContext(optionsBuilder.Options));

                    // Register Dependency Injection 
                    DependencyInjection.DependencyInjectionRepository(ref services);

                    services.AddHostedService<Worker>();
                });
    }
}
