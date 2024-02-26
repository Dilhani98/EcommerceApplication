using Ecommerce.APi.Search.Models;

namespace Ecommerce.APi.Search.Interface
{
    public interface IProductService
    {
        Task<(bool IsSuccess, IEnumerable<Product> product, string errorMessage)> GetProductAsync(int customerId);

    }
}
