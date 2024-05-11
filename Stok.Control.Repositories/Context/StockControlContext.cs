using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stok.Control.Entities;
using Stok.Control.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok.Control.Repositories.Context
{
    public class StockControlContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-M2EMNTI;Database=StockControlDb;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        

    }
}
