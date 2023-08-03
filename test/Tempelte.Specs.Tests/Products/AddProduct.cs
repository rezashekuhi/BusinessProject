using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
using Xunit;

namespace Tempelte.Specs.Tests.Products
{
    [Scenario("تعریف کالا")]
    public class AddProduct : BusinessIntegrationTest
    {
        private Group group1;

        [Given("دو گروه با عنوان های  اسباب بازی و" +
            " لبنیات در فهرست گروه ها وجود دارد"+
            "و:یک کالا با نام شیر در فهرست" +
            " کالا های لبنیات وجود دارد")]
        public void Given()
        {
            group1 = AddGroupFactory.Create("اسباب بازی");
            DbContext.Save(group1);
            var group2 = AddGroupFactory.Create("لبنیات");
            DbContext.Save(group2);
            var product = AddProductFactory.Create(group2.Id);
            DbContext.Save(product);
        }

        [When("یک کالا با عنوان شیر در گروه اسباب بازی" +
            "  با حداقل موجودی ۱۰ را ثبت میکنم ")]
        public void When()
        {
            var sut = ProductServiceFactory.Generate(SetupContext);
            var dto = AddProductDtofactory.Create(group1.Id,"شیر", 10);
            sut.Add(dto);
        }

        [Then("یک کالا با عنوان شیر در گروه اسباب بازی " +
            "و حداقل موجودی ۱۰ و وضعیت ناموجود و" +
            " موجودی ۰  باید در فهرست کالا موجود باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Product>().Single(_=>_.GroupId==group1.Id);
            expected.Title.Should().Be("شیر");
            expected.MinimumInventory.Should().Be(10);
            expected.Condition.Should().Be(Condition.Unavailable);
            expected.Inventory.Should().Be(0);
            expected.GroupId.Should().Be(group1.Id);
            
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
