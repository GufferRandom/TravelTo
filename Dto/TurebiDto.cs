using System.ComponentModel.DataAnnotations;

namespace TravelTo.Dto
{
    public class TurebiDto
    {


        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

        public string? Description { get; set; }
        public IFormFile? image { get; set; }
    }
}
