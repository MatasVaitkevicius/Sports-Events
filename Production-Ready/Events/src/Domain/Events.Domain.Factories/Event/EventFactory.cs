using Events.Api.Dto.Events;
using Events.Repository.Event;
using System;
using System.Threading.Tasks;
using EventPoco = Events.Repository.Pocos.Event;

namespace Events.Domain.Factories.Event
{
    public class EventFactory : IEventFactory
    {
        private readonly IEventsRepository _repository;

        public EventFactory(IEventsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateEvent(NewEvent newEvent)
        {
            var eventPoco = new EventPoco
            {
                Name = newEvent.Name,
                EventDate = newEvent.EventDate,
                TimeFrom = newEvent.TimeFrom,
                TimeTill = newEvent.TimeTill,
                Price = newEvent.Price,
                PhoneNumber = newEvent.PhoneNumber,
                Address = newEvent.Location.Address,
                City = newEvent.Location.City,
                Country = newEvent.Location.Country,
                Description = newEvent.Description,
                FacebookEventUrl = newEvent.FacebookEventUrl,
                ImageUrl = newEvent.ImageUrl,
                DateUpdated = DateTime.Now,
                UserId = newEvent.UserId,
                SportTypeId = newEvent.SportTypeId,
                Canceled = false
            };

            return await _repository.CreateEvent(eventPoco);
        }

        public async Task CreateUpdatedEvent(int eventId, EventUpdate updateEvent)
        {
            var updatedEventPoco = new EventPoco
            {
                Name = updateEvent.Name,
                EventDate = updateEvent.EventDate,
                TimeFrom = updateEvent.TimeFrom,
                TimeTill = updateEvent.TimeTill,
                Price = updateEvent.Price,
                PhoneNumber = updateEvent.PhoneNumber,
                Address = updateEvent.Location.Address,
                City = updateEvent.Location.City,
                Country = updateEvent.Location.Country,
                Description = updateEvent.Description,
                FacebookEventUrl = updateEvent.FacebookEventUrl,
                ImageUrl = updateEvent.ImageUrl,
                DateUpdated = DateTime.Now,
                SportTypeId = updateEvent.SportTypeId
            };

            await _repository.UpdateEvent(eventId, updatedEventPoco);
        }
    }
}