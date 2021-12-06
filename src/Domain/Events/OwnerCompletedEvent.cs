namespace CleanArchitecture.Domain.Events;

public class OwnerCompletedEvent : DomainEvent
{
    public OwnerCompletedEvent(Owner item)
    {
        Item = item;
    }

    public Owner Item { get; }
}
