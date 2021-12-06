namespace CleanArchitecture.Domain.Entities;

public class OwnersList : AuditableEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public IList<Owner> Items { get; private set; } = new List<Owner>();
}
