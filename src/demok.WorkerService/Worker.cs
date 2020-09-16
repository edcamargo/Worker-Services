using System;
using System.Threading;
using System.Threading.Tasks;
using demok.Domain.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace demok.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly ICustomerService _customerService;

        public Worker(ILogger<Worker> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker service starting at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                _customerService.ExecuteWork();

                _logger.LogInformation("Worker service delay at: {time}", DateTimeOffset.Now);
                await Task.Delay(9000, stoppingToken);
            }
        }
    }
}
