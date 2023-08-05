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
        public static AddProductArrivalDto Create(int productId,int number=10,
          string invoiceNumber="123a",string companyName="dummy_companyname")
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
