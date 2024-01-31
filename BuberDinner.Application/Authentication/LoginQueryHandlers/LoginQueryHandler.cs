using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Command.Domain.Common.Errors;
using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<LoginQueryVM>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<LoginQueryVM>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var user = _userRepository.GetByEmail(request.Email);
        // Validate if user exist
        if(user is null)
        {
            return new[] {Errors.Authentication.InvalidCredentials};    
        }
        // Validate if password is correct
        if(user!.Password != request.Password)
        {
            return new[] {Errors.Authentication.InvalidCredentials};    
        }
        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new LoginQueryVM(user.Id, user.FirstName, user.LastName, user.Email, token);
    }
}