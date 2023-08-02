using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Products.Contracts;

namespace Templete.Persistanse.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly DbSet<Product> _products;
        public EFProductRepository(EFDataContext context)
        {
            _products=context.Set<Product>();
        }
        public bool IsExsistByGroupId(int groupId)
        {
            return _products.Any(_ => _.GroupId == groupId);
        }
    }
}
