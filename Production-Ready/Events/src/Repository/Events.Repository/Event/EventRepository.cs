using Events.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EventPoco = Events.Repository.Pocos.Event;

namespace Events.Repository.Event
{
    public class EventRepository : IEventsRepository
    {
        private readonly EventsDbContext _db;

        public EventRepository(EventsDbContext db)
        {
            _db = db;
        }

        public async Task<EventPoco[]> GetAllEvents()
        {
            return await _db.Events
                .Select(e => e)
                .Include(v => v.Voters)
                .ToArrayAsync();
        }

        public async Task<EventPoco[]> GetAllEventsBySearchTerm(string searchTerm)
        {
            return await _db.Events
                .Where(e => e.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToArrayAsync();
        }

        public async Task<EventPoco[]> GetAllEventsBySportTypeId(int sportTypeId)
        {
            return await _db.Events
                .Where(e => e.SportTypeId == sportTypeId)
                .ToArrayAsync();
        }

        public async Task<EventPoco> GetEventById(int id)
        {
            return await _db.Events.Include(v => v.Voters).SingleOrDefaultAsync(e => e.EventId == id);
        }

        public async Task<EventPoco[]> GetEventsByUserId(string userId)
        {
            return await _db.Events.Select(e => e).Where(e => e.UserId == userId).Include(e => e.Voters).ToArrayAsync();
        }

        public async Task<int> CreateEvent(EventPoco newEvent)
        {
            await _db.Events.AddAsync(newEvent);

            await _db.SaveChangesAsync();

            return newEvent.EventId;
        }

        public async Task UpdateEvent(int eventId, EventPoco updatedEvent)
        {
            var oldEvent = await _db.Events.FirstOrDefaultAsync(e => e.EventId == eventId);

            oldEvent.Name =  updatedEvent.Name;
            oldEvent.EventDate =  updatedEvent.EventDate;
            oldEvent.TimeFrom =  updatedEvent.TimeFrom;
            oldEvent.TimeTill =  updatedEvent.TimeTill;
            oldEvent.Price =  updatedEvent.Price;
            oldEvent.PhoneNumber =  updatedEvent.PhoneNumber;
            oldEvent.Address =  updatedEvent.Address;
            oldEvent.Country =  updatedEvent.Country;
            oldEvent.City =  updatedEvent.City;
            oldEvent.Description =  updatedEvent.Description;
            oldEvent.FacebookEventUrl = updatedEvent.FacebookEventUrl;
            oldEvent.ImageUrl =  updatedEvent.ImageUrl;
            oldEvent.SportTypeId =  updatedEvent.SportTypeId;
            oldEvent.DateUpdated =  updatedEvent.DateUpdated;

            _db.Events.Update(oldEvent);

            await _db.SaveChangesAsync();
        }

        public async Task ChangeEventState(int eventId)
        {
            var oldEvent = await _db.Events.FirstOrDefaultAsync(e => e.EventId == eventId);

            oldEvent.Canceled = !oldEvent.Canceled;

            _db.Events.Update(oldEvent);

            await _db.SaveChangesAsync();
        }
    }
}