using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Groups.Contracts.Dto;
using Templete.Services.Groups.Dto;

namespace Templete.Services.Groups.Contracts
{
    public interface GroupService
    {
        void Add(AddGroupDto dto);
        void Delete(int id);
        List<GetAllGroupDto> GetAll();
        GetGroupAndProductsByIdDto GetById(int id);
        void Edite(EditeGroupDto dto);
    }
}
