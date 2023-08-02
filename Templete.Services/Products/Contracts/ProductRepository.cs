using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.Products.Contracts
{
    public interface ProductRepository
    {
        bool IsExsistByGroupId(int groupId);
    }
}
