using demok.InfraStructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demok.Domain.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;
        //protected DataContext _dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TEntity Add(TEntity obj)
        {
            _dataContext.Set<TEntity>().Add(obj);
            _dataContext.SaveChanges();

            return obj;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(object id)
        {
            _dataContext.Set<TEntity>().AsNoTracking();
            return _dataContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _dataContext.Set<TEntity>().Remove(obj);
            _dataContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _dataContext.Entry(obj).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
