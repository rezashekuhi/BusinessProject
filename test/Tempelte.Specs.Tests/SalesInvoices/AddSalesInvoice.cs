using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Templete.TestTools.Products;
using Templete.TestTools.SalesInvoices;
using Xunit;

namespace Tempelte.Specs.Tests.SalesInvoices
{
    [Scenario("فروش کالا")]
    public class AddSalesInvoice : BusinessIntegrationTest
    {
        private Group group;
        private Product product;
        [Given("گروهی با نام لوازم یدکی " +
            "در فهرست گروه ها وجود دارد" +
            "و:کالایی با عنوان لنت ترمز" +
            " با موجودی ۲۰  و وضعیت موجود" +
            " و حداقل موجودی ۵ در گروه لوازم یدکی وجود دارد")]
        public void Given()
        {
            group = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group);
            product = AddProductFactory.Create(group.Id, "لنت ترمز"
            ,Condition.Available, 20, 5);
            DbContext.Save(product);
        }

        [When("کالای با عنوان لنت ترمز " +
            "و قیمت واحد ۱۰۰۰ تومان " +
            "برای مشتری به نام مجید رضوی" +
            " به تعداد ۵ عدد و شماره" +
            " فاکتور 123آ را ثبت میکنم")]
        public void When()
        {
            var sut = SalesInvoiceServiceFactory.Generate(SetupContext);
            var dto = AddSalesInvoiceDtoFactory.Create(product.Id,1000,"مجید رضوی",5,"123a");
            sut.Add(dto);
        }

        [Then("کالا با عنوان لنت ترمز با موجودی ۱۵ " +
            "و وضعیت موجود و حداقل موجودی ۵ " +
            "در گروه لوازم یدکی وجود داشته باشد" +
            "و:یک فاکتور فروش با کالای لنت ترمز " +
            "و تعداد ۵ و قیمت ۱۰۰۰ و شماره فاکتور ۱۲۳آ " +
            "و مشتری با نام مجید رضوی و تاریخ 1402" +
            " در فاکتورهای فروش باید وجود داشته باشد" +
            "و:‌ یک سند حسابداری با شماره فاکتور ۱۲۳آ " +
            "و شماره سند 1233455657 و تاریخ 1402" +
            " و مبلغ ۵۰۰۰ باید در فهرست " +
            "سندهای حسابداری ثبت شده باشد")]
        public void Then()
        {
            var expectedProduct=ReadContext.Set<Product>().Single();
            expectedProduct.Title.Should().Be("لنت ترمز");
            expectedProduct.Inventory.Should().Be(15);
            expectedProduct.Condition.Should().Be(Condition.Available);
            expectedProduct.MinimumInventory.Should().Be(5);
            expectedProduct.GroupId.Should().Be(group.Id);
            var expectedSalesInvoice=ReadContext.Set<SalesInvoice>().Single();
            expectedSalesInvoice.ProductId.Should().Be(product.Id);
            expectedSalesInvoice.Number.Should().Be(5);
            expectedSalesInvoice.Price.Should().Be(1000);
            expectedSalesInvoice.InvoiceNumber.Should().Be("123a");
            expectedSalesInvoice.CustomerName.Should().Be("مجید رضوی");
            var expectedDocument = ReadContext.Set<AccountingDocument>().Single();
            expectedDocument.InvoiceNumber.Should().Be("123a");
            expectedDocument.TotalAmount.Should().Be(5000);
            expectedDocument.DateTime.Should().Be(expectedSalesInvoice.DateTime);
        }

        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When(),
                _ => Then()
                );
        }
    }
}
