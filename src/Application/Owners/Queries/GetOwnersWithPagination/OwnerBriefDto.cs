using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Owners.Queries.GetOwnersWithPagination;

public class OwnerBriefDto : IMapFrom<Owner>
{
    public int IdOwner { get; set; }

    public int ListId { get; set; }

    public string? Name { get; set; }

    public bool Done { get; set; }


}
