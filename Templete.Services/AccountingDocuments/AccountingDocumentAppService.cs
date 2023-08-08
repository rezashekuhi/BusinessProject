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
        private readonly AccountingDocumentRepository _repository;
        public AccountingDocumentAppService(AccountingDocumentRepository repository)
        {
            _repository = repository;
        }
        public List<GetAllAccountingDocumentDto> GetAll(SearchInGetAllAccountingDocumentDto dto)
        {
            return _repository.GetAll(dto);
        }
    }
}
