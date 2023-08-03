using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Entities
{
    public class AccountingDocument
    {
        public int documentNumber { get; set; }
        public int SalesInvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public int TotalAmount { get; set; }

        public SalesInvoice SalesInvoice { get; set; }
    }
}
