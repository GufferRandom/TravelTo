using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class Turebi
    {

        [Key]
        public int id { get; set; } 
        [MaxLength(50)]
        public string Name { get; set; } 
        public double Price { get; set; }

        public string? Description { get; set; }
        public string? image_name { get; set; }
    }
}
