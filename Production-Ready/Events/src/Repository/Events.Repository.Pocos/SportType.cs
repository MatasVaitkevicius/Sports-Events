using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Repository.Pocos
{
    public class SportType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SportTypeId { get; set; }

        public string Name { get; set; }

        #region Dependencies

        public List<Event> Events { get; set; }

        #endregion
    }
}