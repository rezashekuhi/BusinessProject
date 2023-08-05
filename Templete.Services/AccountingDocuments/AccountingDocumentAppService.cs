using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.AccountingDocuments.Contract;
using Templete.Services.AccountingDocuments.Contract.Dto;

namespace Templete.Services.AccountingDocuments
{
    public class AccountingDocumentAppService : AccountingDocumentService
    {
        private readonly AccountingDocumentRepository _documentRepository;
        public AccountingDocumentAppService(AccountingDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public List<GetAllAccountingDocumentDto> GetAll(SearchInGetAllAccountingDocumentDto dto)
        {
            return _documentRepository.GetAll(dto);
        }
    }
}
