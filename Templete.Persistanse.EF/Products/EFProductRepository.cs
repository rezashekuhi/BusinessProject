using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups.Contracts.Dto;
using Templete.Services.Products.Contracts;
using Templete.Services.Products.Contracts.Dto;

namespace Templete.Persistanse.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly DbSet<Product> _products;
        public EFProductRepository(EFDataContext context)
        {
            _products=context.Set<Product>();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            _products.Remove(product);
        }

        public Product FindeById(int id)
        {
            return _products.FirstOrDefault(_=>_.Id == id);
        }


        public List<GetAllProductDto> GetAll(SearchInGetAllDto dto)
        {

            var result= _products
                .Select(_=> new GetAllProductDto
                {
                    Id=_.Id,
                    GroupName=_.Group.Name,
                    Title=_.Title,
                    Inventory=_.Inventory,
                    MinimumInventory=_.MinimumInventory,
                    Condition=_.Condition
                }).ToList();

            if (!string.IsNullOrWhiteSpace(dto.GroupName))
            {
                result = result.Where(_ => _.GroupName.Contains(dto.GroupName)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(dto.ProductTitle))
            {
                result = result.Where(_ => _.Title.Contains(dto.ProductTitle)).ToList();
            }

            if (dto.Condition>0)
            {
                result = result.Where(_ => _.Condition == dto.Condition).ToList();
            }

            return result;
        }

        public bool IsExsistByGroupId(int groupId)
        {
            return _products.Any(_ => _.GroupId == groupId);
        }

        public bool IsExsistByTitle(string title)
        {
            return _products.Any(_ => _.Title == title);
        }

        public void Update(Product product)
        {
            _products.Update(product);
        }
    }
}
