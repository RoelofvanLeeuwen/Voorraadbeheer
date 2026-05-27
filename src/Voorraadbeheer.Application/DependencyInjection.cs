using Microsoft.Extensions.DependencyInjection;

namespace Voorraadbeheer.Application;

/// <summary>
/// Registratie van alle Application-services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Voegt Application-services toe aan de DI-container.
    /// </summary>
    /// <param name="services">De service-collectie.</param>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services worden hier geregistreerd bij uitwerking van user stories.
        return services;
    }
}
