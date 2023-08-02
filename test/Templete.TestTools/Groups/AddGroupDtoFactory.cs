using ShopApp.Entities;
using ShopApp.Services.Groups.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.TestTools.Groups
{
    public static class AddGroupDtoFactory
    {
        public static AddGroupDto create(string name="dummy")
        {
            return new AddGroupDto
            {
                Name=name
            };
        }
    }
}
