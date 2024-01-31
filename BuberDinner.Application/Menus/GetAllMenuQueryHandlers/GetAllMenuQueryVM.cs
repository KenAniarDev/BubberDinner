using BuberDinner.Domain.Hosts.ValueObjects;

namespace BuberDinner.Application.Menu.GetAllMenuQueryHandlers;

public record GetAllMenuQueryVM(
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    List<MenuSectionVM> MenuSections,
    HostId HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record MenuSectionVM
(
    string Id, 
    string Name, 
    string Description, 
    List<MenuItemVM> MenuItems
);

public record MenuItemVM
(
    string Id, 
    string Name, 
    string Description
);