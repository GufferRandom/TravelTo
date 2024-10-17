using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelTo.Models
{
    public class Sastumroebi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(10,10000)]

        public int Fasi { get; set; }

        [Required]
        [MinLength(40,ErrorMessage ="The Lenght is too short ")]
        public string Description {  get; set; }
        [Required]
        public string gmail { get; set; }
        [Required]
        public string Lokacia { get; set; }
        public string? Nomer {  get; set; }
        public string? Owner { get; set; }
       
        public int Tvisebebis_Sastumroebis_Id { get; set; }
        [ForeignKey("Tvisebebis_Sastumroebis_Id")]
        public List<TvisebebiSastumroebis> Tvisebebis_Sastumroebi {  get; set; }
    }
}
