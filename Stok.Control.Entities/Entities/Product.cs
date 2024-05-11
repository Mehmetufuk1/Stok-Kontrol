using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok.Control.Entities.Entities
{
    public class Product :BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short? Stock { get; set; }
        public DateTime? ExpiredDate { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }
        public Supplier? Supplier { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public Product()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}
