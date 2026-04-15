using CleanStore.Application.SharedContext.Behaviors;

namespace CleanStore.Application.SharedContext;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));

        });
        // aqui serão registrados os serviços da camada de aplicação
        return services;
    }

}