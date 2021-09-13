using Events.Api.Dto.Events;
using Events.Api.Dto.Users;
using Events.Constants.Constants;
using Events.TestHelpers.Data;
using System;

namespace Events.EventRepositoryCasesTests.EventsCases.TestData
{
    public class EventsUpdateDataCollection : ClassDataBase<NewUser, NewEvent, EventUpdate>
    {
        public EventsUpdateDataCollection() :
            base(new[]
            {
                Create("username", "email", "firstname", "latname", "paswrd", "Event", DateTime.Now, "10", "12", 12.05,
                    "8666566", "street", "city", "country", "description", null, null, 1, 1, "Eventas", DateTime.Now,
                    "10", "12", 12.05,
                    "8666566", "streetas", "cityas", "countryas", "descriptionas", null, "http://image", 1),
                Create("username", "email", "firstname", "latname", "paswrd", "Event", DateTime.Now, "10", "12", 12.05,
                    "8666566", "street", "city", "country", "description", null, null, 1, 1, "Eventas", DateTime.Now,
                    "10", "12", 12.05,
                    "8666566", "streetas", "cityas", "countryas", "descriptionasass", null, "http://image", 1),
                Create("username", "email", "firstname", "latname", "paswrd", "Event", DateTime.Now, "10", "12", 12.05,
                    "8666566", "street", "city", "country", "description", null, null, 1, 1, "Eventas", DateTime.Now,
                    "10", "12", 12.05,
                    "866656as6", "streets", "citysssas", "countryas", "descriptionas", null, "http://image", 1),
            })
        {
        }

        private static Tuple<NewUser, NewEvent, EventUpdate> Create(string username, string email, string firstName,
            string lastName, string password, string name, DateTime eventDate, string timeFrom, string timeTill,
            double price, string phoneNumber, string address, string city, string country, string description, 
            string facebookEventUrl, string imageUrl, int userId, int sportTypeId, string uName, DateTime uEventData, 
            string uTimeFrom, string uTimeTill, double uPrice, string uPhoneNumber, string uAddress,
            string uCity, string uCountry, string uDescription, string uFacebookUrl, string uImageUrl, int uSportTypeId)
        {
            return new Tuple<NewUser, NewEvent, EventUpdate>(
                new NewUser
                {
                    UserName = username,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password
                },
                new NewEvent
                {
                    Name = name,
                    EventDate = eventDate,
                    TimeFrom = timeFrom,
                    TimeTill = timeTill,
                    Price = price,
                    PhoneNumber = phoneNumber,
                    Location = new Location
                    {
                        Address = address,
                        City = city,
                        Country = country
                    },
                    Description = description,
                    FacebookEventUrl = facebookEventUrl,
                    ImageUrl = imageUrl,
                    UserId = userId,
                    SportTypeId = sportTypeId
                },
                new EventUpdate
                {
                    Name = uName,
                    EventDate = uEventData,
                    TimeFrom = uTimeFrom,
                    TimeTill = uTimeTill,
                    Price = uPrice,
                    PhoneNumber = uPhoneNumber,
                    Location = new Location
                    {
                        Address = uAddress,
                        City = uCity,
                        Country = uCountry
                    },
                    Description = uDescription,
                    FacebookEventUrl = uFacebookUrl,
                    ImageUrl = uImageUrl,
                    SportTypeId = uSportTypeId
                });
        }
    }
}