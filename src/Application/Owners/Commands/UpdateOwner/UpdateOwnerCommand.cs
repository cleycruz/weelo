using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Owners.Commands.UpdateOwner;

public class UpdateOwnerCommand : IRequest
{
    public int IdOwner { get; set; }

    public string? Name { get; set; }

    public bool Done { get; set; }
}

public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOwnerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Owners
            .FindAsync(new object[] { request.IdOwner }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Owner), request.IdOwner);
        }

        entity.Name = request.Name;
        entity.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
