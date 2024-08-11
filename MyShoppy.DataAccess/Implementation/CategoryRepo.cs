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
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly ApplicationContext _context;

        public CategoryRepo(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var CategoryInDB = _context.Categories.FirstOrDefault(x => x.Id == category.Id);

            if (CategoryInDB != null)
            {
                CategoryInDB.Name = category.Name;
                CategoryInDB.Description = category.Description;
                CategoryInDB.CreatedTime = DateTime.Now;
            }
        }
    }
}
