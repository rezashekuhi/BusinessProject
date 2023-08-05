using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups.Exceptions;
using Templete.Services.ProductArrivals.Exceptions;
using Templete.Services.Products.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Unit;
using Templete.TestTools.Groups;
using Templete.TestTools.Products;
using Xunit;

namespace CMS.Service.Unit.Test.Products
{
    public class ProductUnitTest : BusinessUnitTest
    {
        [Fact]
        public void Add_add_product_properly()
        {
            var group1 = AddGroupFactory.Create("اسباب بازی");
            DbContext.Save(group1);
            var group2 = AddGroupFactory.Create("لبنیات");
            DbContext.Save(group2);
            var product = AddProductFactory.Create(group2.Id);
            DbContext.Save(product);

            var sut = ProductServiceFactory.Generate(SetupContext);
            var dto = AddProductDtofactory.Create(group1.Id, "شیر", 10);
            sut.Add(dto);

            var expected = ReadContext.Set<Product>().ToHashSet().Last();
            expected.Title.Should().Be("شیر");
            expected.MinimumInventory.Should().Be(10);
            expected.Condition.Should().Be(Condition.Unavailable);
            expected.Inventory.Should().Be(0);
            expected.GroupId.Should().Be(group1.Id);
        }
        [Fact]
        public void Add_throw_exception_when_group_id_not_found()
        {
            var invalidGroupId = 1;

            var sut = ProductServiceFactory.Generate(SetupContext);
            var dto = AddProductDtofactory.Create(invalidGroupId);
            var expected = () => sut.Add(dto);

            expected.Should().ThrowExactly<GroupIdNotFoundException>();
        }

        [Fact]
        public void Add_throw_exception_when_product_title_duplicate()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id);
            DbContext.Save(product);

            var sut = ProductServiceFactory.Generate(SetupContext);
            var dto = AddProductDtofactory.Create(group.Id);
            var expected = () => sut.Add(dto);

            expected.Should().ThrowExactly<ProductIsDuplicateException>();
        }

        [Fact]
        public void Delete_delete_product_properly()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id);
            DbContext.Save(product);

            var sut = ProductServiceFactory.Generate(SetupContext);
            sut.Delete(product.Id);

            var expected = ReadContext.Set<Product>();
            expected.Should().HaveCount(0);
        }

        [Fact]
        public void Delete_throw_exception_when_product_id_not_found()
        {
            var invalidId = 1;

            var sut = ProductServiceFactory.Generate(SetupContext);
            var expected=()=> sut.Delete(invalidId);

            expected.Should().ThrowExactly<ProductIdNotFoundException>();
        }
    }
}
