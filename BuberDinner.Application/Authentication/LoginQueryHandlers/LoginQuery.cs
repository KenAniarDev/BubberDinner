using BuberDinner.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Login;

public record LoginQuery (string Email, string Password) : IRequest<ErrorOr<LoginQueryVM>>;