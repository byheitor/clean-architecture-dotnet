

using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Domain.SharedContext.Repositories.Abstractions;

namespace CleanStore.Domain.AccountContext.Respositories.Abstractions;

public interface IAccountRepository : IRepository<Account>
{
    Task<bool> VerifyEmailExistsAsync(string email);

    Task SaveAsync(Account account);
}