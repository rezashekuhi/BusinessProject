using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
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

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product FindeById(int id)
        {
            return _products.FirstOrDefault(_=>_.Id == id);
        }

        public bool IsExsistByGroupId(int groupId)
        {
            return _products.Any(_ => _.GroupId == groupId);
        }

        public bool IsExsistByTitle(string title)
        {
            return _products.Any(_ => _.Title == title);
        }

        public void Update(Product product)
        {
            _products.Update(product);
        }
    }
}
