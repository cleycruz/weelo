using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.OwnersLists.Commands.CreateOwnersList;

public class CreateOwnersListCommand : IRequest<int>
{
    public string? Title { get; set; }
}

public class CreateOwnersListCommandHandler : IRequestHandler<CreateOwnersListCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateOwnersListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateOwnersListCommand request, CancellationToken cancellationToken)
    {
        var entity = new OwnersList();

        entity.Title = request.Title;

        _context.OwnersLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
