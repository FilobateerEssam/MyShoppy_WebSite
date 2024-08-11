using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShoppy.Entities.Models;

namespace MyShoppy.Entities.Repository
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        void Update(Category category);
    }
}
