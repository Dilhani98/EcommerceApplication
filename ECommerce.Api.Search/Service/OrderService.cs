using Ecommerce.APi.Search.Interface;
using Ecommerce.APi.Search.Models;
using System.Text.Json;

namespace Ecommerce.APi.Search.Service
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<OrderService> logger;

        public OrderService(IHttpClientFactory httpClientFactory, ILogger<OrderService> logger) {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<Order> Oreders, string ErrorMeassage)> GetOrderAsync(int customerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("OrderService");
                var response =  await client.GetAsync("api/orders");
                if(response.IsSuccessStatusCode)
                {
                    try
                    {
                        var content = await response.Content.ReadAsByteArrayAsync();
                        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                        var result = JsonSerializer.Deserialize<IEnumerable<Order>>(content, options);
                        return (true, result, null);

                        
                    }
                    catch (JsonException ex)
                    {
                        // Log the exception or handle it appropriately
                        return (false, null, ex.Message);
                    }

                }
                return (false, null, response.ReasonPhrase);

            }catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return(false, null, ex.Message);
            }
        }
    }
}
