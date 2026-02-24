using EventManagement.Api.Data;
using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories;

public class RegistrationRepository : IRegistrationRepository
{
    private readonly ApplicationDbContext _context;

    public RegistrationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool EventExists(Guid eventId)
    {
        return _context.Events.Any(e => e.Id == eventId);
    }

    public bool UserExists(Guid userId)
    {
        return _context.Users.Any(u => u.Id == userId);
    }

    public bool RegistrationExists(Guid eventId, Guid userId)
    {
        return _context.Registrations.Any(r => r.EventId == eventId && r.UserId == userId);
    }

    public int GetRegistrationCountForEvent(Guid eventId)
    {
        return _context.Registrations.Count(r => r.EventId == eventId);
    }

    public int GetEventCapacity(Guid eventId)
    {
        return _context.Events.Where(e => e.Id == eventId).Select(e => e.Capacity).First();
    }

    public Registration Add(Registration registration)
    {
        _context.Registrations.Add(registration);
        _context.SaveChanges();
        return registration;
    }
}