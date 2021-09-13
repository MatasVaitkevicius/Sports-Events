using System.Threading.Tasks;
using SportTypePoco = Events.Repository.Pocos.SportType;

namespace Events.Repository.SportType
{
    public interface ISportTypeRepository : ISportTypeReadOnlyRepository
    {
        Task AddNewSportType(SportTypePoco newSportType);
    }
}