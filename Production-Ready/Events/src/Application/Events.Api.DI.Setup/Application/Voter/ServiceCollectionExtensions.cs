using Events.Api.Cases.Voter;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Application.Voter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayerVoterDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddScoped<IVoterCases, VoterCases>();
        }
    }
}