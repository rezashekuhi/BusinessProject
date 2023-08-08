using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.SalesInvoices.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Templete.TestTools.Products;
using Templete.TestTools.SalesInvoices;
using Xunit;

namespace Tempelte.Specs.Tests.SalesInvoices
{
    [Scenario("فروش کالا وقتی که تعداد " +
        "وارد شده بیشتر از موجودی " +
        "کالا باشد")]
    public class AddSalesInvoiceWhenTheQuantityEnteredIsMoreThanTheStockOfTheProduct 
        : BusinessIntegrationTest
    {
        private Group group;
        private Product product;
        private Action expected;

        [Given("گروهی با نام لوازم یدکی " +
            "در فهرست گروه ها وجود دارد" +
            "و:کالایی با عنوان لنت ترمز" +
            " با موجودی 10 و وضعیت موجود" +
            " و حداقل موجودی ۵ در گروه لوازم یدکی وجود دارد")]
        public void Given()
        {
            group = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group);
            product = AddProductFactory.Create(group.Id, "لنت ترمز"
            , Condition.Available, 10, 5);
            DbContext.Save(product);
        }

        [When("کالای با عنوان لنت ترمز " +
            "و قیمت واحد ۱۰۰۰ تومان " +
            "برای مشتری به نام مجید رضوی" +
            " به تعداد 15 عدد و شماره" +
            " فاکتور 123آ را ثبت میکنم")]
        public void When()
        {
            var sut = SalesInvoiceServiceFactory.Generate(SetupContext);
            var dto = AddSalesInvoiceDtoFactory.Create(product.Id, 1000,
                "مجید رضوی", 15, "123a");
            expected = () => sut.Add(dto);
        }

        [Then("")]
        public void Then()
        {
            expected.Should()
                .ThrowExactly<QuantityEnteredIsMoreThanTheProductStockException>();
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
