using FluentValidation;

namespace CleanArchitecture.Application.Owners.Commands.CreateOwner;

public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
{
    public CreateOwnerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
