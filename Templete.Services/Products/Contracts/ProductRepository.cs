using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.Services.Products.Contracts
{
    public interface ProductRepository
    {
        bool IsExsistByGroupId(int groupId);
        bool IsExsistByTitle(string title);
        void Add(Product product);
        Product FindeById(int id);
        void Update(Product product);
    }
}
