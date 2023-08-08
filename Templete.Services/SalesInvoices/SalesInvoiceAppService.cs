using Templete.Entities;
using Templete.Services.AccountingDocuments.Contract;
using Templete.Services.Contracts;
using Templete.Services.ProductArrivals.Exceptions;
using Templete.Services.Products.Contracts;
using Templete.Services.SalesInvoices.Contracts;
using Templete.Services.SalesInvoices.Contracts.Dto;
using Templete.Services.SalesInvoices.Exceptions;

namespace Templete.Services.SalesInvoices
{
    public class SalesInvoiceAppService : SalesInvoiceService
    {
        private readonly SalesInvoiceRepository _salesInvoiceRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _productRepository;
        private readonly AccountingDocumentRepository _documentRepository;
        public SalesInvoiceAppService(SalesInvoiceRepository salesInvoiceRepository,
            ProductRepository productRepository,
            UnitOfWork unitOfWork, AccountingDocumentRepository documentRepository)
        {
            _salesInvoiceRepository = salesInvoiceRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _documentRepository = documentRepository;
        }

        public void Add(AddSalesInvoiceDto dto)
        {
            var product = _productRepository.FindeById(dto.ProductId);

            if (product==null)
            {
                throw new ProductIdNotFoundException();
            }

            if (dto.Number>product.Inventory)
            {
                throw new QuantityEnteredIsMoreThanTheProductStockException();
            }

            product.Inventory = product.Inventory - dto.Number;

            if (product.Inventory <= product.MinimumInventory && product.Inventory>0)
            {
                product.Condition = Condition.ReadyToOrder;
            }
            else if (product.Inventory >= product.MinimumInventory)
            {
                product.Condition = Condition.Available;
            }else
            {
                product.Condition = Condition.Unavailable;
            }

            _productRepository.Update(product);

            var salesInvoice = new SalesInvoice
            {
                ProductId = dto.ProductId,
                Number = dto.Number,
                CustomerName = dto.CustomerName,
                Price = dto.UnitPrice,
                InvoiceNumber = dto.InvoiceNumber,
                DateTime = DateTime.Now
            };

            var accountingDocument = new AccountingDocument
            {
                SalesInvoiceId=salesInvoice.Id,
                InvoiceNumber=salesInvoice.InvoiceNumber,
                TotalAmount=dto.UnitPrice * dto.Number,
                DateTime=salesInvoice.DateTime
            };
            salesInvoice.AccountingDocuments.Add(accountingDocument);

            _salesInvoiceRepository.Add(salesInvoice);

            _unitOfWork.Complete();
        }

        public List<GetAllSalesInvoiceDto> GetAll()
        {
            return _salesInvoiceRepository.GetAll();
        }
    }
}
