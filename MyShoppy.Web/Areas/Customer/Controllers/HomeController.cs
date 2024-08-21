using Microsoft.AspNetCore.Mvc;
using MyShoppy.Entities.Repository;

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
    }
}
