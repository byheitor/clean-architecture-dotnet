using CleanStore.Domain.AccountContext.Exceptions;

public class ErrorMessages
{
    #region Properties
    public static EmailErrorMessages Email { get; } = new();
    #endregion

    public class EmailErrorMessages
    {
        public string NullOrEmpty => "Email não pode ser nulo ou vazio.";
        public string InvalidFormat => "Formato de email inválido.";
    }

}
