using AutoMapper;
using Ecommerce.Api.Products.Db;
using Ecommerce.Api.Products.Interfaces;
using Ecommerce.Api.Products.Profile;
using Ecommerce.Api.Products.Providers;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.ProductTest
{
    public class ProductServices
    {
        [Fact]
        public async Task GetProductsReturnAllProducts()
        {
            var options = new DbContextOptionsBuilder<ProductsDbContexts>().
                UseInMemoryDatabase(nameof(GetProductsReturnAllProducts))
                .Options;

             var dbContext = new ProductsDbContexts(options);
            

            CreateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile> { productProfile }));

            var mapper = new Mapper(configuration);
            var productsProvider = new ProductProvider(dbContext, null, mapper);
            var products = await productsProvider.getProductAsync();

            Assert.True(products.IsSuccess);
            Assert.True(products.product.Any());
            Assert.Null(products.ErrorMessage);



        }


        public void CreateProducts(ProductsDbContexts dbContexts)
        {
            for (int i = 20; i < 30; i++)
            {
                dbContexts.Product.Add(new Product
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    Inventoey = "10",
                    Price ="50"
                });
                dbContexts.SaveChanges();
                
            }
        }
    }



}