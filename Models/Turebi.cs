using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
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
        [MaxLength(1000)]
        public string? Description { get; set; }
        public string? image_name { get; set; }
        public int? Company_Id { get; set; }
        [ForeignKey("Company_Id")]
        public Company? Company { get; set; }
        public ICollection<UserAndTurebiMap>? UserAndTurebiMapT { get; }
        public ICollection<SastumroebiDaTurebi>? Sastumroebi { get; set; }
        public ICollection<UserCookieTurebi>? UserCookieTurebi { get; set; }
    }
}
