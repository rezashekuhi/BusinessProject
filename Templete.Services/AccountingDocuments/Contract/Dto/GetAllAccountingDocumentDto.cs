using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.AccountingDocuments.Contract.Dto
{
    public class GetAllAccountingDocumentDto
    {
        public int DocumentNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public int TotalAmount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
