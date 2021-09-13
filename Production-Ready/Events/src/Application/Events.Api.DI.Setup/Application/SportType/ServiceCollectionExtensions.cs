using Events.Api.Cases.SportType;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Application.SportType
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayerSportTypeDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<ISportTypeReadOnlyCases, SportTypeCases>();
        }
    }
}