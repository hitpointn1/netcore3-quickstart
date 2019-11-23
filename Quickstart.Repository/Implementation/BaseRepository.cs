using Microsoft.EntityFrameworkCore;
using Quickstart.Repository.Context;
using Quickstart.Repository.Entities;
using Quickstart.Repository.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quickstart.Repository.Implementation
{

    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationContext Context { get; }

        public BaseRepository(ApplicationContext context)
        {
            Context = context;
        }  

        public void Add(T entity)
        {
            Context.Set<T>()
                .Add(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>()
                .Update(entity);
        }
        
        public void Remove(T entity)
        {
            Context.Set<T>()
                .Remove(entity);
        }

        public async ValueTask RemoveById(int id)
        {
            T model = await GetById(id);
            if (model != null)
                Context.Set<T>()
                    .Remove(model);
        }

        public ValueTask<T> GetById(int id) =>
            Context.Set<T>()
                .FindAsync(id);

        public Task<T> GetById(int id, bool hasTracking = false) =>
            Context.Set<T>()
                .AsNoTracking(hasTracking)
                .FirstOrDefaultAsync(entity => entity.ID == id);

        public Task<int> CountAll() =>
            Context.Set<T>()
                .CountAsync();

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> predicate, bool hasTracking = false) =>
            await Context.Set<T>()
                .Where(predicate)
                .AsNoTracking(hasTracking)
                .ToArrayAsync();

        public async Task<IEnumerable<T>> GetAll(bool hasTracking = false) =>
            await Context.Set<T>()
                .AsNoTracking(hasTracking)
                .ToArrayAsync();
    }
}
