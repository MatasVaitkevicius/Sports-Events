using Events.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SportTypePoco = Events.Repository.Pocos.SportType;

namespace Events.Repository.SportType
{
    public class SportTypeRepository : ISportTypeRepository
    {
        private readonly EventsDbContext _db;

        public SportTypeRepository(EventsDbContext db)
        {
            _db = db;
        }

        public async Task<SportTypePoco> GetSportTypeById(int id)
        {
            return await _db.SportTypes.SingleOrDefaultAsync(e => e.SportTypeId == id);
        }

        public async Task<SportTypePoco[]> GetAllSportTypes()
        {
            return await _db.SportTypes.Select(e => e).ToArrayAsync();
        }

        public async Task AddNewSportType(SportTypePoco newSportType)
        {
            await _db.SportTypes.AddAsync(newSportType);

            await _db.SaveChangesAsync();
        }

    }
}