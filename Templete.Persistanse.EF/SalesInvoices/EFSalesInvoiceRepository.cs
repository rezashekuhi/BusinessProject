using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.SalesInvoices.Contracts;
using Templete.Services.SalesInvoices.Contracts.Dto;

namespace Templete.Persistanse.EF.SalesInvoices
{
    public class EFSalesInvoiceRepository : SalesInvoiceRepository
    {
        private readonly DbSet<SalesInvoice> _salesInvoices;
        public EFSalesInvoiceRepository(EFDataContext context)
        {
            _salesInvoices=context.Set<SalesInvoice>();
        }

        public void Add(SalesInvoice salesInvoice)
        {
            _salesInvoices.Add(salesInvoice);
        }

        public List<GetAllSalesInvoiceDto> GetAll()
        {
            return _salesInvoices.Select(_ => new GetAllSalesInvoiceDto
            {
                Id = _.Id,
                CustomerName = _.CustomerName,
                DateTime = DateTime.Now,
                InvoiceNumber = _.InvoiceNumber,
                Number = _.Number,
                Price = _.Price,
                ProductId = _.ProductId,
                ProductTitle = _.Product.Title
            }).ToList();
        }
    }
}
