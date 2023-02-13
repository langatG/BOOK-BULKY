using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> covertypelist = _unitOfWork.CoverType.GetAll();
            return View(covertypelist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType Created successfuly";
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
            var covertypefromdb = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id == id);

            if (covertypefromdb == null)
            {
                TempData["error"] = "an Error Occured";
                return NotFound();
            }
            return View(covertypefromdb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "covertype Updated successfuly";
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
            var covertypefromdb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (covertypefromdb == null)
            {
                return NotFound();
            }
            return View(covertypefromdb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var covertypefromdb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (covertypefromdb == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(covertypefromdb);
            _unitOfWork.Save();
            TempData["success"] = "Covertype Delete successfuly";
                return RedirectToAction("Index");
        }
    }
}
