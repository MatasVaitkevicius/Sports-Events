using AutoMapper;
using Events.Api.DI.Setup.Application.Event;
using Events.Api.DI.Setup.Application.SportType;
using Events.Api.DI.Setup.Application.Voter;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.Api.DI.Setup.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayerDependencies(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddApplicationLayerEventDependencies()
                .AddApplicationLayerSportTypeDependencies()
                .AddApplicationLayerVoterDependencies()
                .AddAutoMapper();
        }
    }
}