using Events.Repository.Voter;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Infrastructure.Voter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayerVoterDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<IVoterRepository, VoterRepository>();
        }
    }
}