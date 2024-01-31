using ErrorOr;
using  BuberDinner.Application.Services.Authentication.Common;

namespace BuberDinner.Application.Services.Authentication.Query;

public interface IAuthenticationQueryService
{
    // Control Flow Via FluentResults
    //Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    ErrorOr<AuthenticationResult> Login(string email, string password);
}