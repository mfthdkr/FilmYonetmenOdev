using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Film :RecordBase
    {   
        [Required]
        [StringLength(200)]
        public string Adi { get; set; }
        [StringLength(2000)]
        public string Aciklamasi { get; set; }
        public double Hasilat { get; set; }
        public int? Odul { get; set; }
        public DateTime? GosterimTarihi { get; set; }
        public int YonetmenId { get; set; }
        public Yonetmen Yonetmen { get; set; }
    }
}
