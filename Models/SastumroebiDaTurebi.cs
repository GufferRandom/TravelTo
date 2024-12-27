namespace TravelTo.Models
{
    public class SastumroebiDaTurebi
    {
        public int Sastumro_Id { get; set; }
        public int Turebi_Id { get; set; }
        public Sastumroebi? Sastumroebi { get; set; }=null;
        public Turebi? Turebi { get; set; } = null;
    }
}
