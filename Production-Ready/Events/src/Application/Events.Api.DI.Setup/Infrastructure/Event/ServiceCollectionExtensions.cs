using Events.Repository.Event;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Infrastructure.Event
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayerEventDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<IEventsRepository, EventRepository>();
        }
    }
}