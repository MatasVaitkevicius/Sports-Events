using Events.Api.DI.Setup;
using Events.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Events.TestHelpers
{
    public class DependencyInjectionHelper
    {
        public static IServiceProvider CreateAndConfigureContainer()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EventsDbContext>(options => options.UseInMemoryDatabase());

            services.AddAllDependencies();

            var iocContainer = services.BuildServiceProvider();

            return iocContainer;
        }
    }
}