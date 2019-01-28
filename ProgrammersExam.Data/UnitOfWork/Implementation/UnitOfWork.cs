using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgrammersExam.Data.Repository.Implementation;
using ProgrammersExam.Data.Repository.Interface;
using ProgrammersExam.Data.UnitOfWork.Interface;

namespace ProgrammersExam.Data.UnitOfWork.Implementation
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>
        where TContext : DbContext
    {
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(TContext context) => Context = context ?? throw new ArgumentNullException(nameof(context));

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryAsync<TEntity>(Context);
            return (IRepositoryAsync<TEntity>)_repositories[type];
        }

        public TContext Context { get; }

        public int SaveChanges() => Context.SaveChanges();

        public void Dispose() => Context?.Dispose();
    }

}