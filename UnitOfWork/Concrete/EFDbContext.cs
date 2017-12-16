using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Abstract;

namespace UnitOfWork.Concrete
{
    public class EFDbContext : DbContext, IEFDbContext
    {
        public EFDbContext() : base("name=PUM2")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Expenses> expenses { get; set; }
        public DbSet<Incomes> incomes { get; set; }
        public DbSet<Savings> savings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(x => x.IsUnicode(false));
            base.OnModelCreating(modelBuilder);
        }
    }
}
