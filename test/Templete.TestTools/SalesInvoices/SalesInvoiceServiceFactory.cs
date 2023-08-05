using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Persistanse.EF;
using Templete.Persistanse.EF.AccountingDocuments;
using Templete.Persistanse.EF.Products;
using Templete.Persistanse.EF.SalesInvoices;
using Templete.Services.SalesInvoices;

namespace Templete.TestTools.SalesInvoices
{
    public static class SalesInvoiceServiceFactory
    {
        public static SalesInvoiceAppService Generate(EFDataContext context)
        {
            var salesInvoiceRepository=new EFSalesInvoiceRepository(context);
            var productRepository = new EFProductRepository(context);
            var unitOfWork = new EFUnitOfWork(context);
            var documentRepository = new EFAccountingDocumentRepository(context);
            var sut=new SalesInvoiceAppService(salesInvoiceRepository,productRepository
                ,unitOfWork,documentRepository);
            return sut;
        }
    }
}
