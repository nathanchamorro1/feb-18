using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories;

public interface IRegistrationRepository
{
    bool EventExists(Guid eventId);
    bool UserExists(Guid userId);
    bool RegistrationExists(Guid eventId, Guid userId);
    int GetRegistrationCountForEvent(Guid eventId);
    int GetEventCapacity(Guid eventId);

    Registration Add(Registration registration);
}