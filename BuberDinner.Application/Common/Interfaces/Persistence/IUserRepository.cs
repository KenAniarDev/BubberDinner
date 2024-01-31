using BuberDinner.Application.Services.Authentication.Command.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Add(User user);
    
    User? GetByEmail(string email);
}