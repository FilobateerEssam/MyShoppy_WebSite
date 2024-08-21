using Microsoft.AspNetCore.Mvc;
using MyShoppy.Entities.Models;
using MyShoppy.Entities.Repository;
using MyShoppy.Entities.ViewModels;

namespace MyShoppy.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var Products = _unitOfWork.Product.GetAll(IncludeWord: "Category");
            return View(Products);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ShoppingCart obj = new ShoppingCart()
            {
                product = _unitOfWork.Product.GetFirstorDefault(x => x.Id == id, IncludeWord: "Category"),
                Count = 1
            };
            return View(obj);

            //if (product_details == null)
            //{
            //    return NotFound();
            //    // Show an error message with toaster
            //    TempData["ErrorData"] = "Error: Product not found!";
            //}

        }
    }
}
