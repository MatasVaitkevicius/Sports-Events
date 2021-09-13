using System.Threading.Tasks;
using VoterPoco = Events.Repository.Pocos.Voter;

namespace Events.Repository.Voter
{
    public interface IVoterRepository
    {
        Task CreateVoter(VoterPoco voter);

        Task DeleteVoter(int eventId, string userId);
    }
}