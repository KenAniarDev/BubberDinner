using System.Net;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication.Command.Application.Common.Errors;

public class DuplicateEmailError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}