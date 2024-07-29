using Microsoft.AspNetCore.Mvc;
using MyShoppy.DataAccess.Data;
using MyShoppy.Entities;

namespace MyShoppy.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _applicationContext;

        public CategoryController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoriesList = _applicationContext.Categories.ToList();
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
                _applicationContext.Categories.Add(category);
                _applicationContext.SaveChanges();
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

            var categoryfromDb = _applicationContext.Categories.Find(id);

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
                _applicationContext.Categories.Update(category);
                _applicationContext.SaveChanges();
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

            var categoryfromDb = _applicationContext.Categories.Find(id);

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

            var categoryFromDb = _applicationContext.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _applicationContext.Categories.Remove(categoryFromDb);
                _applicationContext.SaveChanges();
                TempData["Delete"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
