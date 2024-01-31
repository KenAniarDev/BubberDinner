namespace BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(BuberDinner.Domain.Menu.Menu menu);
}