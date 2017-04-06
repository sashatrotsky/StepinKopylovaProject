using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
   public class EFDbContext: DbContext
    {
        public DbSet<item> items { get; set; }
        public DbSet<Cart> Carts { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
