using EventManagement.Api.Models;
using EventManagement.Api.Repositories;

namespace EventManagement.Api.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IRegistrationRepository _registrationRepository;

    public RegistrationService(IRegistrationRepository registrationRepository)
    {
        _registrationRepository = registrationRepository;
    }

    public Registration CreateRegistration(Guid eventId, Guid userId)
    {
        if (!_registrationRepository.EventExists(eventId))
            throw new KeyNotFoundException("Event not found.");

        if (!_registrationRepository.UserExists(userId))
            throw new KeyNotFoundException("User not found.");

        if (_registrationRepository.RegistrationExists(eventId, userId))
            throw new ArgumentException("User is already registered for this event.");

        var capacity = _registrationRepository.GetEventCapacity(eventId);
        if (capacity > 0)
        {
            var currentCount = _registrationRepository.GetRegistrationCountForEvent(eventId);
            if (currentCount >= capacity)
                throw new ArgumentException("Event is at capacity.");
        }

        var registration = new Registration
        {
            Id = Guid.NewGuid(),
            EventId = eventId,
            UserId = userId,
            RegisteredAt = DateTime.UtcNow,
            Status = "Registered"
        };

        return _registrationRepository.Add(registration);
    }
}