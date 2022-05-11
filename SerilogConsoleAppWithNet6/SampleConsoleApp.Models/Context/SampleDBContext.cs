using Microsoft.EntityFrameworkCore;
using SampleConsoleApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Models.Context
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext()
        {

        }

        public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            

        //    //modelBuilder.Entity<Product>().HasData(new Product(
        //    //    Id = 1,
        //    //    Category = "FoodItem",
        //    //    Level = 1,
        //    //    Name = "Apple-" + i,
        //    //    Description = "Apple Descr--" + i,
        //    //    CreatedBy = "SystemUser",
        //    //    CreatedDate = DateTime.Now,
        //    //    Type = "GroceryItem"
        //    //);

        //     modelBuilder.Entity<Blog>().HasData(new Blog(1, "Url1"));

        //    modelBuilder.Entity<Blog>().HasData(new Blog(2, "Url2"));

        //    modelBuilder.Entity<Post>().HasData(new Post(1, "Title1", "Content1") { BlogId = 1 });
        //    modelBuilder.Entity<Post>().HasData(new Post(2, "Title2", "Content2") { BlogId = 1 });
        //    modelBuilder.Entity<Post>().HasData(new Post(3, "Title3", "Content3") { BlogId = 1 });

        //    modelBuilder.Entity<Post>().HasData(new Post(4, "Title4", "Content4") { BlogId = 2 });
        //}

    }
}
