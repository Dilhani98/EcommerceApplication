using Ecommerce.Api.Sales.Models;

namespace Ecommerce.Api.Sales.Interface
{
    public interface IOrderProvide
    {
        Task<(bool IsSuccess, IEnumerable<Order> order, string ErrorMessage)> getOrderAsync();

        Task<(bool IsSuccess, Order order, string ErrorMessage)> getOrderAsync(int id);
    }
}
