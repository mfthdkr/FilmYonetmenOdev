using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class YonetmenModel :RecordBase
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        [MinLength(2, ErrorMessage = "{0} minimum {1} karakter olmalıdır!")]
        [MaxLength(200, ErrorMessage = "{0} maksimum {1} karakter olmalıdır!")]
        public string Adi { get; set; }


        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        [MinLength(2, ErrorMessage = "{0} minimum {1} karakter olmalıdır!")]
        [MaxLength(200, ErrorMessage = "{0} maksimum {1} karakter olmalıdır!")]
        public string Soyadi { get; set; }

        [DisplayName("Ödüller")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        [Range(0, 1000000, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır!")]
        public int? Odul { get; set; }


        [DisplayName("Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }


        [DisplayName("Doğum Tarihi")]
        public string DogumTarihiDisplay { get; set; }

        [DisplayName("Sitedeki film sayısı")]
        public int  FilmSayisiDisplay { get; set; }

    }
}
