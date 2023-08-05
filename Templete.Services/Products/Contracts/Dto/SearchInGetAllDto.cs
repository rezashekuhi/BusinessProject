using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.Services.Products.Contracts.Dto
{
    public class SearchInGetAllDto
    {
        public string? GroupName { get; set; }
        public string? ProductTitle { get; set; }
        public Condition? Condition { get; set; }

    }
}
