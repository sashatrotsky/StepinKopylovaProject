using Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Services.IService;
using Repository.Entity;

namespace Services.Service
{
    public class ItemService : IItemService
    {
        private All Database { get; set; }

        public ItemService(All bd)
        {
            Database = bd;
        }
        public IEnumerable<ItemEntity> GetAll() 
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Item, ItemEntity>());
            return Mapper.Map<IEnumerable<Item>, List<ItemEntity>>(Database.item.GetAll());
        }
        public void Add(ItemEntity item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ItemEntity, Item>());
            var cr = Mapper.Map<ItemEntity, Item>(item);
            Database.item.Add(cr);
        }

        public void Update(ItemEntity item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ItemEntity, Item>());
            var cr = Mapper.Map<ItemEntity, Item>(item);
            Database.item.Update(cr);
        }
        public void Delete(Item nazv)
        {
            Database.item.Delete(nazv);
        }
    }
}
