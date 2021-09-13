using Events.Api.Cases.Event;
using Events.Api.Cases.Users;
using Events.Api.Dto.Events;
using Events.Api.Dto.Users;
using Events.EventRepositoryCasesTests.EventsCases.TestData;
using Events.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Events.EventRepositoryCasesTests.EventsCases
{
    public class EventsFieldsValidityTests
    {
        [Theory, ClassData(typeof(EventsInvalidDataCollection))]
        public async void ItThrowsArgumentNullException_WhenEventIsCreated(NewUser newUser, NewEvent newEvent)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var userCases = iocContainer.GetService<IUserCases>();

            var eventCases = iocContainer.GetService<IEventCases>();

            // Act:

            var userId = await userCases.CreateUser(newUser);

            newEvent.UserId = userId;

            // Assert:

            await Assert.ThrowsAsync<ArgumentNullException>(async () => 
                await eventCases.CreateEvent(newEvent));
        }
    }
}