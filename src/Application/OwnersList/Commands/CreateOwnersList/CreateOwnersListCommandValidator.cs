using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.OwnersLists.Commands.CreateOwnersList;

public class CreateOwnersListCommandValidator : AbstractValidator<CreateOwnersListCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOwnersListCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.OwnersLists
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
