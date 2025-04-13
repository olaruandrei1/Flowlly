using Microsoft.Extensions.DependencyInjection;
using Ollyware.Flowlly.Core.API.Application.Contracts.Infrastructure;
using Ollyware.Flowlly.Core.API.Application.Contracts.Infrastructure.ExternalCalls;
using Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;
using Ollyware.Flowlly.Core.API.Infrastructure.Implementations;
using Refit;

namespace Ollyware.Flowlly.Core.API.Infrastructure;

public static class InfrastructureDependencies
{
    public static IServiceCollection InfrastructureRegister(this IServiceCollection services, ExternalDependencies externalDependencies)
    {
        services.AddScoped<IExportFiles, ExportFiles>()
               .AddScoped<IManipulateFiles, ManipulateFiles>();

        services.AddHttpClient<IExternalHttps, ExternalHttps>((serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(externalDependencies.HttpBase);
        });

        services.AddRefitClient<INotificationsPushes>(new())
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(externalDependencies.NotificationsRefitBase));

        return services;
    }
}
