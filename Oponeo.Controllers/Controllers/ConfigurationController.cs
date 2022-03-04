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
    
    [HttpGet("example/async-test")]
    public async Task<string[]> GetExampleCall([FromQuery] string abc, [FromHeader] string xyz)
    {
        var taskOfLongRunningFunc = privateLongRunningFunc();
        var task2 = privateLongRunningFunc();
        
        foreach (var i in new [] {1,3,4,5})
        {
            
        }
        
        var result = await taskOfLongRunningFunc;

        return result.Take(2).ToArray();
    }

    private async Task<string[]> privateLongRunningFunc()
    {
        var result = new[] {"Product-1", "Product-2", "Product-3"};

        await Task.Delay(100000000);

        return result;
    }
}