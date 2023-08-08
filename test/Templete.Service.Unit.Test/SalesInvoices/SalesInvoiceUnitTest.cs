using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.ProductArrivals.Exceptions;
using Templete.Services.SalesInvoices.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Unit;
using Templete.TestTools.Groups;
using Templete.TestTools.Products;
using Templete.TestTools.SalesInvoices;
using Xunit;

namespace CMS.Service.Unit.Test.SalesInvoices
{
    public class SalesInvoiceUnitTest : BusinessUnitTest
    {
        [Fact]
        public void Add_add_sales_invoice_properly()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id,"dummyt_title"
            , Condition.Available, 20, 5);
            DbContext.Save(product);
            var sut = SalesInvoiceServiceFactory.Generate(SetupContext);
            var dto = AddSalesInvoiceDtoFactory.Create(product.Id, 1000, "dummy_Name"
                , 5, "123a");

            sut.Add(dto);

            var expectedProduct = ReadContext.Set<Product>().Single();
            expectedProduct.Title.Should().Be(product.Title);
            expectedProduct.Inventory.Should().Be(15);
            expectedProduct.Condition.Should().Be(Condition.Available);
            expectedProduct.MinimumInventory.Should().Be(product.MinimumInventory);
            expectedProduct.GroupId.Should().Be(group.Id);
            var expectedSalesInvoice = ReadContext.Set<SalesInvoice>().Single();
            expectedSalesInvoice.ProductId.Should().Be(product.Id);
            expectedSalesInvoice.Number.Should().Be(dto.Number);
            expectedSalesInvoice.Price.Should().Be(dto.UnitPrice);
            expectedSalesInvoice.InvoiceNumber.Should().Be(dto.InvoiceNumber);
            expectedSalesInvoice.CustomerName.Should().Be("dummy_Name");
            var expectedDocument = ReadContext.Set<AccountingDocument>().Single();
            expectedDocument.InvoiceNumber.Should().Be("123a");
            expectedDocument.TotalAmount.Should().Be(5000);
            expectedDocument.DateTime.Should().Be(expectedSalesInvoice.DateTime);
        }

        [Fact]
        public void Add_throw_exception_when_product_id_not_found()
        {
            var invalidProductId = 1;

            var sut = SalesInvoiceServiceFactory.Generate(SetupContext);
            var dto = AddSalesInvoiceDtoFactory.Create(invalidProductId);
            var expected = ()=> sut.Add(dto);

            expected.Should().ThrowExactly<ProductIdNotFoundException>();
        }

        [Fact]
        public void Add_throw_exception_when_quantity_entered_is_more_than_the_stock_of_the_product()
        {
            var group = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id, "لنت ترمز"
            , Condition.Available, 10, 5);
            DbContext.Save(product);

            var sut = SalesInvoiceServiceFactory.Generate(SetupContext);
            var dto = AddSalesInvoiceDtoFactory.Create(product.Id, 1000,
                "مجید رضوی", 15, "123a");
            var expected = () => sut.Add(dto);

            expected.Should()
                .ThrowExactly<QuantityEnteredIsMoreThanTheProductStockException>();
        }

        [Fact]
        public void Get_get_all_sales_invoice_peoperly()
        {
            var group = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id, "لنت ترمز"
            , Condition.Available, 50, 10);
            DbContext.Save(product);
            var salesInvoice = AddSalesInvoiceFactory.Create(product.Id);
            DbContext.Save(salesInvoice);

            var sut = SalesInvoiceServiceFactory.Generate(SetupContext);
            var result = sut.GetAll();

            result.Single().Id.Should().Be(salesInvoice.Id);
            result.Single().ProductId.Should().Be(salesInvoice.ProductId);
            result.Single().ProductTitle.Should().Be(salesInvoice.Product.Title);
            result.Single().CustomerName.Should().Be(salesInvoice.CustomerName);
            result.Single().Number.Should().Be(salesInvoice.Number);
            result.Single().Price.Should().Be(salesInvoice.Price);
            result.Single().InvoiceNumber.Should().Be(salesInvoice.InvoiceNumber);
        }

    }
}
