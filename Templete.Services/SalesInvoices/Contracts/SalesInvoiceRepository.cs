using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.SalesInvoices.Contracts.Dto;

namespace Templete.Services.SalesInvoices.Contracts
{
    public interface SalesInvoiceRepository
    {
        void Add(SalesInvoice salesInvoice);
        List<GetAllSalesInvoiceDto> GetAll();
    }
}
