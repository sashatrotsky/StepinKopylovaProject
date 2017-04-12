using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Repository.Interfaces;
using Repository.Repositories;
using AutoMapper;
using Domain.Abstract;

namespace Services
{
    public class ServiceBase : IItemService
    {
        private Property Database { get; set; }

        public Servicebd(Property bd)
        {
            Database = bd;
        }



        public IEnumerable<Item> Get()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Item, >());
            return Mapper.Map<IEnumerable<T>, List<T>>(Database.nazv.GetAll());
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public GameTransfer GetGame(int? id)
        {
            var game = Database.Games.Get(id.Value);
            Mapper.Initialize(cfg => cfg.CreateMap<Game, GameTransfer>());
            return Mapper.Map<Game, GameTransfer>(game);
        }

        public void Create(GameTransfer game)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GameTransfer, Game>());
            var gg = Mapper.Map<GameTransfer, Game>(game);
            Database.Games.Create(gg);
        }

        public void Update(GameTransfer item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GameTransfer, Game>());
            var gg = Mapper.Map<GameTransfer, Game>(item);
            Database.Games.Update(gg);
        }

        public IEnumerable<GameTransfer> Find(string predicate)
        {
            var game = Database.Games.Find(predicate);
            Mapper.Initialize(cfg => cfg.CreateMap<Game, GameTransfer>());
            return Mapper.Map<IEnumerable<Game>, List<GameTransfer>>(game);
        }

        public IEnumerable<GameTransfer> Search(string predicate)
        {
            var game = Database.Games.Search(predicate);
            Mapper.Initialize(cfg => cfg.CreateMap<Game, GameTransfer>());
            return Mapper.Map<IEnumerable<Game>, List<GameTransfer>>(game);
        }

        public void Delete(int id)
        {
            Database.Games.Delete(id);
        }
    }
}
