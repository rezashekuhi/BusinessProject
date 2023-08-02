using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class ProductArrival
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateTime { get; set; }
        public int Number { get; set; }
        public string InvoiceNumber { get; set; }
        public string CompanyName { get; set; }

        
        public Product Product { get; set; }
    }
}
