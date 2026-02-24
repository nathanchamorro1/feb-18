using EventManagement.Api.Models;

namespace EventManagement.Api.Services;

public interface IRegistrationService
{
    Registration CreateRegistration(Guid eventId, Guid userId);
}