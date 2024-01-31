namespace BuberDinner.Application.Authentication.Register;

public record RegisterCommandRequest
(
    string FirstName,
    string LastName, 
    string Email,
    string Password
);