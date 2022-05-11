using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Models.Entities
{
    public class Invoice : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual List<InvoiceItem> Items { get; set; }
    }
}
