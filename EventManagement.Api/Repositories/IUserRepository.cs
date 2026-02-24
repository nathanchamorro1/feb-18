using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories;

public interface IUserRepository
{
    List<User> GetAll();
    User? GetById(Guid id);
    User Add(User user);
}