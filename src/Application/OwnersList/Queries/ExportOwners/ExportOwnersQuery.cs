using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.OwnersLists.Queries.ExportOwners;

public class ExportOwnersQuery : IRequest<ExportOwnersVm>
{
    public int ListId { get; set; }
}

public class ExportOwnersQueryHandler : IRequestHandler<ExportOwnersQuery, ExportOwnersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilderOwner _fileBuilder;

    public ExportOwnersQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilderOwner fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportOwnersVm> Handle(ExportOwnersQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Owners
                .Where(t => t.ListId == request.ListId)
                .ProjectTo<OwnersRecord>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        var vm = new ExportOwnersVm(
            "OwnersItems.csv",
            "text/csv",
            _fileBuilder.BuildOwnersFile(records));

        return vm;
    }
}
