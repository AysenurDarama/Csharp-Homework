using Entities;
using Repositories.Abstract;
using Repositories.Contexts;
using Repositories.EfRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete;

public class EfUserRepository : EfRepositoryBase<User, BootcampContext>, IUserRepository
{
    public EfUserRepository(BootcampContext context) : base(context)
    {
    }
}
