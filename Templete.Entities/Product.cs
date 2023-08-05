using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Entities
{
    public class Product
    {
        public Product()
        {
            ProductArrivals = new HashSet<ProductArrival>();
            SalesInvoices= new HashSet<SalesInvoice>();
        }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; }
        public int Inventory { get; set; }
        public int MinimumInventory { get; set; }
        public Condition Condition { get; set; }

        public HashSet<ProductArrival> ProductArrivals { get; set; }
        public HashSet<SalesInvoice> SalesInvoices { get; set; }
        public Group Group { get; set; }
    }
    public enum Condition
    {
        Unavailable = 1,
        ReadyToOrder = 2,
        Available = 3

    }

}
