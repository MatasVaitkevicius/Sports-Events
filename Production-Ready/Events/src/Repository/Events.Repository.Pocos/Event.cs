using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Repository.Pocos
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

        public string TimeFrom { get; set; }

        public string TimeTill { get; set; }

        public double Price { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public string FacebookEventUrl { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool Canceled { get; set; }

        public string UserId { get; set; }

        #region Dependencies

        public int SportTypeId { get; set; }

        public SportType SportType { get; set; }

        public List<Voter> Voters { get; set; }

        #endregion
    }
}