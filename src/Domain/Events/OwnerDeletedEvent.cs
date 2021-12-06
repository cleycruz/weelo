namespace CleanArchitecture.Domain.Events;

public class OwnerDeletedEvent : DomainEvent
{
    public OwnerDeletedEvent(Owner item)
    {
        Item = item;
    }

    public Owner Item { get; }
}
