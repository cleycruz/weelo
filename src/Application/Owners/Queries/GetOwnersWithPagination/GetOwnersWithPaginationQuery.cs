using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Owners.Queries.GetOwnersWithPagination;

public class GetOwnersWithPaginationQuery : IRequest<PaginatedList<OwnerBriefDto>>
{
    public int ListId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetOwnersWithPaginationQueryHandler : IRequestHandler<GetOwnersWithPaginationQuery, PaginatedList<OwnerBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOwnersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<OwnerBriefDto>> Handle(GetOwnersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Owners
            .Where(x => x.IdOwner == request.ListId)
            .OrderBy(x => x.Name)
            .ProjectTo<OwnerBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
