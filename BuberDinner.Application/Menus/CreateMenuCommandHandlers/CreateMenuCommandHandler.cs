using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.Entities;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Menus.CreateMenuCommandHandlers;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Domain.Menu.Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Domain.Menu.Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Create Menu
        var menu = Domain.Menu.Menu.Create(HostId.Create(request.HostId), request.Name, request.Description,
            request.MenuSections.ConvertAll(section => MenuSection.Create(section.Name, section.Description,
                section.MenuItems.ConvertAll(item => MenuItem.Create(item.Name, item.Description)))));

        // Persist Menu
        _menuRepository.Add(menu);
        
        return menu;
    }
}