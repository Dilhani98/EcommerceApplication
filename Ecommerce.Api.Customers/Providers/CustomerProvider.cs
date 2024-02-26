using AutoMapper;
using Ecommerce.Api.Customers.Db;
using Ecommerce.Api.Customers.Interface;
using Ecommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Customers.Providers
{
    public class CustomerProvider : ICustomerService
    {
        private readonly CustomerDbContext dbContexts;
        private readonly ILogger<CustomerProvider> logger;
        private readonly IMapper mapper;

        public CustomerProvider(CustomerDbContext dbContexts,
            ILogger<CustomerProvider> logger, IMapper mapper) {
            this.dbContexts = dbContexts;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContexts.Customers.Any())
            {
                dbContexts.Customers.Add(new DbCustomer()
                {
                    Id = 1,
                    CustomerName = "Niroshika",
                    Address = "galle"
                });

                dbContexts.Customers.Add(new DbCustomer()
                {
                    Id = 2,
                    CustomerName = "Dilhani",
                    Address = "galle"

                });

                dbContexts.SaveChanges();
            }
        }


        public async Task<(bool IsSuccess, IEnumerable<Customer> Customers, string ErrorMessage)> GetCustomerAsync()
        {
            try
            {
                var customers = await dbContexts.Customers.ToListAsync();

                if (customers != null && customers.Any())
                {
                    var result = mapper.Map<IEnumerable<DbCustomer>, IEnumerable<Models.Customer>>(customers);
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

        

        async Task<(bool IsSuccess, Customer customer, string ErrorMessage)> ICustomerService.GetCustomerAsync(int Id)
        {
            try
            {
                var customer = await dbContexts.Customers.FirstOrDefaultAsync(p => p.Id == Id);

                if (customer != null)
                {
                    var result = mapper.Map<Db.DbCustomer, Models.Customer>(customer);
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
