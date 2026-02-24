using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationsController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost("events/{id:guid}/registrations")]
    public ActionResult<Registration> CreateRegistration(Guid id, [FromBody] CreateRegistrationRequest input)
    {
        if (input.UserId == Guid.Empty)
            return BadRequest("UserId is required.");

        try
        {
            var created = _registrationService.CreateRegistration(id, input.UserId);
            return StatusCode(201, created);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}