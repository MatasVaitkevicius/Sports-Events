using AutoMapper;
using VoterDto = Events.Api.Dto.Voters.Voter;
using VoterPoco = Events.Repository.Pocos.Voter;

namespace Events.Api.Mappers.Voter
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VoterPoco, VoterDto>();            
        }
    }
}