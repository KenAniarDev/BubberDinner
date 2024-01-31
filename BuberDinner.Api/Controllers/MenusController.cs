using BuberDinner.Application.Menus.CreateMenuCommandHandlers;
using BuberDinner.Application.Services.Authentication.Command.Api.Controllers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("host/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenusController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuCommandRequest request, Guid hostId)
    {
        var command = new CreateMenuCommand(
            hostId,
            request.Name,
            request.Description,
            _mapper.Map<List<MenuSectionCommand>>(request.MenuSections)
            );
        
        var createMenuResult = await _mediator.Send(command);
        
        return createMenuResult.Match(
            menu => Ok(_mapper.Map<CreateMenuCommandVM>(menu)),
            errors => Problem(errors));
    }
}