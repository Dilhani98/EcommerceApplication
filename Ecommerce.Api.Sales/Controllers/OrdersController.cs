using Ecommerce.Api.Sales.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Sales.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderProvide orderProvide;

        public OrdersController(IOrderProvide orderProvide)
        {
            this.orderProvide = orderProvide;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderAsync()
        {
            var result = await orderProvide.getOrderAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Item2);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var result = await orderProvide.getOrderAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.order);
            }

            return NotFound();
        }
    }
}

