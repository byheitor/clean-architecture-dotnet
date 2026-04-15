using CleanStore.Domain.SharedContext.AggregateRoots.Abastractions;

namespace CleanStore.Domain.SharedContext.Repositories.Abstractions;

public interface IRepository<TAggregateRoot>
 where TAggregateRoot : IAggregateRoot
{

}