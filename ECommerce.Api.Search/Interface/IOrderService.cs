using Ecommerce.APi.Search.Models;

namespace Ecommerce.APi.Search.Interface
{
    public interface IOrderService
    {
        Task<(bool IsSuccess, IEnumerable<Order> Oreders, string ErrorMeassage)> GetOrderAsync(int customerId);
    }
}
