using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FluentValidation;

namespace Deerlicious.API.Features.Users;

public sealed record CreateUserRequest(string Username, string Password, string Email);

public sealed record CreateUserResponse(Guid Id, string Username);

public sealed class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse>
{
    private readonly DeerliciousContext _context;

    public CreateUserEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/users");
        AllowAnonymous();
        Options(x => x.WithTags("Users"));
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken c)
    {
        var user = Database.Entities.User.Create(request.Username, request.Password, request.Email);

        _context.Users.Add(user);

        var result = await _context.SaveChangesAsync(c);

        if (result is not 1)
            ThrowError(ValidationMessages.SavingError);

        await SendAsync(new CreateUserResponse(user.Id, user.UserName), cancellation: c);
    }
}

public sealed class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
    }
}