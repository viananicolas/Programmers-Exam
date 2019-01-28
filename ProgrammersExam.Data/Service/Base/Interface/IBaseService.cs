using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace ProgrammersExam.Data.Service.Base.Interface
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : Entities.Entity.Abstract.Base
    {
        Task<TEntity> Add(TEntity entity);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);
    }
}
