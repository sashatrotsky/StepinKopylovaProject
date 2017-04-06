using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FIO { get; set; }
        public string tel { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public User()
        {
            Orders = new List<Order>();
            Carts = new List<Cart>();
        }
       

       


    }
}
