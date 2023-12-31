﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.Groups.Contracts.Dto;
using Templete.Services.Products.Contracts.Dto;
using Templete.Services.Products.Dto;

namespace Templete.Services.Products.Contracts
{
    public interface ProductService
    {
        void Add(AddProductDto dto);
        List<GetAllProductDto> GetAll(SearchInGetAllDto dto);
        void Delete(int id);
    }
}
