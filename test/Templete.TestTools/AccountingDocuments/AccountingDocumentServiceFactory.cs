using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Persistanse.EF;
using Templete.Persistanse.EF.AccountingDocuments;
using Templete.Services.AccountingDocuments;

namespace Templete.TestTools.AccountingDocuments
{
    public static class AccountingDocumentServiceFactory
    {
        public static AccountingDocumentAppService Generate(EFDataContext context)
        {
            var accountingDocumentRepository = new EFAccountingDocumentRepository(context);
            var sut = new AccountingDocumentAppService(accountingDocumentRepository);

            return sut;
        }
    }
}
