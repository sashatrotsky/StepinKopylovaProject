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
    public class OrderService : ServiceBase<Order>, IOrderService
    {

        public OrderService(IRepositoryBase<Order> repository) : base(repository)
        {
        }

    }
}

