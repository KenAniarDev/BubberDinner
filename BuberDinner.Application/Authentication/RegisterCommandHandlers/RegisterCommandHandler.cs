using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Services.Authentication.Command.Domain.Common.Errors;
using BuberDinner.Application.Services.Authentication.Command.Domain.Entities;

namespace BuberDinner.Application.Authentication.Register;

public record RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterCommandVM>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<RegisterCommandVM>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Check if email is already registered
        if (_userRepository.GetByEmail(request.Email) is not null)
        {
            return new[] {Errors.User.DuplicateEmail};    
        }
        
        // Create user (Generate Unique Id)
        var user = new User { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, Password = request.Password };
        _userRepository.Add(user);
        
        // Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user); 
        
        return new RegisterCommandVM(user.Id, user.FirstName, user.LastName, user.Email, token);
    }
}
