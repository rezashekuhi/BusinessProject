using Microsoft.AspNetCore.Mvc;
using Templete.Services.Products.Contracts;
using Templete.Services.Products.Contracts.Dto;
using Templete.Services.Products.Dto;

namespace Templete.RestApi.Properties.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddProductDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllProductDto> GetAll([FromQuery]SearchInGetAllDto dto)
        {
            return _service.GetAll(dto);
        }

    }
}
