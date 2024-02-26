using AutoMapper;
using Ecommerce.Api.Products.Db;
using Ecommerce.Api.Products.Interfaces;
using Ecommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Products.Providers
{
    public class ProductProvider : IProductsProvider
    { 
        private readonly ProductsDbContexts dbContexts;
        private readonly ILogger<ProductProvider> logger;
        private readonly IMapper mapper;
      public  ProductProvider(ProductsDbContexts dbContexts, ILogger<ProductProvider> logger, IMapper mapper)
        {
                  this.dbContexts = dbContexts;
                  this.logger = logger;
                  this.mapper = mapper;

            SeedData();


        }

        private void SeedData()
        {
            if (!dbContexts.Product.Any())
            {
                dbContexts.Product.Add(new Db.Product()
                {
                    Id = 1,
                    Name = "Test",
                    Price = "20",
                    Inventoey = "100",

                });
                     dbContexts.Product.Add(new Db.Product()
                     {
                         Id = 2,
                         Name = "Test2",
                         Price = "30",
                         Inventoey = "200",

                     }); 
                dbContexts.SaveChanges();

            }

        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> product, string ErrorMessage)> getProductAsync()
        {
            try
            {
                var products = await dbContexts.Product.ToListAsync();
                Console.WriteLine(products);
                if(products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);

                }

                return(false, null, "Not found");

            }catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, null,ex.Message);
                   
            }
        }

        public async Task<(bool IsSuccess, Models.Product product, string ErrorMessage)> getProductAsync(int id)
        {
            try
            {
                var products = await dbContexts.Product.FirstOrDefaultAsync(p => p.Id == id);

                if (products != null)
                {
                    var result = mapper.Map<Db.Product, Models.Product>(products);
                    return (true, result, null);

                }

                return (false, null, "Not found");

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);

            }
        }
    }
}
