using Events.Api.Dto.Voters;
using Events.Domain.Factories.Voter;
using Events.Repository.Voter;
using System.Threading.Tasks;

namespace Events.Api.Cases.Voter
{
    public class VoterCases : IVoterCases
    {
        private readonly IVoterRepository _repository;

        private readonly IVoterFactory _voterFactory;

        public VoterCases(IVoterRepository repository, IVoterFactory voterFactory)
        {
            _repository = repository;
            _voterFactory = voterFactory;
        }

        public async Task CreateVoter(NewVoter newVoter)
        {
            await _voterFactory.CreateVoter(newVoter.EventId, newVoter.UserId);
        }

        public async Task DeleteVoter(int eventId, string userId)
        {
            await _repository.DeleteVoter(eventId, userId);
        }
    }
}