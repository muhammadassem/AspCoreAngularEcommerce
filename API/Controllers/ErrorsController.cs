using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [HttpGet("statusCode")]
    public  IActionResult Index(int statusCode) {
        return new ObjectResult(new ApiResponse(statusCode));
    }
}
