using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.TestTools.ProductArrivals
{
    public static class AddProductArrivalFactory
    {
        public static ProductArrival Create(int productId, int number=20,
            string invoiceNumber="123a", string companyName="dummy_compani")
        {
            return new ProductArrival
            {
                ProductId = productId,
                Number = number,
                InvoiceNumber = invoiceNumber,
                CompanyName = companyName,
                DateTime = DateTime.Now
            };
        }
    }
}
