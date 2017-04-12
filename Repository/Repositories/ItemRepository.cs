using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {

        public ItemRepository(DbContext context) : base(context)
        {
        }

    }

}
