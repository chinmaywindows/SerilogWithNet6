using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Models.Entities
{
    public class Customer : BaseEntity
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string? PostalCode { get; set; }

        public virtual List<Invoice> Invoices { get; set; }

    }
}
