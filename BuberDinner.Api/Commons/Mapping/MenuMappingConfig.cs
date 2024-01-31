using BuberDinner.Application.Menus.CreateMenuCommandHandlers;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menus.Entities;
using Mapster;

namespace BuberDinner.Api.Commons.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuCommandRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);
        
        config.NewConfig<Menu, CreateMenuCommandVM>()
            //n.Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.MenuSections, src => src.MenuSections);
        
        config.NewConfig<MenuSection, MenuSectionVM>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.MenuItems, src => src.MenuItems);

        config.NewConfig<MenuItem, MenuItemVM>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}