using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.OwnersLists.Queries.GetOwners;

public class GetOwnersQuery : IRequest<OwnersVm>
{
}

public class GetOwnerQueryHandler : IRequestHandler<GetOwnersQuery, OwnersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOwnerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OwnersVm> Handle(GetOwnersQuery request, CancellationToken cancellationToken)
    {
        return new OwnersVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList(),

            Lists = await _context.OwnersLists
                .AsNoTracking()
                .ProjectTo<OwnersListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken)
        };
    }
}
