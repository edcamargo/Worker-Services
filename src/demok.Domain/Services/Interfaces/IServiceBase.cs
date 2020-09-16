using System.Collections.Generic;

namespace demok.Domain.Services.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
    }
}
