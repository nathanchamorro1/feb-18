using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories;

public interface IEventRepository
{
    List<Event> GetAll();
    Event? GetById(Guid id);
    Event Add(Event ev);
}
