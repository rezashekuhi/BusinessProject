using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.ProductArrivals.Contracts.Dto;
using Templete.Services.ProductArrivals.Dto;

namespace Templete.Services.ProductArrivals.Contracts
{
    public interface ProductArrivalService
    {
        void Add(AddProductArrivalDto dto);
        List<GetAllProductArrvialDto> GetAll();
    }
}
