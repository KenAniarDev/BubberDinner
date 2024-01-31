using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Command.Domain.Common.Errors;
using BuberDinner.Application.Services.Authentication.Command.Domain.Entities;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Errors;
using FluentResults;
using ErrorOr;
using  BuberDinner.Application.Services.Authentication.Common;

namespace BuberDinner.Application.Services.Authentication.Command;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    // Control Flow Via FluentResult
    // public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Control Flow Via ErrorOr
        if (_userRepository.GetByEmail(email) is not null)
        {
            return new[] {Errors.User.DuplicateEmail};    
        }
        
        // Check if email is already registered
        // Control Flow Via FluentResult
        // if (_userRepository.GetByEmail(email) is not null)
        // {
        //     return Result.Fail<AuthenticationResult>(new[] {new DuplicateEmailError()});
        // }
        // Control Flow Via Exceptions
        // if (_userRepository.GetByEmail(email) is not null)
        // {
        //     throw new DuplicateEmailException();
        // }
        // Create user (Generate Unique Id)
        var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };
        _userRepository.Add(user);
        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user); 
        return new AuthenticationResult(user, token);
    }

}