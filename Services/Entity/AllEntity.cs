using System;
using Domain.Entities;
using Repository.Repositories;

namespace Repository.Interfaces
{
    public interface AllEntity
    {
        IRepositoryBase<Cart> Cart{ get; }
        IRepositoryBase<Item> Item { get; }
        IRepositoryBase<Order> Order { get; }
        IRepositoryBase<User> User { get; }
    }
}
