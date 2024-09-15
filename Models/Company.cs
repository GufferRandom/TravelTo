using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class Company
    {
        [Key]
        public int Company_Id { get;set; }
        public string Name { get;set; }
        public string? description{ get;set; }
        public string? owner { get; set; }   

        public ICollection<Turebi> Turebi{ get; set; }

    }
}
