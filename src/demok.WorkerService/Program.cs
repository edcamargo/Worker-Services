using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demok.InfraStructure.Ioc;
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
                    // Register Dependency Injection 
                    DependencyInjection.DependencyInjectionRepository(ref services);
                    DependencyInjection.DependencyInjectionServices(ref services);

                    services.AddHostedService<Worker>();
                });
    }
}
