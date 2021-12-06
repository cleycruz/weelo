using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.OwnersLists.Queries.GetOwners;

public class OwnersListDto : IMapFrom<OwnersList>
{
    public OwnersListDto()
    {
        Items = new List<OwnersDto>();
    }

    public int Id { get; set; }

    public string? Name { get; set; }


    public IList<OwnersDto> Items { get; set; }
}
