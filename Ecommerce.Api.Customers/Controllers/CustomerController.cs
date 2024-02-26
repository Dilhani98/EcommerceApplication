using Ecommerce.Api.Customers.Interface;
using Ecommerce.Api.Customers.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]

        public async Task<IActionResult> GetCustomerAsync()
        {
            var result = await customerService.GetCustomerAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customerService.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.customer);
            }

            return NotFound();
        }

    }
}
