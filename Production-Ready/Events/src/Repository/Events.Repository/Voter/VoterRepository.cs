using Events.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VoterPoco = Events.Repository.Pocos.Voter;

namespace Events.Repository.Voter
{
    public class VoterRepository : IVoterRepository
    {
        private readonly EventsDbContext _db;

        public VoterRepository(EventsDbContext db)
        {
            _db = db;
        }

        public async Task CreateVoter(VoterPoco voter)
        {
            await _db.Voters.AddAsync(voter);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteVoter(int eventId, string userId)
        {
            var voter = await _db.Voters.
                FirstOrDefaultAsync(v => v.EventId == eventId && v.UserId == userId);

            _db.Remove(voter);

            await _db.SaveChangesAsync();
        }
    }
}