using EventManagement.Api.Models;
using EventManagement.Api.Repositories;

namespace EventManagement.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetUsers()
    {
        return _userRepository.GetAll();
    }

    public User? GetUserById(Guid id)
    {
        return _userRepository.GetById(id);
    }

    public User CreateUser(User request)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };

        return _userRepository.Add(user);
    }
}