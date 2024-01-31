namespace BuberDinner.Application.Authentication.Login;

public record LoginQueryRequest
(
    string Email,
    string Password
);