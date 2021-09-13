using Events.Repository.Pocos;
using Events.TestHelpers.Data;

namespace Events.MappersTests.TestData
{
    public class VoterPocoToDtoDataCollection : ClassDataBase<Voter>
    {
        public VoterPocoToDtoDataCollection() :
            base(new[]
            {
                Create(1, 2),
                Create(2, 3),
                Create(3, 1),
            })
        {
        }

        private static Voter Create(int voterId, int eventId)
        {
            return new Voter
            {
                VoterId = voterId,
                EventId = eventId
            };
        }
    }
}