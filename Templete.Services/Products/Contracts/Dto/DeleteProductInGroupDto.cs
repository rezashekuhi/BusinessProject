using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.Groups.Contracts.Dto
{
    public class DeleteProductInGroupDto
    {
        public int GroupId { get; set; }
        public int ProductId { get; set; }
    }
}
