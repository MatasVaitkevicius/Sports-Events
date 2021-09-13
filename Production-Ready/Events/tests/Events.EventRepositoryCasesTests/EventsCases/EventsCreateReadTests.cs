using Events.Api.Cases.Event;
using Events.Api.Cases.Users;
using Events.Api.Dto.Events;
using Events.Api.Dto.Users;
using Events.EventRepositoryCasesTests.EventsCases.TestData;
using Events.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Events.EventRepositoryCasesTests.EventsCases
{
    public class EventsCreateReadTests
    {
        [Theory, ClassData(typeof(EventsValidationDataCollection))]
        public async void ItFindsCreatedEvent_WhenEventIsCreated(NewUser newUser, NewEvent newEvent)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var userCases = iocContainer.GetService<IUserCases>();

            var eventCases = iocContainer.GetService<IEventCases>();

            // Act:

            var userId = await userCases.CreateUser(newUser);

            newEvent.UserId = userId;

            var eventId = await eventCases.CreateEvent(newEvent);

            // Assert:

            var retrievedEvent = await eventCases.GetEventById(eventId);

            Assert.NotNull(retrievedEvent);
        }
    }
}