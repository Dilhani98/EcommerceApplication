using Ecommerce.APi.Search.Interface;
using Ecommerce.APi.Search.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Search.Controllers;

[ApiController]
[Route("api/controller")]
public class SearchController : ControllerBase
{
    private readonly ISearchInterface searchInterface;

    public SearchController(ISearchInterface searchInterface)
    {
        this.searchInterface = searchInterface;
    }

    [HttpPost]

    public async Task<IActionResult> SearchAsync(SearchTerm term)
    {
        var result = await searchInterface.SearchAsync(term.CustomerId);

        if(result.IsSuccess)
        {
            return Ok(result.SearchResult);
        }

        return NotFound();
    }
    
}
