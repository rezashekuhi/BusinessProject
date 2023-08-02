using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Products.Dto;

namespace Templete.Services.Products.Contracts
{
    public interface ProductService
    {
        void Add(AddProductDto dto);
    }
}
