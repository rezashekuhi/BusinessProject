using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Contracts;
using Templete.Services.Groups.Contracts;
using Templete.Services.Groups.Exceptions;
using Templete.Services.Products.Contracts;
using Templete.Services.Products.Dto;
using Templete.Services.Products.Exceptions;

namespace Templete.Services.Products
{
    public class ProductAppService : ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly GroupRepository _groupRepository;
        public ProductAppService(ProductRepository productRepository,
            UnitOfWork unitOfWork,
            GroupRepository groupRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _groupRepository = groupRepository;
        }
        public void Add(AddProductDto dto)
        {
            var isExsistGroupId = _groupRepository.IsExistById(dto.GroupId);
            if (isExsistGroupId==false)
            {
                throw new GroupIdNotFoundException();
            }

            var duplicateTitle = _productRepository.IsExsistByTitle(dto.Title);
            if (duplicateTitle==true)
            {
                throw new ProductIsDuplicateException();
            }

            var product = new Product
            {
                Title=dto.Title,
                GroupId=dto.GroupId,
                 Condition=Condition.Unavailable,
                 Inventory=0,
                 MinimumInventory=dto.MinimumInventory
            };
            _productRepository.Add(product);
            _unitOfWork.Complete();
        }
    }
}
