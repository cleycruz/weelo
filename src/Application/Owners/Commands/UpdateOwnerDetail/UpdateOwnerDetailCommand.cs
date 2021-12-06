using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Owners.Commands.UpdateOwnerDetail;

public class UpdateOwnerDetailCommand : IRequest
{
    public int IdOwner { get; set; }

    public int ListId { get; set; }

    public PriorityLevel Priority { get; set; }

    public string? Note { get; set; }
}

public class UpdateOwnerDetailCommandHandler : IRequestHandler<UpdateOwnerDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOwnerDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateOwnerDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Owners
            .FindAsync(new object[] { request.IdOwner }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Owner), request.IdOwner);
        }

       // entity.ListId = request.ListId;
       // entity.Priority = request.Priority;
       // entity.Note = request.Note;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
