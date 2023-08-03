using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.ProductArrivals.Dto;

namespace Templete.TestTools.ProductArrivals
{
    public static class ProductArrivalDtoFactory
    {
        public static AddProductArrivalDto Create(int productId,int number,
          string invoiceNumber,string companyName)
        {
            return new AddProductArrivalDto
            {
                ProductId=productId,
                Number=number,
                InvoiceNumber=invoiceNumber,
                CompanyName=companyName
            };
        }
    }
}
