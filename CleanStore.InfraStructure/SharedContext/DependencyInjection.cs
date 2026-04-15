using CleanStore.Domain.SharedContext.Repositories.Abstractions;
using CleanStore.Domain.AccountContext.Respositories.Abstractions;
using CleanStore.InfraStructure.AccountContext.Respositories;
using CleanStore.InfraStructure.SharedContext.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CleanStore.InfraStructure.SharedContext;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAccountRepository, AccountRepository>();
        
        return services; 
    }
    
}