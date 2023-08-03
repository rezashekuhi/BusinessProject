using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.ProductArrivals.Contracts.Dto
{
    public class GetAllProductArrvialDto
    {
        public string ProductTitle { get; set; }
        public int Number { get; set; }
        public string InvoiceNumber { get; set; }
        public string CompaniName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
