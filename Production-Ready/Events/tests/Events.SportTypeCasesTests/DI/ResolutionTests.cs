using Events.Api.Cases.SportType;
using Events.Api.DI.Setup;
using Events.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Events.SportTypeCasesTests.DI
{
    public class ResolutionTests
    {
        [Fact]
        public void ItResolve_ISportTypesService()
        {
            // Prepare:

            var services = new ServiceCollection();

            services.AddDbContext<EventsDbContext>(options => options.UseInMemoryDatabase());

            services.AddAllDependencies();

            var iocContainer = services.BuildServiceProvider();

            // Act:

            var cases = iocContainer.GetService<ISportTypeReadOnlyCases>();

            // Assert:

            Assert.NotNull(cases);
        }
    }
}