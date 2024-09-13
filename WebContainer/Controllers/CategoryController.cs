using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace WebContainer.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _categoryRepo.GetAll().ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category entity)
        {
            #region Add custom model validations
            if (entity.Name.ToLower() == entity.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Category name cannot be same as display order.");
            }
            if (entity.Name.ToLower() == entity.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category name cannot be equal to test.");
            }
            #endregion

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(entity);
                _categoryRepo.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Category cat = _categoryRepo.GetByFirstOrDefault(u => u.Id == id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category entity)
        {
            if (entity != null && entity.Id != 0)
            {
                _categoryRepo.Update(entity);
                _categoryRepo.Save();
                TempData["Success"] = "Category was updated successfully.";
            }
            else
            {
                TempData["Error"] = "Category was not found.";
            }
            return RedirectToAction("Index", _categoryRepo.GetAll().ToList());
        }

        public IActionResult Delete(int id)
        {
            Category cat = _categoryRepo.GetByFirstOrDefault(u => u.Id == id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category entity)
        {
            if (entity != null && entity.Id != 0)
            {
                _categoryRepo.Remove(entity);
                _categoryRepo.Save();
                TempData["Success"] = "Category was removed successfully.";
            }
            else
            {
                TempData["Error"] = "Category was not found.";
            }
            return RedirectToAction("Index", _categoryRepo.GetAll().ToList());
        }
    }
}
