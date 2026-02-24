using EventManagement.Api.Models;
using EventManagement.Api.Repositories;

namespace EventManagement.Api.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public IEnumerable<Event> GetEvents()
    {
        return _eventRepository.GetAll();
    }

    public Event? GetEventById(Guid id)
    {
        return _eventRepository.GetById(id);
    }

    public Event CreateEvent(Event request)
    {
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            StartDateTime = request.StartDateTime,
            EndDateTime = request.EndDateTime,
            Location = request.Location,
            Capacity = request.Capacity
        };

        return _eventRepository.Add(ev);
    }
}
