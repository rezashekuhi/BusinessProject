using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; }
        public int Inventory { get; set; }
        public int MinimumInventory { get; set; }
        public Condition Condition { get; set; }

        public List<ProductArrival> ProductArrivals { get; set; }
        public List<SalesInvoice> SalesInvoices { get; set; }
        public Group Group { get; set; }
    }
    public enum Condition
    {
        Unavailable = 1,
        ReadyToOrder = 2,
        Available = 3

    }

}
