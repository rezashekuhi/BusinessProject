using Microsoft.AspNetCore.Mvc;
using Templete.Services.Groups.Contracts;
using Templete.Services.Groups.Dto;

namespace Templete.RestApi.Properties.Controllers
{
    [Route("groups")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly GroupService _Service;
        public GroupController(GroupService service)
        {
            _Service = service;
        }

        [HttpPost]
        public void Add([FromBody]AddGroupDto dto)
        {
            _Service.Add(dto);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            _Service.Delete(id);
        }

        [HttpGet]
        public List<GetAllGroupDto> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet("{id}")]
        public GetGroupAndProductsByIdDto GetById([FromRoute]int id)
        {
            return _Service.GetById(id);
        }
      
    }
}
