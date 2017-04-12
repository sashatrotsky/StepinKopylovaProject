using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart: EntitiesBase
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Cart()
        {
            Orders = new List<Order>();
        }
    }

}
