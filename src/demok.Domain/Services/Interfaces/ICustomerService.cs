using demok.Domain.Entities;

namespace demok.Domain.Services.Interfaces
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        /// <summary>
        /// Executa a fila de customer
        /// </summary>
        void ExecuteWork();
    }
}
