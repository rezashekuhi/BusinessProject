using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;
using Templete.Services.ProductArrivals.Contracts;
using Templete.Services.ProductArrivals.Contracts.Dto;

namespace Templete.Persistanse.EF.ProductArrivals
{
    public class EFProductArrivalRepository : ProductArrivalRepository
    {
        private readonly DbSet<ProductArrival> _productArrivals;
        public EFProductArrivalRepository(EFDataContext context)
        {
            _productArrivals=context.Set<ProductArrival>();
        }

        public void Add(ProductArrival productArrival)
        {
            _productArrivals.Add(productArrival);
        }

        public List<GetAllProductArrvialDto> GetAll()
        {
            return _productArrivals.Select(_=> new GetAllProductArrvialDto
            {
                ProductTitle=_.Product.Title,
                Number=_.Number,
                InvoiceNumber=_.InvoiceNumber,
                CompaniName=_.CompanyName,
                DateTime=_.DateTime
            }).ToList();
        }
    }
}
