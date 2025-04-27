using Entities;
using Entities.Data;
using Repositories.Abstract;
using Repositories.EfRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete;

public class UserRepository : EfRepositoryBase<User>, IUserRepository
{
    public UserRepository(BootcampContext context) : base(context)
    {
    }
}
