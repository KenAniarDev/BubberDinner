using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Command.Domain.Entities;

namespace BuberDinner.Infratrasture.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetByEmail(string email)
    {
       return _users.SingleOrDefault(user => user.Email == email);
    }
}