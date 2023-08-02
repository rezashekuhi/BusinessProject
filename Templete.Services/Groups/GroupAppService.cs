using ShopApp.Entities;
using ShopApp.Services.Groups.Contract;
using ShopApp.Services.Groups.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Contracts;
using Templete.Services.Groups.Dto;
using Templete.Services.Groups.Exceptions;
using Templete.Services.Products.Contracts;

namespace ShopApp.Services.Groups
{
    public class GroupAppService : GroupService
    {
        private readonly GroupRepository _groupRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _productRepository;
        public GroupAppService(GroupRepository groupRepository
            ,UnitOfWork unitOfWork,
            ProductRepository productRepository)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public void Add(AddGroupDto dto)
        {
            var isExsistByName=_groupRepository.IsExsistByName(dto.Name);
            if (isExsistByName == true)
            {
                throw new DuplicateGroupNameException();
            }

            var group = new Group
            {
                Name = dto.Name
            };
            _groupRepository.Add(group);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var group = _groupRepository.FindeById(id);
            var groupHasAProduct = _productRepository.IsExsistByGroupId(id);
            if (groupHasAProduct==true)
            {
                throw new GroupHasAProductException();
            }
            
            if (group==null)
            {
                throw new GroupIdNotFoundException();
            }
            _groupRepository.Delete(group);
            _unitOfWork.Complete();
        }

        public List<GetAllGroupDto> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public GetGroupAndProductsByIdDto GetById(int id)
        {
            return _groupRepository.GetById(id);
        }
    }
}
