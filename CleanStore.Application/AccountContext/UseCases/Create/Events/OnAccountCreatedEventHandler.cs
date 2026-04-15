using CleanStore.Domain.AccountContext.Events;
using MediatR;

namespace CleanStore.Application.AccountContext.UseCases.Create.Events;

public class OnAccountCreatedEventHandler : INotificationHandler<OnAccountCreatedEvent>
{
    public Task Handle(OnAccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"OnAccountCreatedEventHandler - {notification.Email} se cadastrou");
        return Task.CompletedTask;  
    }
}