using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.TestTools.Groups
{
    public static class AddGroupFactory
    {
        public static Group Create(string name = "dummy")
        {
            return new Group
            {
                Name = name
            };
        }
    }
}
