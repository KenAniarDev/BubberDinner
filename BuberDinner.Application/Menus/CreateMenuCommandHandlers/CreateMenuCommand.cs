using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Menus.CreateMenuCommandHandlers;

public class CreateMenuCommand : IRequest<ErrorOr<Domain.Menu.Menu>>
{
    public Guid HostId { get;}
    public string Name { get; }
    public string Description { get; }
    public List<MenuSectionCommand> MenuSections { get; }
    public CreateMenuCommand(Guid hostId, string name, string description, List<MenuSectionCommand> menuSections)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        MenuSections = menuSections;
    }
}


public class MenuSectionCommand
{
    public string Name { get; }
    public string Description { get; }
    public List<MenuItemCommand> MenuItems { get; }
    
    public MenuSectionCommand(string name, string description, List<MenuItemCommand> menuItems)
    {
        Name = name;
        MenuItems = menuItems;
        Description = description;
    }

}

public class MenuItemCommand
{
    public string Name { get; }
    public string Description { get; }
    
    public MenuItemCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }
}