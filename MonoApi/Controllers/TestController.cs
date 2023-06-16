using Microsoft.AspNetCore.Mvc;

namespace MonoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> GetTest()
    {
        return Ok("fuck yeah");
    }
}