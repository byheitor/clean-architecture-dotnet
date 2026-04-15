
using System.Text.RegularExpressions;
using CleanStore.Domain.AccountContext.Exceptions;
using CleanStore.Domain.SharedContext.Extensions;
using CleanStore.Domain.SharedContext.ValueObjects;

namespace CleanStore.Domain.AccountContext.ValueObjects;


public sealed partial record Email : ValueObject
{

    #region Constants

    public const int MaxLength = 160;
    public const int MinLength = 6;
    public const string Pathern = @"^\w+([-+.'\w+])*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    #endregion

    #region Properties
    public string Address { get; private set; } = string.Empty;
    public string Hash { get; private set; } = string.Empty;
    #endregion

    #region Conntructors
    private Email() { }

    private Email(string address, string hash)
    {
        this.Address = address;
        this.Hash = hash;
    }
    #endregion






    #region Factories

    public static Email Create(string address)
    {
        if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            throw new EmailNullOrEmptyException(ErrorMessages.Email.NullOrEmpty);

        address = address.Trim();
        address = address.ToLower();

        if (!EmailRegex().IsMatch(address))
            throw new InvalidEmailException(ErrorMessages.Email.InvalidFormat);

        return new Email(address, address.ToBase64());
    }

    #endregion

    #region  Opertors

    public static implicit operator string(Email email) => email.ToString();

    #endregion

    #region  Overrrides
    public override string ToString()
    {
        return this.Address;
    }
    #endregion

    #region  Others

    [GeneratedRegex(Pathern)]
    private static partial Regex EmailRegex();

    #endregion

}