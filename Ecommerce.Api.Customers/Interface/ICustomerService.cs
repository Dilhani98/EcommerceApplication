using Ecommerce.Api.Customers.Db;
using Ecommerce.Api.Customers.Models;

namespace Ecommerce.Api.Customers.Interface
{
    public interface ICustomerService
    {
        Task<(bool IsSuccess, IEnumerable<Customer> Customers, string ErrorMessage)> GetCustomerAsync();
        Task<(bool IsSuccess, Customer customer,  string ErrorMessage)> GetCustomerAsync(int id);


    }
}
