using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Persistanse.EF;
using Templete.Persistanse.EF.Groups;
using Templete.Persistanse.EF.ProductArrivals;
using Templete.Persistanse.EF.Products;
using Templete.Services.ProductArrivals;

namespace Templete.TestTools.ProductArrivals
{
    public static class ProductArrivalServiceFactory
    {
        public static ProductArrivalAppService Generate(EFDataContext context)
        {
            var productArrivalRepository = new EFProductArrivalRepository(context);
            var unitOfWork = new EFUnitOfWork(context);
            var productRepository = new EFProductRepository(context); 
            var sut = new ProductArrivalAppService(productArrivalRepository,unitOfWork,productRepository);
            return sut;
        }
    }
}
