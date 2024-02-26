using Ecommerce.Api.Products.Models;

namespace Ecommerce.Api.Products.Interfaces
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Product> product, string ErrorMessage)> getProductAsync();
        Task<(bool IsSuccess, Product product, string ErrorMessage)> getProductAsync(int id);


    }
}
