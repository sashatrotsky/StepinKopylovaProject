﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {

        public OrderRepository(DbContext context)
        {
        }

    }
}
