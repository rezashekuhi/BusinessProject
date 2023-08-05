using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.TestTools.Products
{
    public static class AddProductFactory
    {
        public static Product Create(int groupId, string title = "dummy_title"
        , Condition condition = Condition.Unavailable
            , int inventory = 0, int minimumInventory = 10)
        {
            return new Product
            {
                GroupId = groupId,
                Title = title,
                Condition = condition,
                Inventory = inventory,
                MinimumInventory = minimumInventory
            };
        }
    }
}
