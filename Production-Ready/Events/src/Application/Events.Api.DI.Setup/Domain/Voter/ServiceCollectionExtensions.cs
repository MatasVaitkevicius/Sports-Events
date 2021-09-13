using Events.Domain.Factories.Voter;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Domain.Voter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainLayerVoterDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<IVoterFactory, VoterFactory>();
        }
    }
}