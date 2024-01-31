using BuberDinner.Application.Services.Authentication.Command.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("dinners")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}