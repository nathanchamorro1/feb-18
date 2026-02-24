using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<User> GetUserById(Guid id)
    {
        var user = _userService.GetUserById(id);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User input)
    {
        if (string.IsNullOrWhiteSpace(input.FirstName))
            return BadRequest("First name is required.");

        if (string.IsNullOrWhiteSpace(input.LastName))
            return BadRequest("Last name is required.");

        if (string.IsNullOrWhiteSpace(input.Email))
            return BadRequest("Email is required.");

        var created = _userService.CreateUser(input);
        return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, created);
    }
}