using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups.Contracts.Dto;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Templete.TestTools.Products;
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    [Scenario("حذف محصول از یک گروه")]
    public class DeleteProductInGroup: BusinessIntegrationTest
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
            , Condition.Available, 20, 5);
            DbContext.Save(product);
        }

        [When("کالایی را با نام لنت ترمز" +
            "از گروه لوازم یدکی حذف میکنم")]
        public void When()
        {
            var sut = ProductServiceFactory.Generate(SetupContext);
            sut.Delete(product.Id);
        }

        [Then("در فهرست کالا های گروه " +
            "لوازم یدکی کالایی با نام لنت ترمز نباید " +
            "وجود داشته باشد")]
        public void Then()
        {
            var expected=ReadContext.Set<Product>();
            expected.Should().HaveCount(0);
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
