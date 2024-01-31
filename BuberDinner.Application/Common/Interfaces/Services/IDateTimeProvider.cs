namespace BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}