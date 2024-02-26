using Ecommerce.APi.Search.Interface;
using Ecommerce.APi.Search.Models;
using System.Text.Json;

namespace Ecommerce.APi.Search.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<OrderService> logger;
        public ProductService(IHttpClientFactory httpClientFactory, ILogger<OrderService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<Product> product, string errorMessage)> GetProductAsync(int customerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("ProductService");
                var response = await client.GetAsync("api/products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
