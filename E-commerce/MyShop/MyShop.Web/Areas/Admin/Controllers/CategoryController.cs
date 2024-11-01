using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.DataAcssess;
using MyShop.Entities.Models;
using MyShop.Entities.Repository;

namespace MyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }
        [HttpGet]//Category/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] //Category/Create
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Add(category);
                _unitOfWork.Category.Add(category);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Create"] = "Data Has Created Succesfully";
                return RedirectToAction("Index");
            }
            return View(category);

        }
        [HttpGet]//Category/edit
        public IActionResult Edit(int? id)
        {
            if (id == 0 | id == null)
            {
                NotFound();
            }
            //var CategoryId = _context.Categories.FirstOrDefault(e=> e.Id==id);
            var CategoryId = _unitOfWork.Category.GetFirstOrDefault(e => e.Id == id);
            return View(CategoryId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Update(category);
                _unitOfWork.Category.Update(category);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Update"] = "Data Has Updated Succesfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }
            var CategoryId = _unitOfWork.Category.GetFirstOrDefault(e => e.Id == id);
            return View(CategoryId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            if (ModelState.IsValid)
            {
                var CategoryId = _unitOfWork.Category.GetFirstOrDefault(e => e.Id == id);
                if (id == null | id == 0)
                {
                    NotFound();
                }
                //_context.Categories.Remove(CategoryId);
                _unitOfWork.Category.Remove(CategoryId);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Delete"] = "Data Has Deleted Succesfully";
                return RedirectToAction("Index");
            }
            return Content("Not Found");

        }
    }
}
