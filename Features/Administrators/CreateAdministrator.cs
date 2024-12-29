using FastEndpoints;
using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record CreateAdministratorRequest(Guid UserId, string FirstName, string LastName);
public sealed record CreateAdministratorResponse(Guid Id, string FullName);

public sealed class CreateAdministratorEndpoint : Endpoint<CreateAdministratorRequest, CreateAdministratorResponse>
{
    private readonly DeerliciousContext _context;

    public CreateAdministratorEndpoint(DeerliciousContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/administrators");
        Roles(SeedData.SuperAdminRoleName);
        Options(x => x.WithTags("Administrators"));
    }

    public override async Task HandleAsync(CreateAdministratorRequest request, CancellationToken ct)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, ct);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        var newAdministrator = Administrator.Create(user, request.FirstName, request.LastName);

        _context.Administrators.Add(newAdministrator);

        var result = await _context.SaveChangesAsync(ct);

        if (result is not 1)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateAdministratorResponse(newAdministrator.Id, newAdministrator.FullName),
            cancellation: ct);
    }
}

public sealed class CreateAdministratorRequestValidator : Validator<CreateAdministratorRequest>
{
    public CreateAdministratorRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}