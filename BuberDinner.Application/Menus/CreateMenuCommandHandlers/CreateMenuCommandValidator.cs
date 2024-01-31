using FluentValidation;

namespace BuberDinner.Application.Menus.CreateMenuCommandHandlers;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        this.RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        this.RuleFor(x => x.Description).NotEmpty();
    }
}