using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class UserCookie
    {
        [Key]
        public string User_Id { get; set; }
        public DateOnly expires_in { get; set; }
        public ICollection<UserCookieTurebi>? UserCookieTurebis { get; set; }
        public ICollection<UserSastumroebiCookies>? UserSastumroebiCookies { get; set; }

    }

}
