using System;
using System.Collections.Generic;
using Domain.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {

        public CartRepository(DbContext context) : base(context)
        {
        }

    }
}