using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Repository.Repositories;

namespace Repository.Entity
{
  public interface All 
    {
        IRepositoryBase<Cart> cart { get; }
        IRepositoryBase<Item> item { get; }
        IRepositoryBase<Order> order { get; }
        IRepositoryBase<User> user { get; }
    }
}
