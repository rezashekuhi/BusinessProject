using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.Services.Groups.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Persistanse.EF;
using Templete.Services.Groups.Dto;

namespace ShopApp.Persistanse.EF.Groups
{
    public class EFGroupRepository : GroupRepository
    {
        private readonly DbSet<Group> _group;
        public EFGroupRepository(EFDataContext context)
        {
            _group=context.Set<Group>();
        }
        public void Add(Group group)
        {
            _group.Add(group);
        }

        public void Delete(Group group)
        {
            _group.Remove(group);
        }

        public Group FindeById(int id)
        {
            return _group.FirstOrDefault(_ => _.Id == id);
        }

        public List<GetAllGroupDto> GetAll()
        {
            return _group.Select(_=> new GetAllGroupDto
            {
                Id=_.Id,
                Name=_.Name
            }).ToList();
        }

        public GetGroupAndProductsByIdDto GetById(int id)
        {
            return _group.Where(_=>_.Id==id)
                .Select(_ => new GetGroupAndProductsByIdDto
            {
                Id=_.Id,
                Name=_.Name,
                Products = _.Products.Select(product => new GetProduct{
                    Id=product.Id,
                    Title=product.Title
                }).ToHashSet()
            }).FirstOrDefault();
        }

        public bool IsExistById(int id)
        {
            return _group.Any(_ => _.Id == id);
        }

        public bool IsExsistByName(string name)
        {
           return _group.Any(_=>_.Name==name);
        }
    }
}
