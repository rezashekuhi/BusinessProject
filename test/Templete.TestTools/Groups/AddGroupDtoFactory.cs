
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Groups.Dto;

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
