using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Sales.Db
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
