using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammersExam.Data.Service.Base.Interface;
using ProgrammersExam.Data.UnitOfWork.Interface;

namespace ProgrammersExam.Data.Service.Base
{
    public class Service<TEntity> : IBaseService<TEntity> where TEntity : Entities.Entity.Abstract.Base
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            return _unitOfWork.GetRepositoryAsync<TEntity>().GetAsync(predicate, orderBy, include, disableTracking);
        }
    }
}
