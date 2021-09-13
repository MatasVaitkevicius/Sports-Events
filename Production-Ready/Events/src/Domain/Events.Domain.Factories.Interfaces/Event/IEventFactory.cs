using Events.Api.Dto.Events;
using System.Threading.Tasks;

namespace Events.Domain.Factories.Event
{
    public interface IEventFactory
    {
        Task<int> CreateEvent(NewEvent newEvent);

        Task CreateUpdatedEvent(int eventId, EventUpdate updateEvent);
    }
}