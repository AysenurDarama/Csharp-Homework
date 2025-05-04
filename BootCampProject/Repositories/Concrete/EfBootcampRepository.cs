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

public class EfBootcampRepository : EfRepositoryBase<Bootcamp, BootcampContext>, IBootcampRepository
{
    public EfBootcampRepository(BootcampContext context) : base(context)
    {
    }
}
