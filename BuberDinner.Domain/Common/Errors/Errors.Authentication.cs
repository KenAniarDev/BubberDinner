using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Command.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials =>
                Error.Validation(code: "Authentication.InvalidCredentials", description: "Invalid Credentials.");
        }
    }
}