using System.Threading.Tasks;
using EventPoco = Events.Repository.Pocos.Event;

namespace Events.Repository.Event
{
    public interface IEventsReadOnlyRepository
    {
        Task<EventPoco[]> GetAllEvents();

        Task<EventPoco[]> GetAllEventsBySearchTerm(string searchTerm);

        Task<EventPoco[]> GetAllEventsBySportTypeId(int sportTypeId);

        Task<EventPoco> GetEventById(int id);

        Task<EventPoco[]> GetEventsByUserId(string userId);
    }
}