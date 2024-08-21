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

            return View();
        }
        public IActionResult GetData()
        {
            var products = _unitOfWork.Product.GetAll(IncludeWord: "Category");
            return Json(new { data = products });
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
        public IActionResult Create(ProductVM productVM, IFormFile? file)
        {
            if (productVM.Product.Description == null && productVM.Product.ImageUrl == null)
            {
                productVM.Product.Description = " ";
                productVM.Product.ImageUrl = " ";
            }
            if (ModelState.IsValid)
            {

                string webRootPath = _webHostingEnvironment.WebRootPath;

                if (file != null)
                {
                    // Get the original filename without extension
                    string originalFilename = Path.GetFileNameWithoutExtension(file.FileName);

                    // Get the extension of the file
                    var ext = Path.GetExtension(file.FileName);

                    // Get the date of the day after today
                    // string dateTomorrow = DateTime.Now.AddDays(1).ToString("yyyyMMdd");
                    string dateTomorrow = DateTime.Now.ToString("yyyy-MM-dd");

                    // Combine the original filename with the date
                    string filename = $"{originalFilename}_{dateTomorrow}";

                    // Define the upload path
                    var uploads = Path.Combine(webRootPath, @"Images\products");

                    // Create the full path with the new filename
                    var filePath = Path.Combine(uploads, filename + ext);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Set the ImageUrl property
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

            ProductVM productVM = new ProductVM()
            {
                Product = _unitOfWork.Product.GetFirstorDefault(x => x.Id == id),
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
        public IActionResult Edit(ProductVM productVM, IFormFile? file)
        {
            if (productVM.Product.Description == null && productVM.Product.ImageUrl == null)
            {
                productVM.Product.Description = " ";
                productVM.Product.ImageUrl = " ";
            }
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostingEnvironment.WebRootPath;

                if (file != null)
                {
                    // Get the original filename without extension
                    string originalFilename = Path.GetFileNameWithoutExtension(file.FileName);

                    // Get the extension of the file
                    var ext = Path.GetExtension(file.FileName);

                    // Get the date of the day after today
                    string dateTomorrow = DateTime.Now.ToString("yyyy-MM-dd");

                    // Combine the original filename with the date
                    string filename = $"{originalFilename}_{dateTomorrow}";

                    // Define the upload path
                    var uploads = Path.Combine(webRootPath, @"Images\products");

                    // Create the full path with the new filename
                    var filePath = Path.Combine(uploads, filename + ext);

                    // Delete the old image if it exists
                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(webRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Save the new file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Set the ImageUrl property
                    productVM.Product.ImageUrl = @"Images\products\" + filename + ext;
                }

                _unitOfWork.Product.Update(productVM.Product);
                _unitOfWork.Complete();
                TempData["Edit"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(productVM.Product);
        }




        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _unitOfWork.Product.GetFirstorDefault(x => x.Id == id);

            if (productFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }

            _unitOfWork.Product.Remove(productFromDb);

            // Delete the old image if it exists
            if (!string.IsNullOrEmpty(productFromDb.ImageUrl))
            {
                var oldImagePath = Path.Combine(_webHostingEnvironment.WebRootPath, productFromDb.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.Complete();
            return Json(new { success = true, message = "file has been Deleted" });
        }

    }
}
