using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Persistanse.EF;
using Templete.Persistanse.EF.Groups;
using Templete.Persistanse.EF.Products;
using Templete.Services.Groups;

namespace Templete.TestTools.Groups
{
    public static class GroupServiceFactory
    {
        public static GroupAppService Generate(EFDataContext contex)
        {
            var groupRepository = new EFGroupRepository(contex);
            var unitOfWorkRepository = new EFUnitOfWork(contex);
            var productRepository = new EFProductRepository(contex);
            var sut = new GroupAppService(groupRepository, unitOfWorkRepository, productRepository);
            return sut;
        }
    }
}
