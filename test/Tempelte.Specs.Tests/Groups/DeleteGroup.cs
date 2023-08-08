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
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    [Scenario("حذف گروه")]
    public class DeleteGroup : BusinessIntegrationTest
    {
        private Group group;

        [Given("در فهرست گروه ها یک گروه" +
            " به نام بهداشتی وجود دارد")]
        public void Given()
        {
            group = AddGroupFactory.Create("بهداشتی");
            DbContext.Save(group);
        }

        [When("گروه بهداشتی را حذف میکنم")]
        public void When()
        {
            var sut = GroupServiceFactory.Generate(SetupContext);
            sut.Delete(group.Id);
        }

        [Then("در فهرست گروه ها نباید" +
            " گروهی وجود داشته باشد")]
        [And("")]
        public void Then()
        {
            ReadContext.Set<Group>().Any().Should().BeFalse();
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
