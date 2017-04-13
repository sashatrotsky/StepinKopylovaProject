using System.Data.Entity;
using Domain.Entities;
using Repository.Base;

namespace Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(DbContext context) : base(context)
        {
        }

    }
}
