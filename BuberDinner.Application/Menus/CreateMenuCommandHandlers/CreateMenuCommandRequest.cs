namespace BuberDinner.Application.Menus.CreateMenuCommandHandlers;

public record CreateMenuCommandRequest
(
    string Name,
    string Description,
    List<MenuSectionRequest> MenuSections
);

public record MenuSectionRequest
(
    string Name,
    string Description,
    List<MenuItemRequest> MenuItems
);

public record MenuItemRequest
(
    string Name,
    string Description
);