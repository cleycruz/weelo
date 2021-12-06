using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using MediatR;

namespace CleanArchitecture.Application.OwnersLists.Commands.PurgeOwnersLists;

[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public class PurgeOwnersListsCommand : IRequest
{
}

public class PurgeOwnersListsCommandHandler : IRequestHandler<PurgeOwnersListsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeOwnersListsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PurgeOwnersListsCommand request, CancellationToken cancellationToken)
    {
        _context.OwnersLists.RemoveRange(_context.OwnersLists);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
