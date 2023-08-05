using Microsoft.AspNetCore.Mvc;
using Templete.Services.AccountingDocuments.Contract;
using Templete.Services.AccountingDocuments.Contract.Dto;

namespace Templete.RestApi.Controllers
{
    [Route("accounting_documents")]
    [ApiController]
    public class AccountingDocumentController : Controller
    {
        private readonly AccountingDocumentService _service;
        public AccountingDocumentController(AccountingDocumentService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<GetAllAccountingDocumentDto>
            GetAll([FromQuery]SearchInGetAllAccountingDocumentDto dto)
        {
            return _service.GetAll(dto);
        }
    }
}
