using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Cinema.Persistence.Repositories;
using Cinema.Service.Interfaces;
using Cinema.Service.Services;
using Cinema.Service.Services.Logger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Service.DI;

public static class PersistenceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CinemaDb"));
        });

        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddSingleton<ILoggerManager, LoggerManager>();
        services.AddScoped<IAuthenticatorRepository, AuthenticatorRepository>();
        services.AddScoped<IPdfService, PdfService>();

        return services;
    }
}