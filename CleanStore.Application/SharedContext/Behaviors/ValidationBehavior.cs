

using CleanStore.Application.SharedContext.UseCases.Abastractions;
using FluentValidation;
using MediatR;

namespace CleanStore.Application.SharedContext.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand
{

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        if (validators.Any() == false)
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationErrors = validators
            .Select(validator => validator.Validate(context))
            .Where(validationResult => validationResult.Errors.Any())
            .SelectMany(validationResult => validationResult.Errors)
            .Select(error => new ValidationError(error.PropertyName, error.ErrorMessage))
            .ToList();
        
        if (validationErrors.Any())
            throw new ValidationException(validationErrors);
        
        // var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
        //
        // if (failures.Count != 0)
        //     throw new ValidationException(failures);

        return await next();
    }

}


public sealed class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        this.Errors = errors;
    }
    
    public IEnumerable<ValidationError> Errors { get; } 
}

public sealed record ValidationError(string PropertyName, string ErrorMessage);
