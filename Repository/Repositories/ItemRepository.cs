using Domain.Entities;
using System.Data.Entity;
using Repository.Base;
using Repository.IRepositories;

namespace Repository.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {

        public ItemRepository(DbContext context) : base(context)
        {
        }

    }
}