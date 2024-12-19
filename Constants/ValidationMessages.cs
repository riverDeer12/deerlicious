using FluentValidation.Results;

namespace Deerlicious.API.Constants;

public static class ValidationMessages
{
    public const string IdNotProvided = nameof(IdNotProvided);
    public const string NotValid = nameof(NotValid);
    public const string Required = nameof(Required);
    public const string UsernameAlreadyExists = nameof(UsernameAlreadyExists);
    public const string WrongUserNameOrPassword = nameof(WrongUserNameOrPassword);
}