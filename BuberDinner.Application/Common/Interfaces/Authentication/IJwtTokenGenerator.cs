using BuberDinner.Application.Services.Authentication.Command.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}