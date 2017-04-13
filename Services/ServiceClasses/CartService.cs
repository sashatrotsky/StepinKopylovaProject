using Domain.Entities;
using Repository.Base;
using Services.Base;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceClasses
{
    public class CartService : ServiceBase<Cart>, ICartService
    {

        public CartService(IRepositoryBase<Cart> repository) : base(repository)
        {
        }

    }
}

