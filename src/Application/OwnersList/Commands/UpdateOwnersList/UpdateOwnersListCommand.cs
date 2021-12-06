using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.OwnersLists.Commands.UpdateOwnersList;

public class UpdateOwnersListCommand : IRequest
{
    public int Id { get; set; }

    public string? Title { get; set; }
}

public class UpdateOwnersListCommandHandler : IRequestHandler<UpdateOwnersListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOwnersListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateOwnersListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.OwnersLists
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(OwnersList), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
