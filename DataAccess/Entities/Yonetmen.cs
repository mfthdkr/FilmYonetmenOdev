using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Yonetmen :RecordBase
    {   
        [Required]
        [StringLength(200)]
        public string Adi { get; set; }
        [Required]
        [StringLength(200)]
        public string Soyadi { get; set; }
        public int? Odul { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public List<Film> Filmler { get; set; }

    }
}
