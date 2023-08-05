using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.TestTools.SalesInvoices
{
    public static class AddSalesInvoiceFactory
    {
        public static SalesInvoice Create(int productId,string customerName="dummy_name",
          int number=10,int price=1000,string invoiceNumber="123a")
        {
            return new SalesInvoice
            {
                ProductId = productId,
                CustomerName = customerName,
                Number = number,
                Price = price,
                DateTime = DateTime.Now,
                InvoiceNumber = invoiceNumber
            };
        }
    }
}
