using AutoMapper;
using Events.Api.Dto.Events;
using Events.Domain.Factories.Event;
using Events.Repository.Event;
using System;
using System.Linq;
using System.Threading.Tasks;
using EventDto = Events.Api.Dto.Events.Event;
using EventPoco = Events.Repository.Pocos.Event;


namespace Events.Api.Cases.Event
{
    public class EventCases : IEventCases
    {
        private readonly IEventsRepository _repository;

        private readonly IEventFactory _eventFactory;

        private readonly IMapper _mapper;

        public EventCases(IEventsRepository repository, IEventFactory eventFactory, IMapper mapper)
        {
            _repository = repository;
            _eventFactory = eventFactory;
            _mapper = mapper;
        }

        public async Task<EventDto[]> GetAllEvents()
        {
            var eventsPoco = await _repository.GetAllEvents();

            return eventsPoco.Select(eventPoco => _mapper.Map<EventPoco, EventDto>(eventPoco)).ToArray();
        }

        public async Task<EventDto[]> GetAllEventsBySearchTerm(string searchTerm)
        {
            var eventsPoco = await _repository.GetAllEventsBySearchTerm(searchTerm);

            return eventsPoco.Select(eventPoco => _mapper.Map<EventPoco, EventDto>(eventPoco)).ToArray();
        }

        public async Task<EventDto[]> GetAllEventsBySportTypeId(int sportTypeId)
        {
            var eventsPoco = await _repository.GetAllEventsBySportTypeId(sportTypeId);

            return eventsPoco.Select(eventPoco => _mapper.Map<EventPoco, EventDto>(eventPoco)).ToArray();
        }

        public async Task<EventDto> GetEventById(int id)
        {
            var eventPoco = await _repository.GetEventById(id);

            return _mapper.Map<EventPoco, EventDto>(eventPoco);
        }

        public async Task<EventDto[]> GetEventsByUserId(string userId)
        {
            var eventsPoco = await _repository.GetEventsByUserId(userId);

            return eventsPoco.Select(eventPoco => _mapper.Map<EventPoco, EventDto>(eventPoco)).ToArray();
        }

        public async Task<int> CreateEvent(NewEvent newEvent)
        {
            if (string.IsNullOrWhiteSpace(newEvent.Name))
            {
                throw new ArgumentNullException(nameof(newEvent.Name));
            }

            if (string.IsNullOrWhiteSpace(newEvent.TimeFrom))
            {
                throw new ArgumentNullException(nameof(newEvent.TimeFrom));
            }

            if (string.IsNullOrWhiteSpace(newEvent.TimeTill))
            {
                throw new ArgumentNullException(nameof(newEvent.TimeTill));
            }

            if (string.IsNullOrWhiteSpace(newEvent.PhoneNumber))
            {
                throw new ArgumentNullException(nameof(newEvent.PhoneNumber));
            }

            return await _eventFactory.CreateEvent(newEvent);
        }

        public async Task UpdateEvent(int eventId, EventUpdate eventUpdate)
        {
            await _eventFactory.CreateUpdatedEvent(eventId, eventUpdate);
        }

        public async Task ChangeEventState(int eventId)
        {
            await _repository.ChangeEventState(eventId);
        }
    }
}