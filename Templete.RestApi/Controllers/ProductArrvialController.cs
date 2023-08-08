using Microsoft.AspNetCore.Mvc;
using Templete.Services.ProductArrivals.Contracts;
using Templete.Services.ProductArrivals.Contracts.Dto;
using Templete.Services.ProductArrivals.Dto;

namespace Templete.RestApi.Controllers
{
    [Route("product-arrvials")]
    [ApiController]
    public class ProductArrvialController : Controller
    {
        private readonly ProductArrivalService _service;
        public ProductArrvialController(ProductArrivalService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddProductArrivalDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllProductArrvialDto> GetAll()
        {
            return _service.GetAll();
        }
    }
}
