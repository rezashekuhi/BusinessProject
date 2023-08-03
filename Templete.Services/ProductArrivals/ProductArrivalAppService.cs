using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Contracts;
using Templete.Services.ProductArrivals.Contracts;
using Templete.Services.ProductArrivals.Contracts.Dto;
using Templete.Services.ProductArrivals.Dto;
using Templete.Services.ProductArrivals.Exceptions;
using Templete.Services.Products.Contracts;

namespace Templete.Services.ProductArrivals
{
    public class ProductArrivalAppService : ProductArrivalService
    {
        private readonly ProductArrivalRepository _productArrivalRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _productRepository;
        public ProductArrivalAppService(ProductArrivalRepository productArrivalRepository,
            UnitOfWork unitOfWork,ProductRepository productRepository)
        {
            _productArrivalRepository = productArrivalRepository;
            _unitOfWork = unitOfWork;
            _productRepository=productRepository;
        }

        public void Add(AddProductArrivalDto dto)
        {
            var product = _productRepository.FindeById(dto.ProductId);
            if (product==null)
            {
                throw new ProductIdNotFoundException();
            }
            if (dto.Number <= product.MinimumInventory )
            {
                product.Condition = Condition.ReadyToOrder;
              
            }
            else
            {
                product.Condition = Condition.Available;
           
            }
            product.Inventory = dto.Number;
            _productRepository.Update(product);
      
            var productArrival = new ProductArrival
            {
                ProductId = dto.ProductId,
                Number = dto.Number,
                InvoiceNumber = dto.InvoiceNumber,
                CompanyName = dto.CompanyName,
                DateTime = DateTime.Now
            };

            _productArrivalRepository.Add(productArrival);
            _unitOfWork.Complete();
        }

        public List<GetAllProductArrvialDto> GetAll()
        {
            return _productArrivalRepository.GetAll();
        }
    }
}
