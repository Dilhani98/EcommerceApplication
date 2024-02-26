using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Ecommerce.Api.Customers.Db
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<DbCustomer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions options)  : base(options)
        {
        }

    }
}
