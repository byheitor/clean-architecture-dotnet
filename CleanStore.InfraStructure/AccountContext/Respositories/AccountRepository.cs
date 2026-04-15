using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Domain.AccountContext.Respositories.Abstractions;
using CleanStore.InfraStructure.SharedContext.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanStore.InfraStructure.AccountContext.Respositories;

public class AccountRepository(AppDbContext context) : IAccountRepository
{
    public async Task<bool> VerifyEmailExistsAsync(string email)
        => await context.Accounts.AsNoTracking().AnyAsync(a => a.Email.Address == email);

    public async Task SaveAsync(Account account)
        => await context.Accounts.AddAsync(account);
}