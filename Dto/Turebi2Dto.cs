using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTo.Dto
{
    public class Turebi2Dto
    {
        [Required]
        public int TuriId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
