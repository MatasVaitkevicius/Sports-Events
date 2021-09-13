using Events.Api.Dto.Voters;
using System.Threading.Tasks;

namespace Events.Api.Cases.Voter
{
    public interface IVoterCases
    {
        Task CreateVoter(NewVoter newVoter);

        Task DeleteVoter(int eventId, string userId);
    }
}