using Domain.Entities;
using Repository.Base;
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
