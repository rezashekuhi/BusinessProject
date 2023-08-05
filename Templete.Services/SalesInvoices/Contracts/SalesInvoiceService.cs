using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.SalesInvoices.Contracts.Dto;

namespace Templete.Services.SalesInvoices.Contracts
{
    public interface SalesInvoiceService
    {
        void Add(AddSalesInvoiceDto dto);
        List<GetAllSalesInvoiceDto> GetAll();
    }
}
