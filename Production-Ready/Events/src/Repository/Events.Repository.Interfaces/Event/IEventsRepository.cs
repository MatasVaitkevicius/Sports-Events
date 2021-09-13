using System.Threading.Tasks;
using EventPoco = Events.Repository.Pocos.Event;

namespace Events.Repository.Event
{
    public interface IEventsRepository : IEventsReadOnlyRepository
    {
        Task<int> CreateEvent(EventPoco newEvent);

        Task UpdateEvent(int eventId, EventPoco updatedEvent);

        Task ChangeEventState(int eventId);
    }
}