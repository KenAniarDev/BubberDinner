using BuberDinner.Application.Services.Authentication.Command.Api.Commons.Http;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Application.Services.Authentication.Command.Api.Controllers;

public class ApiController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }
        
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        if (errors == null) throw new ArgumentNullException(nameof(errors));
        
        var firstError = errors.First();

        return Problem(firstError);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        
        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelState = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        return base.ValidationProblem(modelState);
    }
}