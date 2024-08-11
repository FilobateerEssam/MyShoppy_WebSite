using Microsoft.AspNetCore.Mvc;
using MyShoppy.DataAccess.Data;
using MyShoppy.Entities.Models;
using MyShoppy.Entities.Repository;
using MyShoppy.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MyShoppy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostingEnvironment = webHostingEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ProductsList = _unitOfWork.Product.GetAll();
            return View(ProductsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Protect Web From Cross Side Forgery Attacks
        public IActionResult Create(ProductVM productVM, IFormFile file)
        {

            if (ModelState.IsValid)
            {

                string webRootPath = _webHostingEnvironment.WebRootPath;

                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"Images\products");
                    var ext = Path.GetExtension(file.FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @"Images\products\" + filename + ext;
                }

                //_applicationContext.Product.Add(product);
                _unitOfWork.Product.Add(productVM.Product);
                //_applicationContext.SaveChanges();
                _unitOfWork.Complete();
                TempData["Create"] = "Product Added Successfully";
                return RedirectToAction("Index");
            }
            return View(productVM.Product);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // Check ID
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Get Product By ID

            //var productfromDb = _applicationContext.Product.Find(id);
            var productfromDb = _unitOfWork.Product.GetFirstorDefault(x => x.Id == id);

            return View(productfromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Protect Web From Cross Side Forgery Attacks
        public IActionResult Edit(Product product)
        {
            if (product.Description == null)
            {
                product.Description = " ";
            }

            if (ModelState.IsValid)
            {
                //_applicationContext.Product.Update(product);
                _unitOfWork.Product.Update(product);
                //_applicationContext.SaveChanges();
                _unitOfWork.Complete();
                TempData["Edit"] = "Product Updated Successfully";
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

            // Get Product By ID

            //var categoryfromDb = _applicationContext.Categories.Find(id);
            var productfromDb = _unitOfWork.Product.GetFirstorDefault(x => x.Id == id);

            return View(productfromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Protect Web From Cross Side Forgery Attacks
        public IActionResult DeleteProduct(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var productfromDbFromDb = _applicationContext.Product.Find(id);
            var productFromDb = _unitOfWork.Product.GetFirstorDefault(x => x.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_applicationContext.Categories.Remove(categoryFromDb);
                _unitOfWork.Product.Remove(productFromDb);
                //_applicationContext.SaveChanges();
                _unitOfWork.Complete();
                TempData["Delete"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
