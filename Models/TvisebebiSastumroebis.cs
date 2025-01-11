using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTo.Models
{
    public class TvisebebiSastumroebis
    {
        [Key]
        public int Tviseba_Id { get; set; }
        public string? Wifi { get; set; }
        public string? უფასო_ავტოსადგომი { get; set; }
        public string? ოთახი_არამწეველებისთვის { get; set; }
        public string? რესტორანი { get; set; }
        public string? უფასო_წყალი { get; set; }
        public string? საუნა { get; set; }
        public string? სპორტული_დარბაზი { get; set; }
        public string? ბილიარდი { get; set; }
        public string? სპა_ცენტრი { get; set; }
        public string? კინოდარბაზი { get; set; }
        public string? საკონფერენციო_დარბაზი { get; set; }
        public string? ბარი { get; set; }
        public string? საბავშო_ოთახი { get; set; }
        public string? ტერასა { get; set; }
        public string? ბაღი { get; set; }
        public string? სამრეცხაო { get; set; }
        public string? შინაური_ცხოვრების_დაშვება { get; set; }


        public Sastumroebi Sastumro { get; set; }

    
    }
}
