using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class User : IdentityUser
    {
        public string First_Name { get;set; }
        public string Last_Name { get;set;}
        public string City { get; set;} 
        public string Phone { get; set; }

    }
}
