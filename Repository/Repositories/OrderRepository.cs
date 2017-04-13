using System.Data.Entity;
using Domain.Entities;
using Repository.Base;
using Repository.IRepositories;

namespace Repository.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {

        public OrderRepository(DbContext context) : base(context)
        {
        }

    }
}
