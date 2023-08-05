using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.AccountingDocuments.Contract;
using Templete.Services.AccountingDocuments.Contract.Dto;

namespace Templete.Persistanse.EF.AccountingDocuments
{
    public class EFAccountingDocumentRepository : AccountingDocumentRepository
    {
        private readonly DbSet<AccountingDocument> _accountingDocuments;
        public EFAccountingDocumentRepository(EFDataContext context)
        {
            _accountingDocuments=context.Set<AccountingDocument>();
        }
        public void Add(AccountingDocument accountingDocument)
        {
            _accountingDocuments.Add(accountingDocument);
        }

        public List<GetAllAccountingDocumentDto> 
            GetAll(SearchInGetAllAccountingDocumentDto dto)
        {
            var result = _accountingDocuments.Select(_ => new GetAllAccountingDocumentDto
            {
                DocumentNumber = _.documentNumber,
                InvoiceNumber = _.InvoiceNumber,
                 TotalAmount=_.TotalAmount,
                 DateTime=_.DateTime
            });

            if (dto.DocumentNumber>0)
            {
                result = result.Where(_ => _.DocumentNumber == dto.DocumentNumber);
            }

            if (!string.IsNullOrWhiteSpace(dto.InvoiceNumber))
            {
                result = result.Where(_ => _.InvoiceNumber.Contains(dto.InvoiceNumber));
            }

            return result.ToList();
        }
    }
}
