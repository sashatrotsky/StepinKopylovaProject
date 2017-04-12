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
    public class UserService : IUserService
    {
        private All Database { get; set; }

        public UserService(All bd)
        {
            Database = bd;
        }
        public IEnumerable<UserEntity> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserEntity>());
            return Mapper.Map<IEnumerable<User>, List<UserEntity>>(Database.user.GetAll());
        }
        public void Add(UserEntity user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserEntity, User>());
            var cr = Mapper.Map<UserEntity, User>(user);
            Database.user.Add(cr);
        }

        public void Update(UserEntity user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserEntity, User>());
            var cr = Mapper.Map<UserEntity, User>(user);
            Database.user.Update(cr);
        }
        public void Delete(User nazv)
        {
            Database.user.Delete(nazv);
        }
    }
}
