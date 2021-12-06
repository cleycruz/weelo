namespace CleanArchitecture.Domain.Events;

public class OwnerCreatedEvent : DomainEvent
{
    public OwnerCreatedEvent(Owner item)
    {
        Item = item;
    }

    public Owner Item { get; }
}
