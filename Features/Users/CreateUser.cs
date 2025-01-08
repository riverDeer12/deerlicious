using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record CreateUserRequest(string Username, string Password, string Email);

public sealed record CreateUserResponse(Guid Id, string Username);

public sealed class CreateUserEndpoint(DeerliciousContext context) : Endpoint<CreateUserRequest, CreateUserResponse>
{
    public override void Configure()
    {
        Post("api/users");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Users"));
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var usernameExists = await context.Users
            .FirstOrDefaultAsync(x => x.UserName == request.Username, cancellationToken: cancellationToken) 
            is not null;

        if (usernameExists)
            ThrowError(ValidationMessages.UsernameAlreadyExists);

        var user = Database.Entities.User.Create(request.Username, request.Password, request.Email);

        context.Users.Add(user);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateUserResponse(user.Id, user.UserName), cancellation: cancellationToken);
    }
}

public sealed class CreateUserValidator : Validator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}