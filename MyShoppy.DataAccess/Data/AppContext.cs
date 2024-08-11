using Microsoft.EntityFrameworkCore;
using MyShoppy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.DataAccess.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        ////               Model   Table               
        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Phones", Description = "", CreatedTime = DateTime.Now.AddDays(-10) },
                new Category { Id = 2, Name = "Laptops", Description = "", CreatedTime = DateTime.Now.AddDays(-9) },
                new Category { Id = 3, Name = "Electronics", Description = "", CreatedTime = DateTime.Now.AddDays(-8) }
            );
        }

    }

}



