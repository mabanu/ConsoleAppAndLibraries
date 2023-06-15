using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestLibrary.Model;
using TestLibrary.Repositories;

namespace TestLibrary.Controllers;

[ApiController]
[Route("[controller]")]
public class TestLibraryController : ControllerBase
{
    private readonly ITestRepository _testRepository;

    public TestLibraryController(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TestDtoGuidProblem>>> GetTest()
    {
        return Ok(await _testRepository.Get());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TestDtoGuidProblem>> GetTest([FromRoute]string id)
    {
        return Ok(await _testRepository.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<Test>> Post([FromBody] Test test)
    {
         await _testRepository.CreateTest(test);

         return CreatedAtAction("GetTest", new { id = test.ID }, test);
    }
}