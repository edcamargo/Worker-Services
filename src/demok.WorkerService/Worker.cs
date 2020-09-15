using System;
using System.Threading;
using System.Threading.Tasks;
using demok.Domain.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace demok.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly ICustomerRepository _customerRepository;

        public Worker(ILogger<Worker> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker service starting at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                var _customers = _customerRepository.GetAll();

                foreach (var item in _customers)
                {
                    var _customer = _customerRepository.GetById(item.Id);

                    if (_customer != null)
                    {
                        _customer.UpdateCustomer(_customer.Name, _customer.Name+"@gmail.com");

                        _customer.UpdateSalary(2.99);

                        var result = _customer.EhValido();
                        if (!result.IsValid)
                            foreach (var error in result.Errors)
                                _logger.LogInformation("Worker Error include {name} - {message}", _customer.Name, error.ErrorMessage);
                        else
                        {
                            _customerRepository.Update(_customer);
                            _logger.LogInformation("Worker Sucess updated customer {name}", _customer.Name);
                        }
                    }

                    await Task.Delay(3000, stoppingToken);
                }
            }
        }
    }
}
