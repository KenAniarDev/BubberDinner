using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using BuberDinner.Infratrasture.Persistance;

namespace BuberDinner.Infratrasture.Persistance.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;
    private static readonly List<BuberDinner.Domain.Menu.Menu> _menus = new();

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(BuberDinner.Domain.Menu.Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();   
    }
}