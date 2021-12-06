using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.OwnersLists.Commands.UpdateOwnersList;

public class UpdateOwnersListCommandValidator : AbstractValidator<UpdateOwnersListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOwnersListCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(UpdateOwnersListCommand model, string title, CancellationToken cancellationToken)
    {
        return await _context.OwnersLists
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
