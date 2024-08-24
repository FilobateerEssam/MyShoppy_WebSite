using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShoppy.DataAccess.Data;
using MyShoppy.Utitlites;
using System.Security.Claims;
namespace MyShoppy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.AdminRole)]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // User that is logged in that browsed to this page
            string userid = claim?.Value;

            // Get all users except the one that is logged in now

            return View(_context.ApplicationUsers.Where(x => x.Id != userid).ToList());
        }
    }
}
