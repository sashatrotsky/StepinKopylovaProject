using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(DbContext context)
        {
        }

    }
}
