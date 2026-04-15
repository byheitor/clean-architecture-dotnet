using CleanStore.Domain.SharedContext.Repositories.Abstractions;

namespace CleanStore.InfraStructure.SharedContext.Data;

public class UnitOfWork (AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }

    public Task RollbackAsync() => Task.CompletedTask;
}