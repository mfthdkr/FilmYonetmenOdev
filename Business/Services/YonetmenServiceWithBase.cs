using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IYonetmenService : IService<YonetmenModel, Yonetmen, FilmYonetmenContext>
    {

    }
    public class YonetmenService : IYonetmenService
    {
        public RepositoryBase<Yonetmen, FilmYonetmenContext> Repository { get; set; } = new Repository<Yonetmen, FilmYonetmenContext>();

        public Result Add(YonetmenModel model)
        {
            if (Repository.Query().Any(y => y.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Aynı isimde yönetmen bulunmaktadır.");
            Yonetmen entity = new Yonetmen()
            {
                Adi = model.Adi.Trim(),
                Soyadi = model.Soyadi.Trim(),
                Odul = model.Odul.Value,
                DogumTarihi = model.DogumTarihi
            };
            Repository.Add(entity);
            return new SuccessResult("Yönetmen başarıyla eklendi");
        }

        public Result Delete(int id)
        {
            Yonetmen entity = Repository.Query(y => y.Id == id, "Filmler").SingleOrDefault();
            if(entity.Filmler !=null && entity.Filmler.Count > 0)
            {
                return new ErrorResult("Yönetmen silinemez öncelikle ilgili filmler silinmeli.");
            }
            Repository.Delete(entity);
            return new SuccessResult("Yönetmen başarıyla silindi.");
        }

        public void Dispose()
        {
            Repository.Dispose();
        }

        public IQueryable<YonetmenModel> Query()
        {
            IQueryable<YonetmenModel> query = Repository.Query("Filmler").OrderBy(y => y.Adi).Select(y => new YonetmenModel()
            {
                Id = y.Id,
                Adi = y.Adi,
                Soyadi = y.Soyadi,
                DogumTarihi = y.DogumTarihi,
                Odul = y.Odul,
                DogumTarihiDisplay = y.DogumTarihi.HasValue ? y.DogumTarihi.Value.ToString("yyyy-MM-dd") :"",
                FilmSayisiDisplay = y.Filmler.Count

            });
            return query;
        }

        public Result Update(YonetmenModel model)
        {
            if (Repository.Query().Any(y => y.Adi.ToLower() == model.Adi.ToLower().Trim() && y.Id !=model.Id ))
                return new ErrorResult("Aynı isimde yönetmen bulunmaktadır.");

            Yonetmen entity = Repository.Query().SingleOrDefault(y => y.Id == model.Id);
            entity.Adi = model.Adi.Trim();
            entity.Soyadi = model.Soyadi.Trim();
            entity.Odul = model.Odul.Value;
            entity.DogumTarihi = model.DogumTarihi;
            Repository.Update(entity);
            return new SuccessResult("Yönetmen başarıyla eklendi");
        }
    }
}
