using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Products.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Templete.TestTools.Products;
using Xunit;

namespace Tempelte.Specs.Tests.Products
{
    [Scenario("تعریف کالا با عنوان تکراری در یک گروه")]
    public class AddProductDuplicateTitleException: BusinessIntegrationTest
    {
        private Group group;
        private Action expected;
        [Given("یک گروه با عنوان بهداشتی " +
            "در فهرست گروه ها وجود دارد"+
            "و: یک کالا با نام شامپو" +
            " در گروه بهداشتی وجود دارد")]
        public void Given()
        {
            group = AddGroupFactory.Create("بهداشتی");
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id, "شامپو");
            DbContext.Save(product);
        }

        [When("یک کالا با عنوان شامپو " +
            "و گروه بهداشتی و" +
            " حداقل موجودی ۱۰ را ثبت میکنم ")]
        public void When()
        {
            var sut = ProductServiceFactory.Generate(SetupContext);
            var dto = AddProductDtofactory.Create(group.Id, "شامپو", 10);
            expected=()=> sut.Add(dto);
        }

        [Then("خطایی با عنوان" +
            " 'کالا تکراری است'" +
            " باید رخ دهد ")]
        public void Then()
        {
            expected.Should().ThrowExactly<ProductIsDuplicateException> ();
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
