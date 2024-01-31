namespace BuberDinner.Application.Menus.CreateMenuCommandHandlers;

public record CreateMenuCommandVM
(
    Guid HostId,
    Guid Id,
    string Name,
    string Description,
    List<MenuSectionRequest> MenuSections
);

public record MenuSectionVM
(
    Guid Id,
    string Name,
    string Description,
    List<MenuItemVM> MenuItems
);

public record MenuItemVM
(
    Guid Id,
    string Name,
    string Description
);