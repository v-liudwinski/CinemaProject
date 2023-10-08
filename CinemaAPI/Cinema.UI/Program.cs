using System.Text;
using Cinema.Service.DI;
using Cinema.Service.Interfaces;
using Cinema.Service.Services;
using Cinema.UI.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using TokenHandler = Cinema.Service.Services.TokenHandler;

namespace Cinema.UI;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Logger
        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

        builder.Services.AddCors();
        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "JWT Authentication",
                Description = "Enter a valid JWT  bearer token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference()
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
    
            options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, new string[] {} }
            });
        });
        
        // DI
        builder.Services.AddPersistence(builder.Configuration);

        builder.Services.AddScoped<IServiceManager, ServiceManager>();
        builder.Services.AddScoped<ITokenHandler, TokenHandler>();
        builder.Services.AddScoped<IAuthenticatorService, AuthenticatorService>();

        // Add AutoMapper
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        // Add FluentValidation
        builder.Services.AddFluentValidation(options =>
        {
            options.RegisterValidatorsFromAssemblyContaining<Program>();
            options.ImplicitlyValidateChildProperties = true;
        });
        
        // Add Authentication
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option => option.TokenValidationParameters 
                = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                }
            );

        var app = builder.Build();

        app.UseCors(options =>
                options
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000")
                    .WithExposedHeaders("X-Pagination")
            );
        
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "uploads")),
            RequestPath = "/uploads"
        });

        var logger = app.Services.GetRequiredService<ILoggerManager>();
        app.ConfigureExceptionHandler(logger);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}