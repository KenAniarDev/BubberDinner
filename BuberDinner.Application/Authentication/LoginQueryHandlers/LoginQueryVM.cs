namespace BuberDinner.Application.Authentication.Login;

public record LoginQueryVM
(
    Guid Id,    
    string FirstName,
    string LastName, 
    string Email,
    string Token
);