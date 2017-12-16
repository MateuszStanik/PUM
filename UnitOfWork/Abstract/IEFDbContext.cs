using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Abstract
{
    public interface IEFDbContext : IDisposable
    {
        DbSet<Expenses> expenses { get; set; }
        DbSet<Incomes> incomes { get; set; }
        DbSet<Savings> savings { get; set; }
    }
}
