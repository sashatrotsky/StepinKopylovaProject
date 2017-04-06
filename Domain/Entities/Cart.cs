using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int itemId { get; set; }
        public virtual item Item { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Cart()
        {
            Orders = new List<Order>();
        }
    }

}
