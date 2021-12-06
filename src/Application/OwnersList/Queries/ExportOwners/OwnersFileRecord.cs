using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.OwnersLists.Queries.ExportOwners;

public class OwnersRecord : IMapFrom<Owner>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
