using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record UpdateUserRequest(string Email);

public sealed record UpdateUserResponse(string Username, string Email);

public sealed class UpdateUserEndpoint(DeerliciousContext context) : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
    public override void Configure()
    {
        Put("api/users/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Users"));
    }

    public override async Task HandleAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var routeUserId = Route<Guid>("id", isRequired: true);

        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == routeUserId,
            cancellationToken: cancellationToken);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        user.Email = request.Email;

        context.Users.Update(user);

        var result = await context.SaveChangesAsync(cancellationToken);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new(user.Email, user.UserName), cancellation: cancellationToken);
    }
}

public sealed class UpdateUserValidator : Validator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}