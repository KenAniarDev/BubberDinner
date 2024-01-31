using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Services;

namespace BuberDinner.Application.Services.Authentication.Command.Infratrasture.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}