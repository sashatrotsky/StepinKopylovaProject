using Domain.Entities;
using Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
   public interface IItemService
    {

            IEnumerable<ItemEntity> GetAll();
            void Add(ItemEntity item);
            void Update(ItemEntity item);
            void Delete(Item nazv);
        }
    }

}
}
