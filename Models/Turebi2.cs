using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTo.Models
{
    public class Turebi2
    {
        [Key]
        [Required]
        public int TuriId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image_name { get; set; }
    }
}
