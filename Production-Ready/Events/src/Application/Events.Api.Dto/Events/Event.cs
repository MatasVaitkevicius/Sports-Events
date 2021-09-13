using Events.Api.Dto.Voters;
using Events.Constants.Constants;
using System;
using System.Collections.Generic;

namespace Events.Api.Dto.Events
{
    public class Event
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

        public string TimeFrom { get; set; }

        public string TimeTill { get; set; }

        public double Price { get; set; }

        public string PhoneNumber { get; set; }

        public Location Location { get; set; }

        public string Description { get; set; }

        public string FacebookEventUrl { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateUpdated { get; set; }

        public string UserId { get; set; }

        public int SportTypeId { get; set; }

        public List<Voter> Voters { get; set; }

        public bool Canceled { get; set; }
    }
}