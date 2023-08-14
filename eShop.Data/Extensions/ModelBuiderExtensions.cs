using eShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Extensions
{
    public static class ModelBuiderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Category category1 = new Category() { Id = 1, Name = "Ao", DateCreated = DateTime.Now };
            Category category2 = new Category() { Id = 2, Name = "Quan", DateCreated = DateTime.Now };
            Category category3 = new Category() { Id = 3, Name = "Mu", DateCreated = DateTime.Now };

            Product product1 = new Product() { Id = 1, CategoryId = category1.Id, Price = 500, Stock = 0, ViewCount = 10, OriginalPrice = 400, DateCreated = DateTime.Now };
            Product product2 = new Product() { Id = 2, CategoryId = category1.Id, Price = 600, Stock = 0, ViewCount = 10, OriginalPrice = 300, DateCreated = DateTime.Now };
            Product product3 = new Product() { Id = 3, CategoryId = category2.Id, Price = 700, Stock = 0, ViewCount = 10, OriginalPrice = 350, DateCreated = DateTime.Now };
            Product product4 = new Product() { Id = 4, CategoryId = category3.Id, Price = 800, Stock = 0, ViewCount = 10, OriginalPrice = 500, DateCreated = DateTime.Now };

            Order order1 = new Order() { Id = 1, OrderDate = DateTime.Now, ShipName = "Huy1", ShipEmail = "huy1@gmail.com", ShipPhoneNumber = "123456789", ShipAddress = "HN1" };
            Order order2 = new Order() { Id = 2, OrderDate = DateTime.Now, ShipName = "Huy2", ShipEmail = "huy2@gmail.com", ShipPhoneNumber = "1234123421", ShipAddress = "HN2" };
            Order order3 = new Order() { Id = 3, OrderDate = DateTime.Now, ShipName = "Huy3", ShipEmail = "huy3@gmail.com", ShipPhoneNumber = "123431242156789", ShipAddress = "HN3" };



            modelBuilder.Entity<Category>().HasData(category1, category2, category3);
            modelBuilder.Entity<Product>().HasData(product1, product2, product3, product4);
        }
    }
}
