using FastEndpoints;
using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Administrators;

public sealed record CreateAdministratorRequest(Guid User, string FirstName, string LastName);

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

    public override async Task HandleAsync(CreateAdministratorRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.User, cancellationToken);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        var administratorExists = _context.Administrators.Any(x => x.UserId == user.Id);

        if (administratorExists)
            ThrowError(ErrorMessages.AlreadyExists);

        var newAdministrator = Administrator.Init(user, request.FirstName, request.LastName);

        _context.Administrators.Add(newAdministrator);

        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result == 0)
            ThrowError(ErrorMessages.SavingError);

        await SendAsync(new CreateAdministratorResponse(newAdministrator.Id, newAdministrator.FullName),
            cancellation: cancellationToken);
    }
}

public sealed class CreateAdministratorValidator : Validator<CreateAdministratorRequest>
{
    public CreateAdministratorValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.Required);
        RuleFor(x => x.User).NotEmpty().WithMessage(ValidationMessages.Required);
    }
}