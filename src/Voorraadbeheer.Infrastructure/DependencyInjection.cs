using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Voorraadbeheer.Core.Interfaces;
using Voorraadbeheer.Infrastructure.Persistence;
using Voorraadbeheer.Infrastructure.Repositories;

namespace Voorraadbeheer.Infrastructure;

/// <summary>
/// Registratie van alle Infrastructure-services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Voegt Infrastructure-services toe aan de DI-container.
    /// </summary>
    /// <param name="services">De service-collectie.</param>
    /// <param name="connectionString">SQLite connection string.</param>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
