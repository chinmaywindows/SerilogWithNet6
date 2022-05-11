using SampleConsoleApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Data.Interfaces
{
    public interface ISampleDataRepository
    {

        Task CreateIntialRecordsAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
