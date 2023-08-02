using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Groups;
using ShopApp.Services.Groups.Dto;
using ShopApp.TestTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Groups.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Unit;
using Templete.TestTools.Groups;
using Xunit;

namespace Templete.Service.Unit.Test.Groups
{
    public class GroupUnitTest : BusinessUnitTest
    {
        private readonly GroupAppService _sut;
        public GroupUnitTest()
        {
            _sut = GroupServiceFactory.Generate(SetupContext);
        }

        [Fact]
        public void Add_add_group_propely()
        {
            var dto = new AddGroupDto
            {
                Name="dummy"
            };

            
            _sut.Add(dto);

            var expected = ReadContext.Set<Group>().Single();
            expected.Name.Should().Be(dto.Name);
        }

        [Fact]
        public void Add_throw_exception_when_duplicate_group_name()
        {
            var group = new Group
            {
                Name = "dummy"
            };
            DbContext.Save(group);

            var dto = new AddGroupDto
            {
                Name = "dummy"
            };
            var expected = () => _sut.Add(dto);

            expected.Should().ThrowExactly<DuplicateGroupNameException>();
        }

        [Fact]
        public void Delete_throw_exception_when_group_id_not_found()
        {
            var invalidId = 1;

            var expected=()=> _sut.Delete(invalidId);

            expected.Should().ThrowExactly<GroupIdNotFoundException>();
        }

        [Fact]
        public void Delete_delete_group_properly()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);

            _sut.Delete(group.Id);

            ReadContext.Set<Group>().Any().Should().BeFalse();
        }

        [Theory]
        [InlineData(Condition.Unavailable)]
        [InlineData(Condition.ReadyToOrder)]
        [InlineData(Condition.Available)]
        public void Delete_throw_exception_when_group_has_a_product(Condition condition)
        {
            var group=AddGroupFactory.Create();
            DbContext.Save(group);
            var product = new Product
            {
                Title="dummy",
                GroupId = group.Id,
                Condition = condition,
                Inventory=0,
                MinimumInventory=10
            };
            DbContext.Save(product);

            var expected=()=> _sut.Delete(group.Id);

            expected.Should().ThrowExactly<GroupHasAProductException>();
        }

        [Fact]
        public void GetAll_get_all_group_Properly()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);

            var result = _sut.GetAll();

            result.Single().Id.Should().Be(group.Id);
            result.Single().Name.Should().Be(group.Name);
        }

        [Theory]
        [InlineData(Condition.Unavailable)]
        [InlineData(Condition.ReadyToOrder)]
        [InlineData(Condition.Available)]
        public void Get_get_group_and_products_by_id_group(Condition condition)
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = new Product
            {
                Title = "dummy",
                GroupId = group.Id,
                Condition = condition,
                Inventory = 0,
                MinimumInventory = 10
            };
            DbContext.Save(product);

            var result = _sut.GetById(group.Id);

            result.Name.Should().Be(group.Name);
            result.Id.Should().Be(group.Id);
            var resultProduct = result.Products.Single();
            resultProduct.Id.Should().Be(product.Id);
            resultProduct.Title.Should().Be(product.Title);
        }

    }
}
