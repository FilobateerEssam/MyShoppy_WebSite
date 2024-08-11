using Microsoft.AspNetCore.Mvc;
using MyShoppy.DataAccess.Data;
using MyShoppy.Entities.Models;
using MyShoppy.Entities.Repository;

namespace MyShoppy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {


        IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoriesList = _unitOfWork.Category.GetAll();
            return View(CategoriesList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Protect Web From Cross Side Forgery Attacks
        public IActionResult Create(Category category)
        {
            if (category.Name == "Filo")
            {
                ModelState.AddModelError("Name", "Filo is not allowed");
            }
            if (category.Description == null)
            {
                category.Description = " ";
            }
            if (ModelState.IsValid)
            {
                //_applicationContext.Categories.Add(category);
                _unitOfWork.Category.Add(category);
                //_applicationContext.SaveChanges();
                _unitOfWork.Complete();
                TempData["Create"] = "Category Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // Check ID
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Get Category By ID

            //var categoryfromDb = _applicationContext.Categories.Find(id);
            var categoryfromDb = _unitOfWork.Category.GetFirstorDefault(x => x.Id == id);

            return View(categoryfromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Protect Web From Cross Side Forgery Attacks
        public IActionResult Edit(Category category)
        {
            if (category.Description == null)
            {
                category.Description = " ";
            }

            if (ModelState.IsValid)
            {
                //_applicationContext.Categories.Update(category);
                _unitOfWork.Category.Update(category);
                //_applicationContext.SaveChanges();
                _unitOfWork.Complete();
                TempData["Edit"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            // Check ID
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Get Category By ID

            //var categoryfromDb = _applicationContext.Categories.Find(id);
            var categoryfromDb = _unitOfWork.Category.GetFirstorDefault(x => x.Id == id);

            return View(categoryfromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Protect Web From Cross Side Forgery Attacks
        public IActionResult DeleteCategory(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var categoryFromDb = _applicationContext.Categories.Find(id);
            var categoryFromDb = _unitOfWork.Category.GetFirstorDefault(x => x.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_applicationContext.Categories.Remove(categoryFromDb);
                _unitOfWork.Category.Remove(categoryFromDb);
                //_applicationContext.SaveChanges();
                _unitOfWork.Complete();
                TempData["Delete"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
