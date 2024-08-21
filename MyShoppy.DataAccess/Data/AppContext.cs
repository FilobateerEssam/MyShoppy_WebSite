using Microsoft.EntityFrameworkCore;
using MyShoppy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MyShoppy.DataAccess.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        ////               Model   Table               
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Phones", Description = "", CreatedTime = DateTime.Now.AddDays(-10) },
                new Category { Id = 2, Name = "Laptops", Description = "", CreatedTime = DateTime.Now.AddDays(-9) },
                new Category { Id = 3, Name = "Electronics", Description = "", CreatedTime = DateTime.Now.AddDays(-8) }
            );
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });
        }

    }

}



