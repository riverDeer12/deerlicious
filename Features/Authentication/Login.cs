using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using FastEndpoints;
using FastEndpoints.Security;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Deerlicious.API.Features.Authentication;

public sealed record LoginRequest(string Username, string Password, bool RememberMe);

public sealed record LoginResponse(string Token);

public sealed class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    private readonly DeerliciousContext _context;
    private readonly IConfiguration _configuration;

    public LoginEndpoint(DeerliciousContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public override void Configure()
    {
        Post("api/authentication/login");
        AllowAnonymous();
        Options(x => x.WithTags("Authentication"));
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(x => x.Roles).ThenInclude(userRole => userRole.Role)
            .FirstOrDefaultAsync(x => x.UserName == request.Username, cancellationToken);

        if (user is null)
            ThrowError(ErrorMessages.NotFound);

        if (!user.IsValidPassword(request.Password))
            ThrowError(ValidationMessages.WrongUserNameOrPassword);

        var jwtToken = JwtBearer.CreateToken(
            o =>
            {
                o.SigningKey = _configuration["JWTSecretKey"] ?? string.Empty;
                o.ExpireAt = DateTime.Now.AddDays(1);
                o.User.Roles.AddRange(user.Roles.Select(r => r.Role.Name));
                o.User.Claims.Add(("name", request.Username), 
                    ("sub", user.Id.ToString()));
            });

        await SendAsync(new LoginResponse(jwtToken), cancellation: cancellationToken);
    }
}

public sealed class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}