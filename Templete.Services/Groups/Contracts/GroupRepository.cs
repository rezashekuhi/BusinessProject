using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups.Dto;

namespace Templete.Services.Groups.Contracts
{
    public interface GroupRepository
    {
        void Add(Group group);
        bool IsExsistByName(string name);
        Group FindeById(int id);
        void Delete(Group group);
        List<GetAllGroupDto> GetAll();
        GetGroupAndProductsByIdDto GetById(int id);
        bool IsExistById(int id);
    }
}
