
namespace CleanStore.Application.SharedContext.Results;

public record Error(string Code, string Message)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NotFound = new("404", "O recurso não foi encontrado.");
    public static Error NullValue = new("Error.NullValue", "Um valor nulo foi fornecido.");

}