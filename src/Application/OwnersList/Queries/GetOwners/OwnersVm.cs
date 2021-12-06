namespace CleanArchitecture.Application.OwnersLists.Queries.GetOwners;

public class OwnersVm
{
    public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

    public IList<OwnersListDto> Lists { get; set; } = new List<OwnersListDto>();
}
