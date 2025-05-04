using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<LibraryManagement.Application.DTOs.BookDto>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Library API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var keyString = jwtSettings["Key"];
if (string.IsNullOrEmpty(keyString))
    throw new InvalidOperationException("JWT signing key is not configured.");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<LibraryManagement.Api.Services.JwtTokenService>();

// Add Repositories
builder.Services.AddScoped<LibraryManagement.Domain.Interfaces.IUserRepository, LibraryManagement.Infrastructure.Repositories.UserRepository>();
builder.Services.AddScoped<LibraryManagement.Domain.Interfaces.IBookRepository, LibraryManagement.Infrastructure.Repositories.BookRepository>();
builder.Services.AddScoped<LibraryManagement.Domain.Interfaces.ILendingRepository, LibraryManagement.Infrastructure.Repositories.LendingRepository>();
builder.Services.AddScoped<LibraryManagement.Domain.Interfaces.IReservationRepository, LibraryManagement.Infrastructure.Repositories.ReservationRepository>();
builder.Services.AddScoped<LibraryManagement.Domain.Interfaces.ICategoryRepository, LibraryManagement.Infrastructure.Repositories.CategoryRepository>();
builder.Services.AddScoped<LibraryManagement.Domain.Interfaces.ITagRepository, LibraryManagement.Infrastructure.Repositories.TagRepository>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(LibraryManagement.Application.Mapping.UserProfile).Assembly);

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LibraryManagement.Application.Features.Users.Commands.CreateUserCommand).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<LibraryManagement.Api.Middleware.GlobalExceptionMiddleware>();

app.MapControllers();

app.Run(); 