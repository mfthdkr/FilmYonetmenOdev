using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class FilmModel :RecordBase
    {
        [Required(ErrorMessage = "{0} gereklidir!")]
        [MinLength(2, ErrorMessage = "{0} minimum {1} karakter olmalıdır!")]
        [MaxLength(200, ErrorMessage = "{0} maksimum {1} karakter olmalıdır!")]
        [DisplayName("Film Adı")]
        public string Adi { get; set; }



        [StringLength(500, ErrorMessage = "{0} maksimum {1} karakter olmalıdır!")]
        [DisplayName("Özet")]
        public string Aciklamasi { get; set; }



        [DisplayName("Hasılat")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır!")]
        public double? Hasilat { get; set; }



        [DisplayName("Ödüller")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        [Range(0, 1000000, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır!")]
        public int? Odul { get; set; }



        [DisplayName("Gösterim Tarihi")]
        
        public DateTime? GosterimTarihi { get; set; }



        [DisplayName("Yönetmen Adı")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        public int? YonetmenId { get; set; }




        // Viewlar için oluşturulan propertyler


        [DisplayName("Hasılat")]
        public string HasilatDisplay { get; set; }



        [DisplayName("Gösterim Tarihi")]
        public string GosterimTarihiDisplay { get; set; }

        [DisplayName("Yönetmen Adı")]
        public string YonetmenAdiDisplay { get; set; }


    }
}
