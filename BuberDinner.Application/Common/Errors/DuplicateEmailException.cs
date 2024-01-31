using System.Net;

namespace BuberDinner.Application.Services.Authentication.Command.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => $"Email is already in use.";
}