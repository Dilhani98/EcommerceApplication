using Ecommerce.APi.Search.Interface;

namespace Ecommerce.APi.Search.Service
{
    public class SearchService : ISearchInterface
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        public SearchService(IOrderService orderService, IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId)
        {
            var orderresult = await orderService.GetOrderAsync(customerId);
            var productresult =  await productService.GetProductAsync(customerId);
            if (orderresult.IsSuccess)
            {
                foreach (var order in orderresult.Oreders)
                {
                    foreach (var item in order.OrderItem)
                    {
                        item.ProductName = productresult.IsSuccess ?
                            productresult.product.FirstOrDefault(p => p.Id == item.Id)?.Name :
                            "Product information not available";
                    }
                }
                var result = new
                {
                    orders = orderresult.Oreders
                };
                return(true, result);
            }
            return(false, null);
        }
    }
}
