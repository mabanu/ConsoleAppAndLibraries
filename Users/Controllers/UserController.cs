using Microsoft.AspNetCore.Mvc;
using Users.Model;
using Users.Repositories;

namespace Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return Ok(await _userRepository.GetUsers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetTest([FromRoute] Guid id)
    {
        return Ok(await _userRepository.GetUserById(id));
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post([FromBody] User user)
    {
        await _userRepository.CreateUser(user);

        return CreatedAtAction("GetTest", new { id = user.ID }, user);
    }
}