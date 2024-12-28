using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class SastumroDajavshna
    {
        [Required]
        [MinLength(3,ErrorMessage ="Too small for first_name")]
        [MaxLength(10,ErrorMessage ="Too large for first_name")]
        public string First_Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Too small for last_name")]
        [MaxLength(30, ErrorMessage = "Too large for last_name")]
        public string Last_Name { get; set; }
        [Required]
        [Phone(ErrorMessage ="Invalid Phone number")]
        public string Phone_Number { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string gmail { get; set; }
        [MaxLength(1500,ErrorMessage ="Too Large ")]
        public string? text { get; set; }
    }
}
