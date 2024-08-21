﻿using Microsoft.EntityFrameworkCore;
using MyShoppy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
        }

    }

}



