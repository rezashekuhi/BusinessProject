using Microsoft.AspNetCore.Mvc;
using Templete.Services.SalesInvoices.Contracts;
using Templete.Services.SalesInvoices.Contracts.Dto;

namespace Templete.RestApi.Controllers
{
    [Route("sales-invoices")]
    [ApiController]
    public class SalesInvoiceController : Controller
    {
        private readonly SalesInvoiceService _service;
        public SalesInvoiceController(SalesInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddSalesInvoiceDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllSalesInvoiceDto> GetAll()
        {
            return _service.GetAll();
        }

    }
}
