using Events.Api.Dto.Events;
using System.Threading.Tasks;

namespace Events.Api.Cases.Event
{
    public interface IEventCases : IEventReadOnlyCases
    {
        Task<int> CreateEvent(NewEvent newEvent);

        Task UpdateEvent(int eventId, EventUpdate eventUpdate);

        Task ChangeEventState(int eventId);
    }
}