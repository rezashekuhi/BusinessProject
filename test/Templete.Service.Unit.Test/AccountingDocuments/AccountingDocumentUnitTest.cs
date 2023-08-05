using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.AccountingDocuments.Contract.Dto;
using Templete.TestTools.AccountingDocuments;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Unit;
using Templete.TestTools.Groups;
using Templete.TestTools.Products;
using Templete.TestTools.SalesInvoices;
using Xunit;

namespace CMS.Service.Unit.Test.AccountingDocuments
{
    public class AccountingDocumentUnitTest: BusinessUnitTest
    {
        [Fact]
        public void
        Get_get_all_accounting_document_and_search_by_invoicenumber_and_documentnumber()
        {
            var group = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id, "لنت ترمز"
            , Condition.Available, 50, 10);
            DbContext.Save(product);
            var salesInvoice = AddSalesInvoiceFactory.Create(product.Id);
            DbContext.Save(salesInvoice);
            var accountingDocument = AddAccountingDocumentFactory
                .Create(salesInvoice.Id, salesInvoice.InvoiceNumber
                ,salesInvoice.Price*salesInvoice.Number
                ,salesInvoice.DateTime);
            DbContext.Save(accountingDocument);

            var sut= AccountingDocumentServiceFactory.Generate(SetupContext);
            var dto = new SearchInGetAllAccountingDocumentDto
            {
                InvoiceNumber = salesInvoice.InvoiceNumber
            };
            var result = sut.GetAll(dto);

            result.Single().DocumentNumber.Should().Be(accountingDocument.documentNumber);
            result.Single().InvoiceNumber.Should().Be(accountingDocument.InvoiceNumber);
            result.Single().DateTime.Should().Be(accountingDocument.DateTime);
            result.Single().TotalAmount.Should().Be(accountingDocument.TotalAmount);
        }
    }
}
