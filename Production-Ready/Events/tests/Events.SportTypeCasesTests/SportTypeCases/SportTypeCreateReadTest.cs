using Events.Api.Cases.SportType;
using Events.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Events.SportTypeCasesTests.SportTypeCases
{
    public class SportTypeCreateReadTest
    {
        [Fact]
        public async void ItFindsCreatedSportTypes()
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var sportTypeCases = iocContainer.GetService<ISportTypeReadOnlyCases>();

            // Act:

            var sportTypes = await sportTypeCases.GetAllSportTypes();

            // Assert:

            Assert.NotNull(sportTypes);
        }
    }
}