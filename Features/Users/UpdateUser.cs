using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Users;

public sealed record UpdateUserRequest(string Username, string Email, List<Guid> Roles);

public sealed record UpdateUserResponse(Guid Id, string Username);

public sealed class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
    private readonly DeerliciousContext _context;

    public UpdateUserEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put("api/users/{id}");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Users"));
    }

    public override async Task HandleAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var routeUserId = Route<Guid>("id", isRequired: true);

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == routeUserId,
            cancellationToken: cancellationToken);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        user.Email = request.Email;
        user.UserName = request.Username;

        user.Roles = new List<UserRole>(
            request.Roles.Select(roleId => new UserRole
            {
                RoleId = roleId,
                UserId = user.Id
            }));

        await _context.UserRoles
            .Where(userRole => userRole.UserId == user.Id)
            .ExecuteDeleteAsync(cancellationToken);

        _context.Users.Update(user);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new(user.Id, user.UserName), cancellation: cancellationToken);
    }
}

public sealed class UpdateUserValidator : Validator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.Roles).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}