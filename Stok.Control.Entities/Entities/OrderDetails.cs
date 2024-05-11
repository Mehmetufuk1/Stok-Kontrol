using Stok.Control.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok.Control.Entities
{
    public class OrderDetails:BaseEntity
    {
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}