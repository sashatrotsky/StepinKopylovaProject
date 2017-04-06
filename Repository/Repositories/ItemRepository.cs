using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Abstract
{
    public class ItemRepository : RepositoryBase<item>, IItemRepository
    {

        public ItemRepository(DbContext context)
        {
        }

    }

}
