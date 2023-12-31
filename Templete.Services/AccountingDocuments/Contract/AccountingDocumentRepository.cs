﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.AccountingDocuments.Contract.Dto;

namespace Templete.Services.AccountingDocuments.Contract
{
    public interface AccountingDocumentRepository
    {
        void Add(AccountingDocument accountingDocument);
        List<GetAllAccountingDocumentDto> GetAll(SearchInGetAllAccountingDocumentDto dto);
    }
}
