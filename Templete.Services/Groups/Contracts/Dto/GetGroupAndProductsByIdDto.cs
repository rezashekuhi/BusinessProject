using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.Groups.Dto
{
    public class GetGroupAndProductsByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<GetProduct> Products { get; set; }
    }

    public class GetProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
