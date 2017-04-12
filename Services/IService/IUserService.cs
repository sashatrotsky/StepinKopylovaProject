using Domain.Entities;
using Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IUserService
    {

        IEnumerable<UserEntity> GetAll();
        void Add(UserEntity user);
        void Update(UserEntity user);
        void Delete(User nazv);
    }
}

}
}
