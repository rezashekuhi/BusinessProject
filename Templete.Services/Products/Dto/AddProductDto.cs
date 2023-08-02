using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.Products.Dto
{
    public class AddProductDto
    {
        public string Title { get; set; }
        public int GroupId { get; set; }
        public int MinimumInventory { get; set; }
    }
}
