using EventManagement.Api.Models;

namespace EventManagement.Api.Services;

public interface IUserService
{
    IEnumerable<User> GetUsers();
    User? GetUserById(Guid id);
    User CreateUser(User request);
}