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
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    [Scenario("ویرایش گروه")]
    public class EditeGroup : BusinessIntegrationTest
    {
        private Group group;
        [Given("یک گروه با نام لوازم یدکی" +
            "در فهرست گروه ها وجود دارد")]
        public void Given()
        {
            group = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group);
        }

        [When("نام گروه را از لوازم یدکی " +
            "به قطعات خودرو تغییر میدهم")]
        public void When()
        {
            var dto = new EditeGroupDto
            {
                GroupId=group.Id,
                Name = "قطعات خودرو"
            };
            var sut = GroupServiceFactory.Generate(SetupContext);
            sut.Edite(dto);
        }

        [Then("در فهرست گروه ها باید گروهی" +
            "با نام قطعات خودرو وجود داشته باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Group>().Single();
            expected.Name.Should().Be("قطعات خودرو");
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
