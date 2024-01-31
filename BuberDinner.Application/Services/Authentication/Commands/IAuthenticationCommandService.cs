using ErrorOr;
using  BuberDinner.Application.Services.Authentication.Common;

namespace BuberDinner.Application.Services.Authentication.Command;

public interface IAuthenticationCommandService
{
    // Control Flow Via FluentResults
    //Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}