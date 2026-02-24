using EventManagement.Api.Models;

namespace EventManagement.Api.Services;

public interface IEventService
{
    IEnumerable<Event> GetEvents();
    Event? GetEventById(Guid id);
    Event CreateEvent(Event request);
}
