using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelTo.Models
{
    public class TvisebebiSastumroebis
    {
        [Key]
        public int Tviseba_Id { get; set; }
        public string? Wifi {  get; set; }
        public string? Ufaso_avtosadgomi {  get; set; }
        public string? otaxi_aramweveltaTvis{get; set; }
        public string? resotrani{  get; set; }
        public string? daxuruli_auzi{  get; set; }
        public string? sauna{  get; set; }
        public string? sportdarbazi{ get; set; }
        public string? sabiliardo{ get; set; }
        public string? spa_centri{  get; set; }
        public string? kino_darbasi{  get; set; }
        public string? sakonferencio_darbazi{  get; set; }
        public string? bari{get; set; }
        public string? sabavsho_otaxi{  get; set; }
        public string? terasa{  get; set; }
        public string? bagi{  get; set; }
        public string? samrecxao{  get; set; }
        public string? Shinauri_cxovelebis_dashveba{  get; set; }

        public Sastumroebi Sastumro{ get; set; }
    
    }
}
