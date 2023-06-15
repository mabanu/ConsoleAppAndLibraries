using Microsoft.AspNetCore.Mvc;

namespace TestLibrary.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetLibrary()
    {
        return Ok("library");
    }

}