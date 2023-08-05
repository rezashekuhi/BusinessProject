using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.AccountingDocuments.Contract.Dto;

namespace Templete.Services.AccountingDocuments.Contract
{
    public interface AccountingDocumentService
    {
        List<GetAllAccountingDocumentDto> GetAll(SearchInGetAllAccountingDocumentDto dto);
    }
}
