using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.TestTools.DataBaseConfig.Integration;
using Xunit;

namespace Tempelte.Specs.Tests.Groups
{
    public class SpecModel : BusinessIntegrationTest
    {
        [Given("")]
        public void Given()
        {

        }

        [When("")]
        public void When()
        {

        }

        [Then("")]
        public void Then()
        {

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
