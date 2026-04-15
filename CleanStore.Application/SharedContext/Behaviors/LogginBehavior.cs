using CleanStore.Application.SharedContext.UseCases.Abastractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanStore.Application.SharedContext.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            var requestName = typeof(TRequest).Name;
            logger.LogInformation($"Handling request {requestName}");

            var result = await next();

            logger.LogInformation($"Request {requestName} processed");

            return result;
        }
        catch (Exception e)
        {
            logger.LogError(e, $"Error while handling request {request.GetType().Name}");
            throw;
        }
    }
}