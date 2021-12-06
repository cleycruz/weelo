using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.OwnersLists.Queries.GetOwners;

public class OwnersDto : IMapFrom<Owner>
{
   public int IdOwner { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Photo { get; set; }
    public DateTime Birthday { get; set; }
    public int ListId { get; set; }
    public int Priority { get; set; }
    public bool Done { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Owner, OwnersDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
    }
}
