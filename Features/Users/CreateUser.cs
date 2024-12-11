using Deerlicious.API.Constants;
using Deerlicious.API.Database;
using Deerlicious.API.Database.Entities;
using Deerlicious.API.Services;
using FastEndpoints;

namespace Deerlicious.API.Features.Users;

public record CreateUserRequest(
    string Username, 
    string Password,
    string Email);

public class CreateUserResponse
{
    public required Guid Id { get; set; }
    public required string Username { get; set; }
}

public sealed class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse>
{
    private readonly DeerliciousContext _context;
    private readonly IPasswordService _passwordService;
    
    public CreateUserEndpoint(DeerliciousContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public override void Configure()
    {
        Post("api/users");
        AllowAnonymous();
        Options(x => x.WithTags("Users"));
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken c)
    {

        var salt = _passwordService.GenerateSalt();
        
        var user = new User
        { 
            UserName = request.Username,
            Email = request.Email,
            Salt = salt,
            Password = _passwordService.HashPasswordWithSalt(request.Password, salt)
        };

        _context.Users.Add(user);

        var result = await _context.SaveChangesAsync(c);

        if (result is not 1)
            ThrowError(ValidationMessages.SavingError);

        await SendAsync(new CreateUserResponse
        {
            Id = user.UserId,
            Username = user.UserName
        }, cancellation: c);
    }
}