using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.OwnersLists.Commands.DeleteOwnersList;

public class DeleteOwnersListCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteOwnersListCommandHandler : IRequestHandler<DeleteOwnersListCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOwnersListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteOwnersListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.OwnersLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(OwnersList), request.Id);
        }

        _context.OwnersLists.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
