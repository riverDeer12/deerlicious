using Deerlicious.API.Database;
using Deerlicious.API.Services;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services
    .AddAuthenticationJwtBearer(s => 
        s.SigningKey = configuration["JWTSecretKey"])
    .AddAuthorization()
    .AddFastEndpoints();

builder.Services.AddDbContext<DeerliciousContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseFastEndpoints();

app.UseAuthentication();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();