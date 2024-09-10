using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTo.Models
{
    public class Turebi
    {

        [Key]
        public int id { get; set; } 
        [MaxLength(50)]
        public string Name { get; set; }
        
        public double Price { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public string? image_name { get; set; }
        public int Company_Id { get; set; }
        [ForeignKey("Company_Id")]
        public Company Company { get;set; }
    }
}
