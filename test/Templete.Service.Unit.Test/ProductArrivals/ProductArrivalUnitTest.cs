using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.ProductArrivals.Exceptions;
using Templete.TestTools.DataBaseConfig;
using Templete.TestTools.DataBaseConfig.Unit;
using Templete.TestTools.Groups;
using Templete.TestTools.ProductArrivals;
using Templete.TestTools.Products;
using Xunit;

namespace CMS.Service.Unit.Test.ProductArrivals
{
    public class ProductArrivalUnitTest : BusinessUnitTest
    {
        [Fact]
        public void Add_add_product_arrival_with_20_available()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id);
            DbContext.Save(product);
            var sut = ProductArrivalServiceFactory.Generate(SetupContext);
            var dto = ProductArrivalDtoFactory.Create(product.Id, 20, "123a", "dummy_compani_name");

            sut.Add(dto);

            var expected = ReadContext.Set<Product>().Single(_ => _.GroupId == group.Id);
            expected.Title.Should().Be(product.Title);
            expected.Inventory.Should().Be(dto.Number);
            expected.Condition.Should().Be(Condition.Available);
            expected.MinimumInventory.Should().Be(product.MinimumInventory);
            var expectedProductArrival = ReadContext.Set<ProductArrival>().Single();
            expectedProductArrival.ProductId.Should().Be(dto.ProductId);
            expectedProductArrival.Number.Should().Be(dto.Number);
            expectedProductArrival.InvoiceNumber.Should().Be(dto.InvoiceNumber);
            expectedProductArrival.CompanyName.Should().Be(dto.CompanyName);
        }

        [Fact]
        public void Add_add_product_arrival_with_10_available()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id);
            DbContext.Save(product);

            var sut = ProductArrivalServiceFactory.Generate(SetupContext);
            var dto = ProductArrivalDtoFactory.Create(product.Id, 10, "123a", "dummy_compani_name");
            sut.Add(dto);

            var expected = ReadContext.Set<Product>().Single(_ => _.GroupId == group.Id);
            expected.Title.Should().Be(product.Title);
            expected.Inventory.Should().Be(dto.Number);
            expected.Condition.Should().Be(Condition.ReadyToOrder);
            expected.MinimumInventory.Should().Be(product.MinimumInventory);
            var expectedProductArrival = ReadContext.Set<ProductArrival>().Single();
            expectedProductArrival.ProductId.Should().Be(dto.ProductId);
            expectedProductArrival.Number.Should().Be(dto.Number);
            expectedProductArrival.InvoiceNumber.Should().Be(dto.InvoiceNumber);
            expectedProductArrival.CompanyName.Should().Be(dto.CompanyName);
        }

        [Fact]
        public void Add_add_product_arrival_with_5_available()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id);
            DbContext.Save(product);

            var sut = ProductArrivalServiceFactory.Generate(SetupContext);
            var dto = ProductArrivalDtoFactory.Create(product.Id, 5, "123a", "dummy_compani_name");
            sut.Add(dto);

            var expected = ReadContext.Set<Product>().Single(_ => _.GroupId == group.Id);
            expected.Title.Should().Be(product.Title);
            expected.Inventory.Should().Be(dto.Number);
            expected.Condition.Should().Be(Condition.ReadyToOrder);
            expected.MinimumInventory.Should().Be(product.MinimumInventory);
            var expectedProductArrival = ReadContext.Set<ProductArrival>().Single();
            expectedProductArrival.ProductId.Should().Be(dto.ProductId);
            expectedProductArrival.Number.Should().Be(dto.Number);
            expectedProductArrival.InvoiceNumber.Should().Be(dto.InvoiceNumber);
            expectedProductArrival.CompanyName.Should().Be(dto.CompanyName);
        }

        [Fact]
        public void Add_throw_exception_when_product_id_not_found()
        {
            var invalidProductId = 1;

            var sut = ProductArrivalServiceFactory.Generate(SetupContext);
            var dto = ProductArrivalDtoFactory.Create(invalidProductId);
            var expected = ()=> sut.Add(dto);
            expected.Should().ThrowExactly<ProductIdNotFoundException>();
        }

        [Fact]
        public void GetAll_get_all_product_arrvial()
        {
            var group = AddGroupFactory.Create();
            DbContext.Save(group);
            var product = AddProductFactory.Create(group.Id);
            DbContext.Save(product);
            var productArrvial = AddProductArrivalFactory.Create(product.Id);
            DbContext.Save(productArrvial);

            var sut = ProductArrivalServiceFactory.Generate(SetupContext);
            var result=sut.GetAll();

            result.Single().ProductTitle.Should().Be(product.Title);
            result.Single().Number.Should().Be(productArrvial.Number);
            result.Single().InvoiceNumber.Should().Be(productArrvial.InvoiceNumber);
            result.Single().CompaniName.Should().Be(productArrvial.CompanyName);

        }

    }
}
