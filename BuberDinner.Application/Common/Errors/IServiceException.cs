using System.Net;

namespace BuberDinner.Application.Services.Authentication.Command.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}