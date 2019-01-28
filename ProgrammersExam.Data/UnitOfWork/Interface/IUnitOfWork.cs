using System;
using Microsoft.EntityFrameworkCore;
using ProgrammersExam.Data.Repository.Interface;

namespace ProgrammersExam.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;
        int SaveChanges();
    }

    public interface IUnitOfWork<out TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}