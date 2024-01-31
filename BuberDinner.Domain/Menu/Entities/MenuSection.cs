using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.Menus.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _menuItems = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();
    private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> menuItems) : base(id)
    {
        Id = id;
        Name = name;
        Description = description;
        _menuItems = menuItems;
    }
    
    public static MenuSection Create(string name, string description, List<MenuItem> menuItems)
    {
        return new(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
    
#pragma warning disable CS8618
    private MenuSection() {}
#pragma warning restore CS8618
   
    
}