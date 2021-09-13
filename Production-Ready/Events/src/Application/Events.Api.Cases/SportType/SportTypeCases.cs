using AutoMapper;
using Events.Repository.SportType;
using System.Linq;
using System.Threading.Tasks;
using SportTypeDto = Events.Api.Dto.SportType.SportType;
using SportTypePoco = Events.Repository.Pocos.SportType;

namespace Events.Api.Cases.SportType
{
    public class SportTypeCases : ISportTypeReadOnlyCases
    {
        private readonly ISportTypeRepository _repository;

        private readonly IMapper _mapper;

        public SportTypeCases(ISportTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SportTypeDto[]> GetAllSportTypes()
        {
            var sportTypePoco = await _repository.GetAllSportTypes();

            return sportTypePoco.Select(eventPoco => _mapper.Map<SportTypePoco, SportTypeDto>(eventPoco)).ToArray();
        }

        public async Task<SportTypeDto> GetSportTypeById(int id)
        {
            var sportTypePoco = await _repository.GetSportTypeById(id);

            return _mapper.Map<SportTypePoco, SportTypeDto>(sportTypePoco);
        }
    }
}
