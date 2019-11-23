using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quickstart.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        ValueTask RemoveById(int id);
        ValueTask<T> GetById(int id);
        Task<T> GetById(int id, bool hasTracking = false);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> predicate, bool hasTracking = false);
        Task<IEnumerable<T>> GetAll(bool hasTracking = false);
        Task<int> CountAll();
    }
}
