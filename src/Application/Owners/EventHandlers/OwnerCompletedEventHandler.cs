using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Owners.EventHandlers;

public class OwnerCompletedEventHandler : INotificationHandler<DomainEventNotification<OwnerCompletedEvent>>
{
    private readonly ILogger<OwnerCompletedEventHandler> _logger;

    public OwnerCompletedEventHandler(ILogger<OwnerCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<OwnerCompletedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}
