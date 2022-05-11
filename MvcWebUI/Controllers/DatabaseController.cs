using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;


namespace MvcWebUI.Controllers
{   
    // Örnek veri yüklemesi için oluşturuldu.
    // Repository design pattern kullanılmadı. Doğrudan DbContext üzerinden işlem yapıldı.
    public class DatabaseController : Controller
    {   
        public IActionResult Seed() // ~Database/Seed 
        {   
            
            using (FilmYonetmenContext db = new FilmYonetmenContext())
            {   
                var filmEntities =db.Filmler.ToList();
                db.RemoveRange(filmEntities);

                var yonetmenEntities = db.Yonetmenler.ToList();
                db.RemoveRange(yonetmenEntities);


                db.Yonetmenler.Add(new Yonetmen()
                {
                    Adi= "Quentin",
                    Soyadi = "Tarantino",
                    Odul = 172,
                    DogumTarihi=DateTime.Parse("27.03.1963" ,new CultureInfo("tr-TR")),
                    Filmler = new List<Film>()
                    {
                        new Film()
                        {
                            Adi = "Rezervuar Köpekleri",
                            Aciklamasi= "Basit bir mücevher soygunu korkunç bir şekilde ters gider ve hayatta kalan suçlular içlerinden birinin polis muhbiri olduğundan şüphelenmeye başlar.",
                            GosterimTarihi = DateTime.Parse("21.05.1993", new CultureInfo("tr-TR")),
                            Odul = 12,
                            Hasilat = 2832029,
                        },
                        new Film()
                        {
                            Adi = "Ucuz Roman",
                            Aciklamasi= "İki mafya tetikçisi, bir boksör, bir gangster ve karısı ve bir çift lokanta haydutunun hayatları, dört şiddet ve kurtuluş hikayesinde iç içe geçiyor.",
                            GosterimTarihi = DateTime.Parse("14.04.1995", new CultureInfo("tr-TR")),
                            Odul = 70,
                            Hasilat = 214179088,
                        }
                    }
                });
                db.Yonetmenler.Add(new Yonetmen()
                {
                    Adi = "Zeki",
                    Soyadi = "Demirkubuz",
                    Odul = 41
                });
                db.Yonetmenler.Add(new Yonetmen()
                {
                    Adi = "Nuri Bilge",
                    Soyadi ="Ceylan",
                    Odul =92,
                    DogumTarihi=DateTime.Parse("26.01.1959", new CultureInfo("tr-TR")),
                    Filmler = new List<Film>()
                    {
                        new Film()
                        {
                            Adi ="Bir Zamanlar Anadolu'da",
                            Aciklamasi ="Anadolu bozkırlarında bir ceset aramak için bir grup adam yola çıkar.",
                            Odul=21,
                            GosterimTarihi= DateTime.Parse("23-09-2011", new CultureInfo("tr-TR")),
                            Hasilat= 1599541

                        }
                    }
                });
                
                db.SaveChanges();
            }

            TempData["Mesaj"] = "İlk veriler başarıyla oluşturuldu";
            return RedirectToAction("Index", "Home", new { area = "" });
            

        }
    }
}
