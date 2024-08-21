using MyShoppy.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.Entities.ViewModels
{
    public class ShoppingCart
    {
        public Product product { get; set; }
        [Range(1, 100, ErrorMessage = "You must Enter value between 1 to 100")]
        public int Count { get; set; }
    }
}
