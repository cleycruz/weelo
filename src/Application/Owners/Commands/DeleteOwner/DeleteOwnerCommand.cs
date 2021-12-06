using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Owners.Commands.DeleteOwner;

public class DeleteOwnerCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOwnerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Owners
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Owner), request.Id);
        }

        _context.Owners.Remove(entity);

        entity.DomainEvents.Add(new OwnerDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
