using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups;
using Templete.Services.Groups.Contracts.Dto;
using Templete.Services.Groups.Dto;
using Templete.Services.Groups.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Unit;
using Templete.TestTools.Groups;
using Xunit;

namespace CMS.Service.Unit.Test.Groups
{
    public class GroupUnitTest : BusinessUnitTest
    {
        [Fact]
        public void Add_add_group_propely()
        {
            var dto = new AddGroupDto
            {
                Name = "dummy"
            };
            var sut = GroupServiceFactory.Generate(SetupContext);

            sut.Add(dto);

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
            var sut = GroupServiceFactory.Generate(SetupContext);//ToDo ctor
            var dto = new AddGroupDto
            {
                Name = "dummy"
            };

            var expected = () => sut.Add(dto);

            expected.Should().ThrowExactly<DuplicateGroupNameException>();
        }

        [Fact]
        public void Delete_throw_exception_when_group_id_not_found()
        {
            var invalidId = 1;
            var sut = GroupServiceFactory.Generate(SetupContext);

            var expected = () => sut.Delete(invalidId);

            expected.Should().ThrowExactly<GroupIdNotFoundException>();
        }

        [Fact]
        public void Delete_delete_group_properly()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var sut = GroupServiceFactory.Generate(SetupContext);

            sut.Delete(group.Id);

            ReadContext.Set<Group>().Any().Should().BeFalse();
        }

        [Theory]
        [InlineData(Condition.Unavailable)]
        [InlineData(Condition.ReadyToOrder)]
        [InlineData(Condition.Available)]
        public void Delete_throw_exception_when_group_has_a_product(Condition condition)
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
            var sut = GroupServiceFactory.Generate(SetupContext);

            var expected = () => sut.Delete(group.Id);

            expected.Should().ThrowExactly<GroupHasAProductException>();
        }

        [Fact]
        public void GetAll_get_all_group_Properly()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var sut = GroupServiceFactory.Generate(SetupContext);

            var result = sut.GetAll();

            result.Single().Id.Should().Be(group.Id);
            result.Single().Name.Should().Be(group.Name);
        }

        [Fact]
        public void Get_get_group_and_products_by_id_group()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = new Product
            {
                Title = "dummy",
                GroupId = group.Id,
                Condition = Condition.ReadyToOrder,
                Inventory = 0,
                MinimumInventory = 10
            };
            DbContext.Save(product);
            var sut = GroupServiceFactory.Generate(SetupContext);

            var result = sut.GetById(group.Id);

            result.Name.Should().Be(group.Name);
            result.Id.Should().Be(group.Id);
            var resultProduct = result.Products.Single();
            resultProduct.Id.Should().Be(product.Id);
            resultProduct.Title.Should().Be(product.Title);
        }

        [Fact]
        public void Edite_edite_group_properly()
        {
             var group = AddGroupFactory.Create();
            DbContext.Save(group);

            var dto = new EditeGroupDto
            {
                GroupId = group.Id,
                Name = "قطعات خودرو"
            };
            var sut = GroupServiceFactory.Generate(SetupContext);
            sut.Edite(dto);

            var expected = ReadContext.Set<Group>().Single();
            expected.Name.Should().Be(dto.Name);
        }

        [Fact]
        public void Edite_throw_exception_when_group_duplicate_name()
        {
            var group1 = AddGroupFactory.Create("لوازم یدکی");
            DbContext.Save(group1);
            var group2 = AddGroupFactory.Create("بهداشتی");
            DbContext.Save(group2);

            var dto = new EditeGroupDto
            {
                GroupId = group1.Id,
                Name = "بهداشتی"
            };
            var sut = GroupServiceFactory.Generate(SetupContext);
            var expected = () => sut.Edite(dto);

            expected.Should().ThrowExactly<DuplicateGroupNameException>();

        }

        [Fact]
        public void Edite_throw_exception_when_group_id_not_found()
        {
            var invalidId = 1;

            var dto = new EditeGroupDto
            {
                GroupId = invalidId,
                Name = "بهداشتی"
            };
            var sut = GroupServiceFactory.Generate(SetupContext);
            var expected = () => sut.Edite(dto);

            expected.Should().ThrowExactly<GroupIdNotFoundException>();
        }

    }
}
