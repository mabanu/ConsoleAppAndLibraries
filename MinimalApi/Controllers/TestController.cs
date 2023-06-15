using Microsoft.AspNetCore.Mvc;

namespace MinimalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> GetTest()
    {
        return  Ok("fuck yeah");
    }
}