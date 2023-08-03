using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.ProductArrivals.Dto
{
    public class AddProductArrivalDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Number { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
