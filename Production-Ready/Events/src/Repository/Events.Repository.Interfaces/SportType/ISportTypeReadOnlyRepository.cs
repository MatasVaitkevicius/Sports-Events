using System.Threading.Tasks;
using SportTypePoco = Events.Repository.Pocos.SportType;

namespace Events.Repository.SportType
{
    public interface ISportTypeReadOnlyRepository
    {
        Task<SportTypePoco> GetSportTypeById(int id);

        Task<SportTypePoco[]> GetAllSportTypes();
    }
}