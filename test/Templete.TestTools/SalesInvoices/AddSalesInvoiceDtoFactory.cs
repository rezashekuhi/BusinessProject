using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.SalesInvoices.Contracts.Dto;

namespace Templete.TestTools.SalesInvoices
{
    public static class AddSalesInvoiceDtoFactory
    {
        public static AddSalesInvoiceDto Create(int productId,int unitPrice=1000
            ,string customerName="dummy_name",int number=5,string invoiceNumber="123a")
        {
            return new AddSalesInvoiceDto
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                CustomerName = customerName,
                Number = number,
                InvoiceNumber = invoiceNumber
            };
        }
    }
}
