namespace TravelTo.Models
{
    public class UserAndTurebiMap
    {
        public string? User_Id{ get; set; }
        public int? Turebi_Id{ get; set; }
        public Turebi? turebi { get; set; }
        public User? User { get; set; }
    }
}
