using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using System.Globalization;

namespace Business.Services
{   
    public interface IFilmService : IService<FilmModel, Film, FilmYonetmenContext>
    {

    }
    public class FilmService : IFilmService
    {
        public RepositoryBase<Film, FilmYonetmenContext> Repository { get; set; } = new Repository<Film, FilmYonetmenContext>();

        public Result Add(FilmModel model)
        {
            if (Repository.Query().Any(f => f.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Belirtilen film adına sahip kayıt bulunmaktadır.");

            Film entity = new Film()
            {
                Adi = model.Adi.Trim(),
                Aciklamasi = model.Aciklamasi?.Trim(),
                Hasilat = model.Hasilat.Value,
                Odul = model.Odul.Value,
                YonetmenId = model.YonetmenId.Value,
                GosterimTarihi = model.GosterimTarihi
            };
            Repository.Add(entity);
            return new SuccessResult("Film başarıyla eklendi.");
        }

        public Result Delete(int id)
        {
            Film entity = Repository.Query(f => f.Id == id).SingleOrDefault();
            Repository.Delete(entity);
            return new SuccessResult("Film başarıyla silindi");
        }

        public void Dispose()
        {
            Repository.Dispose();
        }

        public IQueryable<FilmModel> Query()
        {
            return Repository.Query("Yonetmen").OrderBy(f => f.Adi).Select(f => new FilmModel()
            {   
                Id = f.Id,
                Adi = f.Adi,
                Aciklamasi = f.Aciklamasi,
                GosterimTarihi = f.GosterimTarihi,
                Hasilat = f.Hasilat,
                Odul = f.Odul,
                YonetmenId = f.YonetmenId,
                HasilatDisplay = f.Hasilat.ToString("C2", new CultureInfo("tr-TR")),
                GosterimTarihiDisplay = f.GosterimTarihi.HasValue ? f.GosterimTarihi.Value.ToString("yyyy-MM-dd") : "",
                YonetmenAdiDisplay = f.Yonetmen.Adi + " " + f.Yonetmen.Soyadi,
                
            }); ;
        }

        public Result Update(FilmModel model)
        {
            if (Repository.Query().Any(f => f.Adi.ToUpper() == model.Adi.ToLower().Trim() && f.Id != model.Id))
                return new ErrorResult("Girdiğiniz film adına sahip kayıt bulunmaktadır.");
            Film entity = Repository.Query("Yonetmen").SingleOrDefault(f => f.Id == model.Id);
            entity.Adi= model.Adi;
            entity.Aciklamasi=model.Aciklamasi?.Trim();
            entity.Hasilat = model.Hasilat.Value;
            entity.Odul = model.Odul.Value;
            entity.YonetmenId = model.YonetmenId.Value;
            entity.GosterimTarihi = model.GosterimTarihi;
            Repository.Update(entity);
            return new SuccessResult("Film başarıyla güncellendi.");
        }
    }
}
