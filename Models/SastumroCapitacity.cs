using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTo.Models
{
    public class SastumroCapitacity
    {
        [Key]
        public int Id { get; set; }
        public int? Sastumro_Id { get; set; }
        public int? MaxCapitacity { get; set; } 
        public int? CurrentCapacity { get; set; }
        public Sastumroebi? Sastumroebi { get; set; }
    }
}
