using BulkBook.Data;
using BulkBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categorylist = _db.Categories;
            return View(categorylist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfuly";
                return RedirectToAction("Index");
            }
           return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromdb = _db.Categories.Find(id);

            if (categoryfromdb == null)
            {
                TempData["error"] = "an Error Occured";
                return NotFound();
            }
            return View(categoryfromdb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromdb = _db.Categories.Find(id);

            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var categoryfromdb = _db.Categories.Find(id);

            if (categoryfromdb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryfromdb);
                _db.SaveChanges();
            TempData["success"] = "Category Delete successfuly";
                return RedirectToAction("Index");
        }
    }
}
