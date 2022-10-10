using Leonardo;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FibonacciController : ControllerBase
{

    [HttpPost("Compute")]
    public async Task<IList<long>> Run([FromServices] ILogger<FibonacciController> logger,
        [FromServices] Fibonacci fibonacci,
        string[] args)
    {
        logger.LogInformation("test");
        return await fibonacci.RunAsync(args); 
    }
    
}