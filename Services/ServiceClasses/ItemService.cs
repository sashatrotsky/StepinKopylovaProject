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
   public class ItemService : ServiceBase<Item>, IItemService
    {
      
            public ItemService(IRepositoryBase<Item> repository) : base(repository)
            {
            }

    }
}

