using Events.Repository.Voter;
using System.Threading.Tasks;
using VoterPoco = Events.Repository.Pocos.Voter;

namespace Events.Domain.Factories.Voter
{
    public class VoterFactory : IVoterFactory
    {
        private readonly IVoterRepository _repository;

        public VoterFactory(IVoterRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateVoter(int eventId, string userId)
        {
            var voterPoco = new VoterPoco
            {
                EventId = eventId,
                UserId = userId
            };

            await _repository.CreateVoter(voterPoco);
        }
    }
}