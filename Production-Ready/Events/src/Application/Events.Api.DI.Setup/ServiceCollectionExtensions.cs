using Events.Api.DI.Setup.Application;
using Events.Api.DI.Setup.Domain;
using Events.Api.DI.Setup.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddApplicationLayerDependencies()
                .AddDomainLayerDependencies()
                .AddInfrastructureLayerDependencies();
        }
    }
}