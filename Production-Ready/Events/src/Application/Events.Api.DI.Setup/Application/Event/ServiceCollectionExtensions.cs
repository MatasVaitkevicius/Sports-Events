using Events.Api.Cases.Event;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Application.Event
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayerEventDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<IEventCases, EventCases>();
        }
    }
}