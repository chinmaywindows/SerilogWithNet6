using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleConsoleApp.Data.Interfaces;
using SampleConsoleApp.Models.Context;
using SampleConsoleApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Data.Services
{
    public class SampleDataRepository : ISampleDataRepository, IDisposable
    {

        private SampleDBContext sampleDBContext; 
        private readonly ILogger<SampleDataRepository> logger;   
        

        public SampleDataRepository(SampleDBContext _sampleDBContext,ILogger<SampleDataRepository> _logger)
        {
            sampleDBContext = _sampleDBContext;
            logger = _logger;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await sampleDBContext.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {

            return await sampleDBContext.Products.ToListAsync();
        }

        public async Task CreateIntialRecordsAsync()
        {

            var options = new DbContextOptionsBuilder<SampleDBContext>()
                .UseInMemoryDatabase(databaseName: "SampelDB")
                .Options;

            using (DbContext dbContext = new SampleDBContext(options))
            {
                List<Product> product = new();
               
                for (int i = 0; i < 100000; i++)
                {
                    product.Add(new Product
                    {
                        Id = i,
                        Category = "FoodItem",
                        Level = 1,
                        Name = "Apple-"+i,
                        Description = "Apple Descr--"+i,
                        CreatedBy = "SystemUser",
                        CreatedDate = DateTime.Now,
                        Type = "GroceryItem"
                    });
                }
                
                //await dbContext.BulkInsertAsync(product);               
                await dbContext.AddRangeAsync(product);
                await dbContext.SaveChangesAsync();

            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
