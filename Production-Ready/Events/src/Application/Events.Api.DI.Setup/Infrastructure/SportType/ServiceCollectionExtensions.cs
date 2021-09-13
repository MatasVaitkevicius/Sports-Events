using Events.Repository.SportType;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Infrastructure.SportType
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayerSportTypeDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<ISportTypeRepository, SportTypeRepository>();
        }
    }
}