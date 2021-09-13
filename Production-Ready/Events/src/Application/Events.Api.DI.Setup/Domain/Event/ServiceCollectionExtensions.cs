using Events.Domain.Factories.Event;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Domain.Event
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainLayerEventDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<IEventFactory, EventFactory>();
        }
    }
}