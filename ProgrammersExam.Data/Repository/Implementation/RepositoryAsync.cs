using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammersExam.Data.Repository.Interface;

namespace ProgrammersExam.Data.Repository.Implementation
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public RepositoryAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }

        public Task AddAsync(T entity) => AddAsync(entity, new CancellationToken());

        public Task AddAsync(T entity, CancellationToken cancellationToken = default) => _dbSet.AddAsync(entity, cancellationToken);

        public Task AddAsync(params T[] entities) => _dbSet.AddRangeAsync(entities);

        public Task AddAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default) =>
            _dbSet.AddRangeAsync(entities, cancellationToken);

        public IEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return orderBy != null ? orderBy(query) : query;

        }

        public void UpdateAsync(T entity) => _dbSet.Update(entity);

    }
}
