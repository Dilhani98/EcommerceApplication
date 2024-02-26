using AutoMapper;
using Ecommerce.Api.Sales.Db;
using Ecommerce.Api.Sales.Interface;
using Ecommerce.Api.Sales.Models;
using Microsoft.EntityFrameworkCore;
using NHibernate.Mapping;

namespace Ecommerce.Api.Sales.Provider
{
    public class Orderprovider : IOrderProvide

    {
        private readonly OrderDbContext dbContexts;
        private readonly ILogger<Orderprovider> logger;
        private readonly IMapper mapper;

        public Orderprovider(OrderDbContext dbContexts, ILogger<Orderprovider> logger, IMapper mapper) {
            this.dbContexts = dbContexts;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }


        private void SeedData()
        {
            if (!dbContexts.Order.Any())
            {
                var orderItem = new Db.OrderItem()
                {
                    Id = 1,
                    OrderID = 1,
                    ProductID = 101,
                    Quantity = 2,
                    UnitPrice = 25
                };
                var order = new Db.Order()
                {
                    Id = 1,
                    CustomerID = 2,
                    OrderDate = DateTime.Now,
                    Total = 100, // Assuming total amount is 100
                    OrderItem = new List<Db.OrderItem>()
                };

               

                 order.OrderItem.Add(orderItem); // Add the order item to the order's list of order items

                dbContexts.Order.Add(order); // Add the order to the Order DbSet

                dbContexts.SaveChanges();
            }
        }




        public async Task<(bool IsSuccess, Models.Order order, string ErrorMessage)> getOrderAsync(int id)
        {
            try
            {
                var result1 = await dbContexts.Order.FirstOrDefaultAsync(p => p.CustomerID == id);

                if (result1 != null)
                {
                    var result = mapper.Map<Db.Order, Models.Order>(result1);
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

        public async Task<(bool IsSuccess, IEnumerable<Models.Order> order, string ErrorMessage)> getOrderAsync()
        {
            try { 
            var products = await dbContexts.Order.ToListAsync();
            Console.WriteLine(products);
            if (products != null && products.Any())
            {
                var result = mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>>(products);
                return (true, result, null);

            }

            return (false, null, "Not found");

        }catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, null,ex.Message);
                   
            }
}
    }
}
