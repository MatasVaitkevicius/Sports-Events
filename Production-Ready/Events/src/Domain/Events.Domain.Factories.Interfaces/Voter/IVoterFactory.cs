using System.Threading.Tasks;

namespace Events.Domain.Factories.Voter
{
    public interface IVoterFactory
    {
        Task CreateVoter(int eventId, string userId);
    }
}