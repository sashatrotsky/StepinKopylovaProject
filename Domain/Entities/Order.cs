using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
