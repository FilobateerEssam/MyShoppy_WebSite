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
            if (ModelState.IsValid)
            {
                _applicationContext.Categories.Add(category);
                _applicationContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
