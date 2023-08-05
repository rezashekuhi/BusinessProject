using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.TestTools.AccountingDocuments
{
    public static class AddAccountingDocumentFactory
    {
        public static AccountingDocument Create(int salesInvoiceId, string invoiceNumber,int totalAmount
            ,DateTime dateTime)
        {
            return new AccountingDocument
            {
                SalesInvoiceId= salesInvoiceId,
                InvoiceNumber = invoiceNumber,
                TotalAmount = totalAmount,
                DateTime = dateTime
            };
        }
    }
}
