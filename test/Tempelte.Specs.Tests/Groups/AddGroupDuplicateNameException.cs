using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Groups;
using Templete.Services.Groups.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    [Scenario(" ثبت گروه با نام تکراری")]
    public class AddGroupDuplicateNameException : BusinessIntegrationTest
    {
        private readonly GroupAppService _sut;
        private Action expected;
        public AddGroupDuplicateNameException()
        {
            _sut = GroupServiceFactory.Generate(SetupContext);
        }
        [Given("یک گروه با نام بهداشتی " +
            "در فهرست گروه وجود دارد")]
        public void Given()
        {
            var group = AddGroupFactory.Create("بهداشتی"); 
            DbContext.Save(group);
        }

        [When("یک گروه با نام بهداشتی را ثبت میکنم ")]
        public void When()
        {
            var dto = AddGroupDtoFactory.create("بهداشتی");
            
           expected=()=> _sut.Add(dto);
        }

        [Then("خطایی با عنوان " +
            "'اسم گروه تکراری' باید رخ دهد")]
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
