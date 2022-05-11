using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;

namespace MvcWebUI.Controllers
{
    public class FilmlerController : Controller
    {
       
        private readonly IFilmService _filmService;
        private readonly IYonetmenService _yonetmenService;
        public FilmlerController(IFilmService filmService,IYonetmenService yonetmenService)
        {
            _filmService= filmService;
            _yonetmenService = yonetmenService;
        }

        
        public IActionResult Index()
        {
            var model = _filmService.Query().ToList();
            return View(model); 
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return View("Hata", "Id gereklidir");
            FilmModel model = _filmService.Query().SingleOrDefault(f => f.Id == id);
            if (model == null)
                return View("Hata", "Film bulunamadı.");
            return View(model);
        }
        // GET: Filmler/Create
        public IActionResult Create()
        {
            ViewData["YonetmenId"] = new SelectList(_yonetmenService.Query().ToList(), "Id", "Adi");
            FilmModel model = new FilmModel()
            {
                GosterimTarihi = DateTime.Now
            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FilmModel film)
        {
            if (ModelState.IsValid)
            {
                var result = _filmService.Add(film);
                if (result.IsSuccessful)
                {
                    TempData["Mesaj"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            ViewData["YonetmenId"] = new SelectList(_yonetmenService.Query().ToList(), "Id", "Adi", film.YonetmenId);
            return View(film);
        }

        public IActionResult Edit(int? id)
        {
            if(id== null)
                return View("Hata","Id gereklidir.");
            ViewData["YonetmenId"] = new SelectList(_yonetmenService.Query().ToList(), "Id", "Adi");
            FilmModel model = _filmService.Query().SingleOrDefault(f => f.Id == id);
            if (model == null)
                return View("Hata", "Film  bulunamadı.");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FilmModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _filmService.Update(model);
                if (result.IsSuccessful)
                    TempData["Mesaj"] = result.Message;
                return RedirectToAction(nameof(Index));
                
            }
            ViewData["YonetmenId"] = new SelectList(_yonetmenService.Query().ToList(), "Id", "Adi", model.YonetmenId);
            
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return View("Hata", "Id gereklidir");
            Result result = _filmService.Delete(id.Value);
            TempData["Mesaj"]= result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
