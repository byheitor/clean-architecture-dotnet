using CleanStore.Application.SharedContext.UseCases.Abastractions;

namespace CleanStore.Application.AccountContext.UseCases.Create;

public sealed record Command(string Email) : ICommand<Response>
{

}