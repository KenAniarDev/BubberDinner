namespace BuberDinner.Application.Authentication.Register;

public record RegisterCommandVM
(
    Guid Id,    
    string FirstName,
    string LastName, 
    string Email,
    string Token
);    
