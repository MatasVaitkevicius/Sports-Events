using System.Threading.Tasks;
using SportTypeDto = Events.Api.Dto.SportType.SportType;

namespace Events.Api.Cases.SportType
{
    public interface ISportTypeReadOnlyCases
    {
        Task<SportTypeDto[]> GetAllSportTypes();

        Task<SportTypeDto> GetSportTypeById(int id);
    }
}
