using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
