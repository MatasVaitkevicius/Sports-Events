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
    public class EventsUpdateTest
    {
        [Theory, ClassData(typeof(EventsUpdateDataCollection))]
        public async void ItHasUpdatedData_WhenEventIsUpdated(NewUser newUser, NewEvent newEvent, EventUpdate updatedEvent)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var userCases = iocContainer.GetService<IUserCases>();

            var eventCases = iocContainer.GetService<IEventCases>();

            // Act:

            var userId = await userCases.CreateUser(newUser);

            newEvent.UserId = userId;

            var eventId = await eventCases.CreateEvent(newEvent);

            await eventCases.UpdateEvent(eventId, updatedEvent);

            // Assert:

            var retrievedEvent = await eventCases.GetEventById(eventId);

            Assert.Equal(updatedEvent.Name, retrievedEvent.Name);
            Assert.Equal(updatedEvent.EventDate, retrievedEvent.EventDate);
            Assert.Equal(updatedEvent.TimeFrom, retrievedEvent.TimeFrom);
            Assert.Equal(updatedEvent.TimeTill, retrievedEvent.TimeTill);
            Assert.Equal(updatedEvent.Price, retrievedEvent.Price);
            Assert.Equal(updatedEvent.PhoneNumber, retrievedEvent.PhoneNumber);
            Assert.Equal(updatedEvent.Location.Address, retrievedEvent.Location.Address);
            Assert.Equal(updatedEvent.Location.City, retrievedEvent.Location.City);
            Assert.Equal(updatedEvent.Location.Country, retrievedEvent.Location.Country);
            Assert.Equal(updatedEvent.Description, retrievedEvent.Description);
            Assert.Equal(updatedEvent.FacebookEventUrl, retrievedEvent.FacebookEventUrl);
            Assert.Equal(updatedEvent.ImageUrl, retrievedEvent.ImageUrl);
        }
    }
}