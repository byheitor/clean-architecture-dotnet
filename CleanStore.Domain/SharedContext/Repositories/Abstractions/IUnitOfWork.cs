namespace CleanStore.Domain.SharedContext.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
}