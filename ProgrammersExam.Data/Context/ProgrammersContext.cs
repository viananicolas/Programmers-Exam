using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammersExam.Entities.Entity;

namespace ProgrammersExam.Data.Context
{
    public class ProgrammersContext : DbContext
    {
        public ProgrammersContext()
            : base()
        {
        }
        public ProgrammersContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Play> Play { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<PerformanceOrder> PerformanceOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region PlaySeed
            //modelBuilder.Entity<Play>().HasData(new Play { Id = 1, Audience = 55, Category = Category.Tragedy, PlayName = "Hamlet" },
            //    new Play { Id = 2, Audience = 35, Category = Category.Comedy, PlayName = "As-Like" },
            //    new Play { Id = 3, Audience = 40, Category = Category.Tragedy, PlayName = "Othello" });
            #endregion
        }

        public override int SaveChanges()
        {
            SetModifiedInformation();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetModifiedInformation();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SetModifiedInformation()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                entityEntry.Property("RegisterDate").CurrentValue = DateTime.Now;
            }
        }
    }
}
