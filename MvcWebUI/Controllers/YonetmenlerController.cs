using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class YonetmenlerController : Controller
    {
        private readonly IYonetmenService _yonetmenService;
        public YonetmenlerController(IYonetmenService yonetmenService)
        {
            _yonetmenService =yonetmenService;
        }

        // GET: Yonetmenler
        public IActionResult Index()
        {
            var model = _yonetmenService.Query().ToList();
            return View(model);
        }

        // GET: Yonetmenler/Details/5
        public IActionResult Details(int? id)
        {
            if(id == null)
                return View("Hata","Id gereklidir.");
            YonetmenModel model = _yonetmenService.Query().SingleOrDefault(y => y.Id == id);
            if (model == null)
                return View("Hata", "Kategori bulunamadı.");
            return View(model);
        }

        // GET: Yonetmenler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetmenler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(YonetmenModel yonetmen)
        {

            if (ModelState.IsValid)
            {
                var result = _yonetmenService.Add(yonetmen);
                if (result.IsSuccessful)
                {
                    TempData["Mesaj"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            
            return View(yonetmen);
        }

        // GET: Yonetmenler/Edit/5
        public IActionResult Edit(int? id)
        {   
            if(id == null)
                return View("Hata","Id gereklidir");
            YonetmenModel model = _yonetmenService.Query().SingleOrDefault(y => y.Id == id);
            if (model == null)
                return View("Hata", "Kategori bulunamadı.");
            return View(model);
            
        }

        // POST: Yonetmenler/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(YonetmenModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _yonetmenService.Update(model);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        // GET: Yonetmenler/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return View("Hata", "Id gereklidir.");
            Result result = _yonetmenService.Delete(id.Value);
            TempData["Mesaj"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

        // POST: Yonetmenler/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed()
        {
            return null;
        }
	}
}
