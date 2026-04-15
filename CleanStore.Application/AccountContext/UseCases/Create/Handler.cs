using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Domain.AccountContext.Respositories.Abstractions;
using CleanStore.Domain.AccountContext.ValueObjects;
using CleanStore.Domain.SharedContext.Repositories.Abstractions;
using CleanStore.Application.SharedContext.Results;
using CleanStore.Application.SharedContext.UseCases.Abastractions;


namespace CleanStore.Application.AccountContext.UseCases.Create;

public sealed class Handler(
    IAccountRepository accountRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        // verificar se o email já cadastrado
        var emailExists = await accountRepository.VerifyEmailExistsAsync(request.Email);
        if (emailExists)
            return Result.Failure<Response>(new Error("400", "Email já cadastrado."));

        // gera os VOs
        var email = Email.Create(request.Email);

        // gera a entidade
        var account = Account.Create(email);

        // persiste os dados 
        await accountRepository.SaveAsync(account);
        await unitOfWork.CommitAsync();

        // retorna o resultado
        var response = new Response(account.Id, account.Email);
        return Result.Success(response);

    }
}