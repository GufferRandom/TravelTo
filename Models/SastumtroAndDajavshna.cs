using System.ComponentModel.DataAnnotations;

namespace TravelTo.Models
{
    public class SastumtroAndDajavshna
    {
        public int Sastumro_Id { get; set; }
        public int SastumroDajavshna_Id { get; set; }
        public Sastumroebi Sastumroebi { get; set; }
        public SastumroDajavshna sastumroDajavshna { get; set; }
    }
}
