using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Owners.EventHandlers;

public class OwnerCreatedEventHandler : INotificationHandler<DomainEventNotification<OwnerCreatedEvent>>
{
    private readonly ILogger<OwnerCreatedEventHandler> _logger;

    public OwnerCreatedEventHandler(ILogger<OwnerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<OwnerCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}
