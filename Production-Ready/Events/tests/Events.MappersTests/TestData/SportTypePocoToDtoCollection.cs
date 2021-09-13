using Events.Repository.Pocos;
using Events.TestHelpers.Data;

namespace Events.MappersTests.TestData
{
    public class SportTypePocoToDtoCollection : ClassDataBase<SportType>
    {
        public SportTypePocoToDtoCollection() : 
            base(new []
            {
                Create(1, "Tennis"),
                Create(2, "Basketball"),
                Create(3, "Baseball"),
            })
        {
        }

        private static SportType Create(int sportTypeId, string name)
        {
            return new SportType
            {
                SportTypeId = sportTypeId,
                Name = name
            };
        }
    }
}