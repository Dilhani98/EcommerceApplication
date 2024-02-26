using Ecommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Products.Controllers

{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;

        public ProductController(IProductsProvider productsProvider) {
            this.productsProvider = productsProvider;
        }
        [HttpGet]
       public async Task<IActionResult> GetProductAsync()
        {
           var result =await productsProvider.getProductAsync();
            if(result.IsSuccess)
            {
                return Ok(result.Item2);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productsProvider.getProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.product);
            }

            return NotFound();
        }
    }
}

