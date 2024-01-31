using BuberDinner.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Register;

public record RegisterCommand
(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password
) : IRequest<ErrorOr<RegisterCommandVM>>;