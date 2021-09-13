using Events.Api.Cases.Event;
using Events.Api.DI.Setup;
using Events.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Events.EventRepositoryCasesTests.DI
{
    public class ResolutionTests
    {
        [Fact]
        public void ItResolve_IEventsService()
        {
            // Prepare:

            var services = new ServiceCollection();

            services.AddDbContext<EventsDbContext>(options => options.UseInMemoryDatabase());

            services.AddAllDependencies();

            var iocContainer = services.BuildServiceProvider();

            // Act:

            var cases = iocContainer.GetService<IEventCases>();

            // Assert:

            Assert.NotNull(cases);
        }
    }
}