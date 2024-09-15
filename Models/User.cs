using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTo.Models
{
    public class User : IdentityUser
    {
        public string First_Name { get;set; }
        public string Last_Name { get;set;}
        public string City { get; set;} 
        public string Phone { get; set; }
        
        public ICollection<UserAndTurebiMap>? UserAndTurebiMapU { get; }



    }
}
