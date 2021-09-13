using AutoMapper;
using SportTypeDto = Events.Api.Dto.SportType.SportType;
using SportTypePoco = Events.Repository.Pocos.SportType;

namespace Events.Api.Mappers.SportType
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SportTypePoco, SportTypeDto>();
        }
    }
}