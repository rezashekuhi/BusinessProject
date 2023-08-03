using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempelte.Specs.Tests;
using Templete.Entities;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Templete.TestTools.ProductArrivals;
using Templete.TestTools.Products;
using Xunit;

namespace Tempelte.Specs.Tests.ProductArrivals
{
    [Scenario("ورود کالا")]
    public class AddProductArrivalWith20Available : BusinessIntegrationTest
    {
        private Group group;
        private Product product;

        [Given("یک گروه با نام بهداشتی " +
            "در فهرست گروه ها وجود دارد" +
            "و: یک کالا با عنوان شامپو با موجودی ۰ و" +
            " ۱۰ وضعیت ناموجود  و حداقل موجودی " +
            " در گروه بهداشتی وجود دارد")]
        public void Given()
        {
            group = AddGroupFactory.Create("بهداشتی");
            DbContext.Save(group);
            product = AddProductFactory.Create(group.Id, "شامپو"
                , Condition.Unavailable, 0, 10);
            DbContext.Save(product);
        }

        [When("تعداد ۲۰ تا به موجودی کالایی " +
            "با عنوان شامپو با شماره فاکتور 123آ " +
            "و نام شرکت فپکو  " +
            "در گروه بهداشتی را وارد میکنم ")]
        public void When()
        {
            var sut = ProductArrivalServiceFactory.Generate(SetupContext);
            var dto = ProductArrivalDtoFactory.Create(product.Id, 20, "123a", "شرکت فپکو");
            sut.Add(dto);
        }

        [Then("یک کالا با عنوان شامپو و موجودی ۲۰ " +
            "و وضعیت موجود در گروه بهداشتی " +
            "و حداقل موجودی ۱۰ باید در فهرست کالاها " +
            "وجود داشته باشد" +
            "و: یک ورودی کالا برای کالای شامپو" +
            " در تاریخ 1402 / 09 / 19 21:59 " +
            " و تعداد ۲۰ و شماره فاکتور ۱۲۳آ " +
            "و نام شرکت فپکو باید در فهرست" +
            " ورودی های کالا وجود داشته باشد")]
        public void Then()
        {
            var expected =ReadContext.Set<Product>().Single(_=>_.GroupId==group.Id);
            expected.Title.Should().Be("شامپو");
            expected.Inventory.Should().Be(20);
            expected.Condition.Should().Be(Condition.Available);
            expected.MinimumInventory.Should().Be(10);
            var expectedProductArrival = ReadContext.Set<ProductArrival>().Single();
            expectedProductArrival.ProductId.Should().Be(product.Id);
            expectedProductArrival.Number.Should().Be(20);
            expectedProductArrival.InvoiceNumber.Should().Be("123a");
            expectedProductArrival.CompanyName.Should().Be("شرکت فپکو");
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
