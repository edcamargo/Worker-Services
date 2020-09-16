using demok.Domain.Entities;
using demok.Domain.Repositories;
using demok.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace demok.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ILogger<CustomerService> logger, ICustomerRepository customerRepository) : base(customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public void ExecuteWork()
        {
            var _customers = _customerRepository.GetAll().Where(x => x.DateIntegration == null).ToList();

            foreach (var item in _customers)
            {
                var _customer = _customerRepository.GetById(item.Id);

                if (_customer != null)
                {
                    //_customer.UpdateCustomer(item.Name, item.Email, item.Salary * 1.99);

                    var result = _customer.EhValido();
                    if (!result.IsValid)
                        foreach (var error in result.Errors)
                            _logger.LogCritical("Worker Error include {name} - {salary} - {message}", _customer.Name, _customer.Salary, error.ErrorMessage);
                    else
                    {
                        _customer.ConfirmationIntegration();

                        _customerRepository.Update(_customer);
                        _logger.LogInformation("Worker Sucess updated customer {name} - {salary}", _customer.Name, _customer.Salary);
                    }
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
