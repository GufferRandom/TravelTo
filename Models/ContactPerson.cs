using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class ContactPerson
    {
        [Key]
        public int Id { get; set; }
        [Required]
		[MaxLength(50, ErrorMessage = "Too long to process ")]
		public string First_Name { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Too long to process ")]
        public string Last_Name{ get; set; }
        [Required]
        [MaxLength(12,ErrorMessage="The max is 12")]
        public string Telephoni{ get; set; }
        [Required]
        
        public string gmail { get; set; }
		[MaxLength(1000, ErrorMessage = "Too long to process ")]
        public string? Messege { get; set; }
    }
}
