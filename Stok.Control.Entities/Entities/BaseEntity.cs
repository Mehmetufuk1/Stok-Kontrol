using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok.Control.Entities.Entities
{
    public abstract class BaseEntity
    {
        [Column(Order = 1)]
        public int ID { get; set; }
        public bool isActive { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }



    }
}
