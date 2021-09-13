using Events.Repository.Pocos;
using Events.TestHelpers.Data;
using System;

namespace Events.MappersTests.TestData
{
    public class EventPocoToDtoDataCollection : ClassDataBase<Event>
    {
        public EventPocoToDtoDataCollection() : base(new []
        {
            Create(1, "Event", DateTime.Now, "10", "12", 12.05, "8666566", "street", "city", "country", 
                "description", null, null, DateTime.Now, false),
            Create(2, "Eventassss", DateTime.Now, "10", "12", 1.05, "866657766", "street", "city", "country", 
                "description", null, "aasas", DateTime.Now, false),
            Create(3, "Event", DateTime.Now, "12", "16", 2.05, "8666566", "streetas", "cityas", "countsssry", 
                "description", "aasasda", null, DateTime.Now, false),
        })
        {
        }

        private static Event Create(int eventId, string name, DateTime eventData, string timeFrom, string timeTill,
            double price, string phoneNumber, string address, string city, string country, string description,
            string faceBookUrl, string imageUrl, DateTime dateUpdated, bool canceled)
        {
            return new Event
            {
                EventId = eventId,
                Name = name,
                EventDate = eventData,
                TimeFrom = timeFrom,
                TimeTill = timeTill,
                Price = price,
                PhoneNumber = phoneNumber,
                Address = address,
                City = city,
                Country = country,
                Description = description,
                FacebookEventUrl = faceBookUrl,
                ImageUrl = imageUrl,
                DateUpdated = dateUpdated,
                Canceled = canceled
            };
        }
    }
}