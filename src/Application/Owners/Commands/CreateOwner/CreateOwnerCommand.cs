using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Owners.Commands.CreateOwner;

public class CreateOwnerCommand : IRequest<int>
{
    public int IdOwner { get; set; }

    public string? Name { get; set; }
}

public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateOwnerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Owner
        {
            IdOwner = request.IdOwner,
            Name = request.Name,
            Done = false
        };

        entity.DomainEvents.Add(new OwnerCreatedEvent(entity));

        _context.Owners.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.IdOwner;
    }
}
