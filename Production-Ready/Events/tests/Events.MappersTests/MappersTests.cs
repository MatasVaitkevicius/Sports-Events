using AutoMapper;
using Events.MappersTests.TestData;
using Events.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EventDto = Events.Api.Dto.Events.Event;
using EventPoco = Events.Repository.Pocos.Event;
using SportTypeDto = Events.Api.Dto.SportType.SportType;
using SportTypePoco = Events.Repository.Pocos.SportType;
using UserDto = Events.Api.Dto.Users.User;
using UserPoco = Events.Repository.Pocos.User;
using VoterDto = Events.Api.Dto.Voters.Voter;
using VoterPoco = Events.Repository.Pocos.Voter;

namespace Events.MappersTests
{
    public class MappersTests
    {
        [Theory, ClassData(typeof(EventPocoToDtoDataCollection))]
        public void ItChecksIf_EventPocoIsMappedToDtoCorrectly(EventPoco eventPoco)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var mapper = iocContainer.GetService<IMapper>();

            // Act:

            var mappedDto = mapper.Map<EventPoco, EventDto>(eventPoco);

            // Assert:

            Assert.Equal(eventPoco.EventId, mappedDto.EventId);
            Assert.Equal(eventPoco.Name, mappedDto.Name);
            Assert.Equal(eventPoco.EventDate, mappedDto.EventDate);
            Assert.Equal(eventPoco.TimeFrom, mappedDto.TimeFrom);
            Assert.Equal(eventPoco.TimeTill, mappedDto.TimeTill);
            Assert.Equal(eventPoco.Price, mappedDto.Price);
            Assert.Equal(eventPoco.PhoneNumber, mappedDto.PhoneNumber);
            Assert.Equal(eventPoco.Address, mappedDto.Location.Address);
            Assert.Equal(eventPoco.City, mappedDto.Location.City);
            Assert.Equal(eventPoco.Country, mappedDto.Location.Country);
            Assert.Equal(eventPoco.Description, mappedDto.Description);
            Assert.Equal(eventPoco.FacebookEventUrl, mappedDto.FacebookEventUrl);
            Assert.Equal(eventPoco.ImageUrl, mappedDto.ImageUrl);
        }

        [Theory, ClassData(typeof(SportTypePocoToDtoCollection))]
        public void ItChecksIf_SportTypePocoIsMappedToDtoCorrectly(SportTypePoco sportTypePoco)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var mapper = iocContainer.GetService<IMapper>();

            // Act:

            var mappedDto = mapper.Map<SportTypePoco, SportTypeDto>(sportTypePoco);

            // Assert:

            Assert.Equal(sportTypePoco.SportTypeId, mappedDto.SportTypeId);
            Assert.Equal(sportTypePoco.Name, mappedDto.Name);
        }

        [Theory, ClassData(typeof(UserPocoToDtoDataCollection))]
        public void ItChecksIf_UserPocoIsMappedToDtoCorrectly(UserPoco userPoco)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var mapper = iocContainer.GetService<IMapper>();

            // Act:

            var mappedDto = mapper.Map<UserPoco, UserDto>(userPoco);

            // Assert:

            Assert.Equal(userPoco.UserId, mappedDto.UserId);
            Assert.Equal(userPoco.UserName, mappedDto.UserName);
            Assert.Equal(userPoco.Email, mappedDto.Email);
            Assert.Equal(userPoco.FirstName, mappedDto.FirstName);
            Assert.Equal(userPoco.LastName, mappedDto.LastName);
            Assert.Equal(userPoco.Password, mappedDto.Password);
        }

        [Theory, ClassData(typeof(VoterPocoToDtoDataCollection))]
        public void ItChecksIf_VoterIsMappedToDtoCorrectly(VoterPoco voterPoco)
        {
            // Prepare:

            var iocContainer = DependencyInjectionHelper.CreateAndConfigureContainer();

            var mapper = iocContainer.GetService<IMapper>();

            // Act:

            var mappedDto = mapper.Map<VoterPoco, VoterDto>(voterPoco);

            // Assert:

            Assert.Equal(voterPoco.UserId, mappedDto.UserId);
            Assert.Equal(voterPoco.EventId, mappedDto.EventId);
        }
    }
}