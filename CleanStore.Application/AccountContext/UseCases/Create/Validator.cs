using CleanStore.Domain.AccountContext.ValueObjects;
using FluentValidation;

namespace CleanStore.Application.AccountContext.UseCases.Create;

public class Validator : AbstractValidator<Command>
{

    public Validator()
    {
        RuleFor(x => x.Email)
        .MinimumLength(Email.MinLength).WithMessage($"Email deve conter pelo menos {Email.MinLength} characteres.");

        RuleFor(x => x.Email)
        .MaximumLength(Email.MaxLength).WithMessage($"Email deve conter no máximo {Email.MaxLength} characteres.");

        RuleFor(x => x.Email)
        .Matches(Email.Pathern).WithMessage($"Email tem formato inválido.");

    }


}