using BuberDinner.Application.Authentication.Login;
using BuberDinner.Application.Authentication.Register;
using BuberDinner.Application.Services.Authentication.Command.Domain.Common.Errors;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Query;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Application.Services.Authentication.Command.Api.Controllers;

[ApiController]
[Route("auth")]
// [ErrorHandlingFilter]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    
    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService, ISender mediator, IMapper mapper)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<RegisterCommandVM> authResult = await _mediator.Send(command);
        // Control Flow Via ErrorOr

        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors));

        // Control Flow Via FluentResults
        // Result<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        // if (registerResult.IsSuccess)
        // {
        //     return Ok(MapAuthResult(registerResult.Value));
        // }
        // var firstError = registerResult.Errors.First();
        //
        // if (firstError is DuplicateEmailError)
        // {
        //     return Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Message);
        // }
        //
        // return Problem();

        // Control Flow Via Exceptions
        // var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        // var response = new AuthenticationResponse(
        //     authResult.user.Id,
        //     authResult.user.FirstName,
        //     authResult.user.LastName,
        //     authResult.user.Email,
        //     authResult.Token
        // );
        // return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQueryRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<LoginQueryVM> authResult = await _mediator.Send(query);
        // ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(request.Email, request.Password);

        
        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        
        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors));
    }
}