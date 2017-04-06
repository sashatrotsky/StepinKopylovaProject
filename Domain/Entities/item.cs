using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class item
    {
        public int Id { get; set; }
        public int itemId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public item()
        {
            Carts = new List<Cart>();
        }
    }
}
