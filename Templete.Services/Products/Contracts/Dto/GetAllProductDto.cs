using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.Services.Products.Contracts.Dto
{
    public class GetAllProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GroupName { get; set; }
        public int Inventory { get; set; }
        public int MinimumInventory { get; set; }
        public Condition Condition { get; set; }
    }
}
