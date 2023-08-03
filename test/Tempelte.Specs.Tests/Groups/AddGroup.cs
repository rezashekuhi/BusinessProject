using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempelte.Specs.Tests;
using Templete.Entities;
using Templete.TestTools.DataBaseConfig.Integration;
using Templete.TestTools.Groups;
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    [Scenario(" ثبت گروه")]
    public class AddGroup : BusinessIntegrationTest
    {
       [Given("فهرست گروه خالی است")]
       public void Given()
        {

        }
       [When("یک گروه با نام بهداشتی را ثبت میکنم")]
       public void When()
        {
            var dto = AddGroupDtoFactory.create("بهداشتی");
            var sut =GroupServiceFactory.Generate(SetupContext);
            sut.Add(dto);
        }
       [Then("در فهرست گروه ها یک گروه با" +
            " نام بهداشتی باید وجود داشته باشد")]
       public void Then()
        {
            var expected = ReadContext.Set<Group>().Single();
            expected.Name.Should().Be("بهداشتی");
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
