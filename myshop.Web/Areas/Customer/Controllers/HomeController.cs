using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myshop.Entities.Models;
using myshop.Entities.Repositories;
using myshop.Entities.ViewModels;
using myshop.Utilities;
using Stripe;
using System.Security.Claims;
using X.PagedList;

namespace myshop.Web.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{
		private readonly IUnitOfWork _unitofwork;

		public HomeController(IUnitOfWork unitofwork)
		{
			_unitofwork = unitofwork;

		}
		public IActionResult Index()
		{

			var products = _unitofwork.Product.GetAll();
			return View(products);
		}

		public IActionResult Details(int ProductId)
		{
			ShoppingCart obj = new ShoppingCart()
			{
				ProductId = ProductId,
				Product = _unitofwork.Product.GetFirstorDefault(v => v.Id == ProductId, Includeword: "Category"),
				Count = 1,


			};
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public IActionResult Details(ShoppingCart shoppingCart)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			shoppingCart.ApplicationUserId = claim.Value;


			// Set the formatted created time
			shoppingCart.FormattedCreatedTime = shoppingCart.GetFormattedCreatedTime();

			// get the new producs that add to db
			ShoppingCart cartobj = _unitofwork.ShoppingCart.GetFirstorDefault(
				u => u.ApplicationUserId == shoppingCart.ApplicationUserId && u.ProductId == shoppingCart.ProductId);

			// Nothing new added

			if (cartobj == null)
			{
				_unitofwork.ShoppingCart.Add(shoppingCart);
			}
			else
			{
				_unitofwork.ShoppingCart.IncreaseCount(cartobj, shoppingCart.Count);
			}

			_unitofwork.Complete();

			return RedirectToAction("Index");
		}


	}
}
