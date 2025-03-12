using Microsoft.AspNetCore.Mvc;
using myShop.DataAccess;
using myShop.Entities.Models;
using myShop.Entities.Repositories;

namespace myShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork; 
        //private readonly ApplicationDbContext _context;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll(); 
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Add(category);
                //_context.SaveChanges();
                _unitOfWork.Category.Add(category);
                _unitOfWork.Complete();
                TempData["create"] = "category created successfully"; 
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id); 
            //var category = _context.Categories.Find(id);
            if (category == null) { return NotFound();  }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Update(category);
                //_context.SaveChanges();
                _unitOfWork.Category.Update(category);
                _unitOfWork.Complete(); 
                TempData["edit"] = "category edited successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (category == null) { return NotFound(); }
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            //_context.Categories.Remove(category);
            //_context.SaveChanges();
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Complete();
            TempData["remove"] = "category removed successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
