using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Level { get; set; }
        public string? Type { get; set; }

        public string? Description { get; set; }
        public string? Category { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }


    }
}
