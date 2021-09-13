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
    public class EventsFieldsPopulationTests
    {
        [Theory, ClassData(typeof(EventsValidationDataCollection))]
        public async void ItHasTheSameData_WhenEventIsCreated(NewUser newUser, NewEvent newEvent)
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

            var retrievedEvent =  await eventCases.GetEventById(eventId);

            Assert.Equal(newEvent.Name, retrievedEvent.Name);
            Assert.Equal(newEvent.EventDate, retrievedEvent.EventDate);
            Assert.Equal(newEvent.TimeFrom, retrievedEvent.TimeFrom);
            Assert.Equal(newEvent.TimeTill, retrievedEvent.TimeTill);
            Assert.Equal(newEvent.Price, retrievedEvent.Price);
            Assert.Equal(newEvent.PhoneNumber, retrievedEvent.PhoneNumber);
            Assert.Equal(newEvent.Location.Address, retrievedEvent.Location.Address);
            Assert.Equal(newEvent.Location.City, retrievedEvent.Location.City);
            Assert.Equal(newEvent.Location.Country, retrievedEvent.Location.Country);
            Assert.Equal(newEvent.Description, retrievedEvent.Description);
            Assert.Equal(newEvent.FacebookEventUrl, retrievedEvent.FacebookEventUrl);
            Assert.Equal(newEvent.ImageUrl, retrievedEvent.ImageUrl);
        }

        [Theory, ClassData(typeof(EventsValidationDataCollection))]
        public async void ItsFieldCancelHasChanged_WhenMethodIsCalled(NewUser newUser, NewEvent newEvent)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var userCases = iocContainer.GetService<IUserCases>();

            var eventCases = iocContainer.GetService<IEventCases>();

            // Act:

            var userId = await userCases.CreateUser(newUser);

            newEvent.UserId = userId;

            var eventId = await eventCases.CreateEvent(newEvent);

            var oldRetrievedEvent = await eventCases.GetEventById(eventId);

            await eventCases.ChangeEventState(eventId);

            var newRetrievedEvent = await eventCases.GetEventById(eventId);

            // Assert:

            Assert.NotEqual(oldRetrievedEvent.Canceled, newRetrievedEvent.Canceled);
        }
    }
}