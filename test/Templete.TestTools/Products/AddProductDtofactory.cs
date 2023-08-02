using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Products.Dto;

namespace Templete.TestTools.Products
{
    public static class AddProductDtofactory
    {
        public static AddProductDto Create(int groupId, string title="dummy_title"
            ,int minimumInventory=10)
        {
            return new AddProductDto
            {
                GroupId = groupId,
                Title = title,
                MinimumInventory = minimumInventory
            };
        }
    }
}
