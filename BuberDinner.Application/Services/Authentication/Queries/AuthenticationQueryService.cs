using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Command.Domain.Common.Errors;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication.Command.Domain.Entities;
using FluentResults;
using ErrorOr;
using  BuberDinner.Application.Services.Authentication.Common;

namespace BuberDinner.Application.Services.Authentication.Query;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        var user = _userRepository.GetByEmail(email);
        // Validate if user exist
        if(user is null)
        {
            return new[] {Errors.Authentication.InvalidCredentials};    
        }
        // Validate if password is correct
        if(user!.Password != password)
        {
            return new[] {Errors.Authentication.InvalidCredentials};    
        }
        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}