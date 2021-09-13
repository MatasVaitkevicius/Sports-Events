using System.ComponentModel.DataAnnotations;

namespace Events.Repository.Pocos
{
    public class Voter
    {
        [Key]
        public int VoterId { get; set; }

        public string UserId { get; set; }

        #region Dependencies

        public int EventId { get; set; }

        public Event Event { get; set; }

        #endregion
    }
}