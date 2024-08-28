using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myshop.Entities.Repositories;
using myshop.Entities.ViewModels;
using System.Security.Claims;

namespace myshop.Web.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Authorize]
	public class CartController : Controller
	{
		private readonly IUnitOfWork _unitofwork;
		public ShoppingCartVM ShoppingCartVM { get; set; }

		public CartController(IUnitOfWork unitofwork)
		{
			_unitofwork = unitofwork;
		}
		public IActionResult Index(int? id)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			// Get the shopping cart items
			ShoppingCartVM = new ShoppingCartVM()
			{

				// Show category name , Image of the product
				CartList = _unitofwork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, Includeword: "Product,Product.Category")

			};

			// Calculate the total price

			foreach (var item in ShoppingCartVM.CartList)
			{
				ShoppingCartVM.TotalCarts += (item.Product.Price * item.Count);
			}

			// Check if the cart is empty and set a message
			if (!ShoppingCartVM.CartList.Any())
			{
				ViewBag.EmptyCartMessage = "Your shopping cart is empty.";
			}

			return View(ShoppingCartVM);
		}
		public IActionResult Plus(int cartid)
		{
			var shoppingcart = _unitofwork.ShoppingCart.GetFirstorDefault(x => x.Id == cartid);

			_unitofwork.ShoppingCart.IncreaseCount(shoppingcart, 1);
			_unitofwork.Complete();
			return RedirectToAction("Index");
		}
		public IActionResult Minus(int cartid)
		{
			var shoppingcart = _unitofwork.ShoppingCart.GetFirstorDefault(x => x.Id == cartid);

			if(shoppingcart.Count < 1)
			{
				_unitofwork.ShoppingCart.Remove(shoppingcart);
			}
			else
			{
				_unitofwork.ShoppingCart.DecreaseCount(shoppingcart, 1);
			}
			_unitofwork.Complete();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int cartid)
		{
			var shoppingcart = _unitofwork.ShoppingCart.GetFirstorDefault(x => x.Id == cartid);
			_unitofwork.ShoppingCart.Remove(shoppingcart);
			_unitofwork.Complete();
			return RedirectToAction("Index");
		}
	}
}
