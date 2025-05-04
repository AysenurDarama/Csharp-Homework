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

public class EfApplicationRepository : EfRepositoryBase<Application, BootcampContext>, IApplicationRepository
{
    public EfApplicationRepository(BootcampContext context) : base(context)
    {
    }
}
