using MyShoppy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.Entities.Repository
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        void Update(Product product);
    }
}
