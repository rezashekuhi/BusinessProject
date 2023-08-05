using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups.Contracts.Dto;
using Templete.Services.Groups.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    [Scenario("ویرایش گروه")]
    public class EditeGroupIsDuplicateNameException : BusinessIntegrationTest
    {
        private Group group1;
        private Group group2;
        private Action expected;

        [Given("یک گروه با نام لوازم یدکی" +
            "و: یک گروه با نام بهداشتی" +
            "در فهرست گروه ها وجود دارد")]
        public void Given()
        {
            group1 = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group1);
            group2 = AddGroupFactory.Create("بهداشتی");
            DbContext.Save(group2);
        }

        [When("نام گروه را از لوازم یدکی " +
            "به بهداشتی تغییر میدهم")]
        public void When()
        {
            var dto = new EditeGroupDto
            {
                GroupId=group1.Id,
                Name = "بهداشتی"
            };
            var sut = GroupServiceFactory.Generate(SetupContext);
            expected=()=> sut.Edite(dto);
        }

        [Then("در فهرست گروه ها باید گروهی" +
            "با نام قطعات خودرو وجود داشته باشد")]
        public void Then()
        {
            expected.Should().ThrowExactly<DuplicateGroupNameException>();
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
