using ShopApp.Persistanse.EF.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Persistanse.EF;
using Templete.Persistanse.EF.Products;
using Templete.Services.Products;

namespace Templete.TestTools.Products
{
    public static class ProductServiceFactory
    {
        public static ProductAppService Generate(EFDataContext context)
        {
            var productRepository = new EFProductRepository(context);
            var unitOfWork = new EFUnitOfWork(context);
            var groupRepository = new EFGroupRepository(context);
            var sut=new ProductAppService(productRepository, unitOfWork,groupRepository);
            return sut;
        } 
    }
}
