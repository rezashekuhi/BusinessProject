using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class SalesInvoice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public DateTime DateTime { get; set; }
        public string InvoiceNumber { get; set; }

        public List<AccountingDocument> AccountingDocuments { get; set; }
        public Product Product { get; set; }
    }
}
