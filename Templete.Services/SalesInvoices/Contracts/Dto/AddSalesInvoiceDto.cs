using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.SalesInvoices.Contracts.Dto
{
    public class AddSalesInvoiceDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Number { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }
    }
}
