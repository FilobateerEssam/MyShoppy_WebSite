using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Image")]
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Relattion one to many
        [ValidateNever]
        public Category Category { get; set; }
    }
}
