using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Products.Db
{
    public class ProductsDbContexts : DbContext
    {
        public DbSet<Product> Product { get; set;}

        public ProductsDbContexts(DbContextOptions options) : base(options)
        {

        }
    }
}
