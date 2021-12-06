using FluentValidation;

namespace CleanArchitecture.Application.Owners.Commands.UpdateOwner;

public class UpdateOwnerCommandValidator : AbstractValidator<UpdateOwnerCommand>
{
    public UpdateOwnerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
