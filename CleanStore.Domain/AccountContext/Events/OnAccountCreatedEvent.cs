using CleanStore.Domain.Events.Abstractions;

namespace CleanStore.Domain.AccountContext.Events;

public sealed record OnAccountCreatedEvent(Guid Id, string Email) : IDomainEvent;

