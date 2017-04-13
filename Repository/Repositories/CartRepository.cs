using Domain.Entities;
using System.Data.Entity;
using Repository.Base;
using Repository.IRepositories;

namespace Repository.Repositories
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {

        public CartRepository(DbContext context) : base(context)
        {
        }

    }
}