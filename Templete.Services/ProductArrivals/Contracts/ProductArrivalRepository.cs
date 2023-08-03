using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.ProductArrivals.Contracts.Dto;

namespace Templete.Services.ProductArrivals.Contracts
{
    public interface ProductArrivalRepository
    {
        void Add(ProductArrival productArrival);
        List<GetAllProductArrvialDto> GetAll();
    }
}
