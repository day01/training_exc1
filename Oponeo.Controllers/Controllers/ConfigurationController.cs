using Microsoft.AspNetCore.Mvc;

namespace Oponeo.Controllers.Controllers;

[ApiController]
[Route("/config")]
public class ConfigurationController : ControllerBase
{
    [HttpGet(template: "product-codes")]
    [ResponseCache(Duration = int.MaxValue, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] {"abc"},
        VaryByHeader = "xyz")]
    public ActionResult<List<string>> GetProductCodes([FromQuery] string abc, [FromHeader] string xyz)
    {
        var result = new[] {"Product-1", "Product-2", "Product-3"};

        return Ok(result);
    }
    
    [HttpGet(template: "product-groups")]
    [ResponseCache(Duration = int.MaxValue, Location = ResponseCacheLocation.Any)]
    public ActionResult<List<string>> GetProductGroup()
    {
        var result = new[] {"Product-1", "Product-2", "Product-3"};

        return Ok(result);
    }
    
    [HttpGet(template: "product-category")]
    [ResponseCache(Duration = int.MaxValue, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] {"abc"},
        VaryByHeader = "xyz")]
    public ActionResult<List<string>> GetProductCategory([FromQuery] string abc, [FromHeader] string xyz)
    {
        var result = new[] {"Product-1", "Product-2", "Product-3"};

        return Ok(result);
    }
}