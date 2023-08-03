using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    [Scenario("حذف گروه وقتی که برای" +
        " گروه کالا وجود دارد")]
    public class DeleteGroupHasAProductExceptionConditionAvailable 
        : BusinessIntegrationTest
    {
        private Action expected;
        private Group group;
        [Given("در فهرست گروه ها یک گروه" +
            " به نام بهداشتی وجود دارد"+ 
            "و: یک کالا با عنوان شامپو" +
            " در گروه بهداشتی ثبت شده است")]
        public void Given()
        {
            group = AddGroupFactory.Create("بهداشتی");
            DbContext.Save(group);
            var product = new Product
            {
                Title = "شامپو",
                GroupId = group.Id,
                Condition = Condition.Available,
                Inventory = 0,
                MinimumInventory = 10
            };
            DbContext.Save(product);
        }

        [When("گروه بهداشتی را حذف میکنم")]
        public void When()
        {
            var sut = GroupServiceFactory.Generate(SetupContext);
            expected = () => sut.Delete(group.Id);
        }

        [Then("")]
        public void Then()
        {
            expected.Should().ThrowExactly<GroupHasAProductException>();
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
