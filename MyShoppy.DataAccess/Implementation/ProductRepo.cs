using MyShoppy.DataAccess.Data;
using MyShoppy.Entities.Models;
using MyShoppy.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.DataAccess.Implementation
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly ApplicationContext _context;

        public ProductRepo(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var ProductInDB = _context.products.FirstOrDefault(x => x.Id == product.Id);

            if (ProductInDB != null)
            {
                ProductInDB.Name = product.Name;
                ProductInDB.Description = product.Description;
                ProductInDB.Price = product.Price;
                ProductInDB.ImageUrl = product.ImageUrl;
                ProductInDB.CategoryId = product.CategoryId;
            }
        }


    }
}
