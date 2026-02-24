using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Event>> GetEvents()
    {
        var events = _eventService.GetEvents();
        return Ok(events);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Event> GetEventById(Guid id)
    {
        var ev = _eventService.GetEventById(id);
        if (ev is null)
        {
            return NotFound();
        }

        return Ok(ev);
    }

    [HttpPost]
    public ActionResult<Event> CreateEvent([FromBody] Event input)
    {
        if (string.IsNullOrWhiteSpace(input.Title))
        {
            return BadRequest("Title is required.");
        }

        if (input.EndDateTime <= input.StartDateTime)
        {
            return BadRequest("EndDateTime must be after StartDateTime.");
        }

        var created = _eventService.CreateEvent(input);
        return CreatedAtAction(nameof(GetEventById), new { id = created.Id }, created);
    }
}
